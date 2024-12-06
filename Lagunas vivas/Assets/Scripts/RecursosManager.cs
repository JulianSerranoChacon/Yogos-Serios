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

    //Las variableas que guardan los valores anteriores, solo para 
    double _prevFelicidad;
    double _prevEcosistema;
    double _prevFauna;
    #endregion

    #region getters
    public int getDinero() { return _dinero; }    
    public double getFelicidad() { return _felicidad; }    
    public double getEcosistema() { return _ecosistema; }
    public double getFauna() { return _fauna; }

    public double getPrevFelicidad() 
    { 
        double x = _prevFelicidad;
        _prevFelicidad = _felicidad;
        return x; 
    }
    public double getPrevEcosistema()
    {
        double x = _prevEcosistema;
        _prevEcosistema = _ecosistema;
        return x;
    }
    public double getPrevFauna()
    {
        double x = _prevFauna;
        _prevFauna = _fauna;
        return x;
    }
    #endregion

    void Awake()
    {        
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
        _prevFelicidad = _felicidad;
        _felicidad += x;
        if (_felicidad > Constants.MAX_REC) _felicidad = Constants.MAX_REC;
        if(x>0) GameManager.Instance.getUIManager().SumaFel();
        else if (x < 0) GameManager.Instance.getUIManager().RestaFel();
    }
    public void AddToEcosistema(double x)
    {
        _prevEcosistema = _ecosistema;
        _ecosistema += x;
        if (_ecosistema > Constants.MAX_REC) _ecosistema = Constants.MAX_REC;
        if (x > 0) GameManager.Instance.getUIManager().SumaEco();
        else if(x < 0) GameManager.Instance.getUIManager().RestaEco();
    }
    public void AddToFauna(double x)
    {
        _prevFauna = _fauna;
        _fauna += x;
        if (_fauna > Constants.MAX_REC) _fauna = Constants.MAX_REC;
        if (x > 0) GameManager.Instance.getUIManager().SumaFau();
        else if (x < 0) GameManager.Instance.getUIManager().RestaFau();
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
