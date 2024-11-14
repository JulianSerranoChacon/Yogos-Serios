using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Instance
    static private GameManager _instance;
    public GameManager Instance() {
        if (_instance == null)
            _instance = this;
        return _instance;}
    #endregion
    #region Asignaciones
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
    }
}
