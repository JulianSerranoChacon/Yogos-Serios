using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Instance
    static private GameManager _instance;
    static public GameManager Instance { get { return _instance; } }
    #endregion
    #region Asignaciones
    void OnEnable()
    {
        if (Instance != null)
            Destroy(gameObject);

        _instance = this;
        DontDestroyOnLoad(gameObject);
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
    public void HandleClick(GameObject clickedObject)
    {
        ClickeableObject clickeable = clickedObject.GetComponent<ClickeableObject>();

        if (clickeable != null)
        {
            GenerateNewEvent();
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
