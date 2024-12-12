using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    private bool _runningEvent = false; // Determina si ya hay un evento en proceso
    #region Instance
    static private GameManager _instance;
    static public GameManager Instance { get { return _instance; } }
    #endregion
    #region Asignaciones
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
        _recursosManager = GetComponent<RecursosManager>();
        _turnosManager = GetComponent<TurnosManager>();
        _listImages = GetComponent<ListaImagenes>();
        _dialogos = GetComponent<Dialogos>();
    }
    public void AssignEventManager(EventManager x)
    {
        _eventManager = x;
    }
    public void AssignUIManager(UIManager x) 
    { 
        _UIManager = x;
    }
    public void setEvent(string s)
    {
        _eventManager.setEvento(s);
    }

    public void setDialogoInicial(bool b = true) { _dialogoinicial = b; }
    public bool getDialogoInicial() {  return _dialogoinicial; }
    #endregion
    #region recursos/variables
    #region references
    EventManager _eventManager;
    RecursosManager _recursosManager;
    UIManager _UIManager;
    ListaImagenes _listImages;
    TurnosManager _turnosManager;
    Dialogos _dialogos;
    public RecursosManager getResMan() { return _recursosManager; }
    public UIManager getUIManager() { return _UIManager; }
    public Sprite getImageEv(int i) {  return _listImages.getImage(i); }
    public Dialogos GetDialogos() { return _dialogos; }
    public string[] getWeekDialogue(int day)
    {
        switch (day)
        {
            case 1:
                return _dialogos.semana1;
                break;
            case 2:
                return _dialogos.semana2;
                break;
            case 3:
                return _dialogos.semana3;
                break;
            case 4:
                return _dialogos.semana4;
                break;
            case 5:
                return _dialogos.semana5;
                break;
            case 6:
                return _dialogos.semana6;
                break;
            case 7:
                return _dialogos.semana7;
                break;
            case 8:
                return _dialogos.semana8;
                break;
            case 9:
                return _dialogos.semana9;
                break;
            case 10:
                return _dialogos.semana10;
                break;
            default:
                return new string[0];
                break;
        }
    }
    public string[] getRecursoDialogue(string recurso)
    {
        switch (recurso)
        {
            case "Felicidad":
                if (_recursosManager.getFelicidad() < Constants.MAX_REC * 0.25)
                    return _dialogos.pocoFe;
                else if(_recursosManager.getFelicidad() < Constants.MAX_REC * 0.75)
                    return _dialogos.muchoFe;
                else
                    return _dialogos.bastanteFe;
                break;
            case "Fauna":
                if (_recursosManager.getFauna() < Constants.MAX_REC * 0.25)
                    return _dialogos.pocoFa;
                else if (_recursosManager.getFauna() < Constants.MAX_REC * 0.75)
                    return _dialogos.muchoFa;
                else
                    return _dialogos.bastanteFa;
                break;
            case "Dinero":
                if (_recursosManager.getDinero() < Constants.BIEN_DE_DINERO * 0.25)
                    return _dialogos.pocoD
                        ;
                else if (_recursosManager.getDinero() < Constants.BIEN_DE_DINERO * 2)
                    return _dialogos.muchoD;
                else
                    return _dialogos.bastanteD;
                break;
            case "Ecosistema":
                if (_recursosManager.getEcosistema() < Constants.MAX_REC * 0.25)
                    return _dialogos.pocoE;
                else if (_recursosManager.getEcosistema() < Constants.MAX_REC * 0.75)
                    return _dialogos.muchoE;
                else
                    return _dialogos.bastanteE;
                break;
            default: 
                return new string[0];
                break;

        }
    }

    #endregion
    public bool EnJuego = true;
    int setPrefabs = -1;


    private bool _dialogoinicial = false;
    #endregion
    public void sendEvent(GameObject clickedObject)
    {
        ClickeableObject clickeable = clickedObject.GetComponent<ClickeableObject>();
        if(clickeable != null)
        {
            clickeable.enviaEvento();
            _eventManager.getEventos();
        }            
    }

    public void HandleClick(GameObject clickedObject)
    {
        ClickeableObject clickeable = clickedObject.GetComponent<ClickeableObject>();

        if (clickeable != null)
        {

            if (!_eventManager.IsThereEvent())
            {
                if (clickeable.getNumScene() < 0)
                {
                    GenerateNewEvent();
                    if (clickeable.posEnArray != -1) _turnosManager.Uncheck(clickeable.posEnArray);
                    Destroy(clickedObject);
                }
                else
                {
                    SceneManager.LoadScene(clickeable.getNumScene());
                    if (clickeable.getNumScene() == 2 || clickeable.getNumScene() == 3 || clickeable.getNumScene() == 4)
                    {
                        setPrefabs = clickeable.getNumScene() - 2;
                    }
                }
            }            
        }
    }
    public void PullUpPrefabs()
    {
        if(setPrefabs != -1)
        {
            _turnosManager.Show(setPrefabs);
            setPrefabs=-1;
        }
    }
    public void GenerateNewEvent()
    {
        if (!_runningEvent)
        {
            _runningEvent = true;
            _eventManager.NewEvent();
        }
    }
    public void EventFinsihed()
    {
        _runningEvent = false;
    }
    public int getTurno()
    {
        return _turnosManager.GetTurno();
    }
    public bool getLagunaTieneEventos(int donde)
    {
        return _turnosManager.LagunaTieneEventos(donde);
    }
}
