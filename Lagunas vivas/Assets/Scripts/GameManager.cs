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
    public RecursosManager getResMan() { return _recursosManager; }
    public UIManager getUIManager() { return _UIManager; }
    public Sprite getImageEv(int i) {  return _listImages.getImage(i); }
    #endregion
    public bool EnJuego = true;
    #endregion
    public void sendEvent(GameObject clickedObject)
    {
        ClickeableObject clickeable = clickedObject.GetComponent<ClickeableObject>();
        clickeable.enviaEvento();
        _eventManager.getEventos();
    }
    public void HandleClick(GameObject clickedObject)
    {
        ClickeableObject clickeable = clickedObject.GetComponent<ClickeableObject>();

        if (clickeable != null)
        {
            if(clickeable.getNumScene() < 0)
            GenerateNewEvent();
            else
            {
                SceneManager.LoadScene(clickeable.getNumScene());
            }
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
}
