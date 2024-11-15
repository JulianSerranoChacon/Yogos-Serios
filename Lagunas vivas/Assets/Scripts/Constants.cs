using System;

public class Constants
{
    //La constante que guarda el m�ximo valor que puede tomar cualquiera de los recursos
    public const double MAX_REC = 100;
    //la constante indica el valor maximo que puede tener el dinero.
    public const float MAX_DINERO = 500;
    //La constante que guarda el dinero con el que empieza el jugador. Podemos cambiarlo a una variable si queremos que esta var�e seg�n la dificultad
    public const int DINERO_INICIAL = 150;
    //La constante por la que se multiplica los recursos para inicializarlos
    public const float PORCENTAJE_INICIAL = 0.6f;
    //Constante que guarda la direcci�n al archivo para leer todos los eventos
    public const string EVENT_DIR = "/Eventos/";
    //COnstante que guarde el n�mero m�ximo de opciones que puede tener un evento
    public const int MAX_OPT = 4;

    //Eventos
    public const int NUM_EVENTOS = 2;
    public enum EVENTOS_ENUM { LISTAPRUEBA, FIESTA};

    public static string[] EVENTOS = new string[]{ "ListaEventos" +
        "", "Fiesta" };

}
