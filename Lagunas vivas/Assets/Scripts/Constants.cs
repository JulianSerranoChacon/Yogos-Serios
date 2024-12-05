using System;

public class Constants
{
    //La constante que guarda el máximo valor que puede tomar cualquiera de los recursos
    public const double MAX_REC = 100;
    //La constante que guarda el dinero con el que empieza el jugador. Podemos cambiarlo a una variable si queremos que esta varíe según la dificultad
    public const int DINERO_INICIAL = 150;
    //La constante por la que se multiplica los recursos para inicializarlos
    public const float PORCENTAJE_INICIAL = 0.6f;
    //Constante que guarda la dirección al archivo para leer todos los eventos
    public const string EVENT_DIR = "/Eventos/";
    //COnstante que guarde el número máximo de opciones que puede tener un evento
    public const int MAX_OPT = 4;

    //la constante indica cuando el dinero en la UI debe de estar de color verde
    public const float BIEN_DE_DINERO = 30;


    //Sistema turnos
    public const int NUM_TURNOS_PARA_FIN = 10;


    //Eventos
    public const int NUM_EVENTOS = 2;
    public enum EVENTOS_ENUM { LISTAPRUEBA, FIESTA, BALONMANO, REPARACIONES_POSITIVO};

    public static string[] EVENTOS = new string[]{ "ListaEventos" +
        "", "Fiesta", "Balonmano", "ReparacionesResultadoPositivo" };

}
