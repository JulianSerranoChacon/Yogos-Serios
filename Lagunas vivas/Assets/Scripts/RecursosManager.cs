using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecursosManager : MonoBehaviour
{
    #region constantes
    const double MAX_REC = 100; //La constante que guarda el máximo valor que puede tomar cualquiera de los recursos
    const int DINERO_INICIAL = 150; //La constante que guarda el dinero con el que empieza el jugador. Podemos cambiarlo a una variable si queremos que esta varíe según la dificultad
    const float PORCENTAJE_INICIAL = 0.6f; //La constante por la que se multiplica los recursos para inicializarlos
    #endregion
    #region variables
    //Cantidad de dinero
    int _dinero;
    //Los recursos que irán manejados mediante barras
    double _felicidad;
    double _ecosistema;
    double _fauna;
    #endregion

    //Método al que se llama para inicializar los recursos
    public void init()
    {
        _dinero = DINERO_INICIAL;
        _felicidad = MAX_REC * PORCENTAJE_INICIAL;
        _ecosistema = MAX_REC * PORCENTAJE_INICIAL;
        _fauna = MAX_REC * PORCENTAJE_INICIAL;
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
