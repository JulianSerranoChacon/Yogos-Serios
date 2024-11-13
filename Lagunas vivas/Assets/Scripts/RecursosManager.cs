using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecursosManager : MonoBehaviour
{
    #region variables
    //Cantidad de dinero
    int _dinero;
    //Los recursos que irán manejados mediante barras
    double _felicidad;
    double _ecosistema;
    double _fauna;
    #endregion

    void Start()
    {
        GameManager.Instance.AssignRecursosManager(this);
        init();
    }
    //Método al que se llama para inicializar los recursos
    public void init()
    {
        _dinero = Constants.DINERO_INICIAL;
        _felicidad = Constants.MAX_REC * Constants.PORCENTAJE_INICIAL;
        _ecosistema = Constants.MAX_REC * Constants.PORCENTAJE_INICIAL;
        _fauna = Constants.MAX_REC * Constants.PORCENTAJE_INICIAL;
    }

    public void AddToFelicidad(double x)
    {
        _felicidad += x;        
    }
    public void AddToEcosistema(double x)
    {
        _ecosistema += x;
    }
    public void AddToFauna(double x)
    {
        _fauna += x;
    }
    public void AddToDinero(int x)
    {
        _dinero += x;
    }
    public bool CheckIfGameOver()
    {
        return _dinero >0 && _ecosistema >0 && _fauna > 0 && _felicidad > 0;
    }
}
