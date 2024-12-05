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
    #endregion
    #region recursos/variables
    #region references
    EventManager _eventManager;
    RecursosManager _recursosManager;
    UIManager _UIManager;
    ListaImagenes _listImages;
    TurnosManager _turnosManager;
    public RecursosManager getResMan() { return _recursosManager; }
    public UIManager getUIManager() { return _UIManager; }
    public Sprite getImageEv(int i) {  return _listImages.getImage(i); }
    #endregion
    public bool EnJuego = true;
    int setPrefabs = -1;
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
            if(clickeable.getNumScene() < 0)
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
                    setPrefabs =clickeable.getNumScene() - 2;
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
