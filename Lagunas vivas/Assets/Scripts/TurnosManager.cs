using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnosManager : MonoBehaviour
{
    #region recursos
    int TurnoActual;
    #endregion
    private void Start()
    {
        TurnoActual = 0;
    }

    public int GetTurno()
    { 
        return TurnoActual; 
    }

    public void NextTurn()
    {
        TurnoActual++;
    }
}
