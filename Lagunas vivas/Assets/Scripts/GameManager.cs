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
    #region references
    EventManager _eventManager;
    RecursosManager _recursosManager;
    #endregion       
}
