using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Instance
    static private GameManager _instance;
    static public GameManager Instance { get { return _instance; } }
    void Awake()
    {
        _instance = GetComponent<GameManager>();
    }
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
    #endregion
    #region recursos/variables
    #region references
    EventManager _eventManager;
    RecursosManager _recursosManager;
    public RecursosManager getResMan() { return _recursosManager; }
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
