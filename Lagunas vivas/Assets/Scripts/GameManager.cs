using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
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
    }
    public void AssignEventManager(EventManager x)
    {
        _eventManager = x;
    }
    public void AssignRecursosManager(RecursosManager x)
    {
        _recursosManager = x;
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
    public RecursosManager getResMan() { return _recursosManager; }
    public UIManager getUIManager() { return _UIManager; }
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
        _eventManager.NewEvent();
    }
    void Start()
    {
        _UIManager.ActualizarInterfaz();    
    }
}
