using System;

public class Constants
{
    //La constante que guarda el máximo valor que puede tomar cualquiera de los recursos
    public const double MAX_REC = 100;
    //La constante que guarda el dinero con el que empieza el jugador. Podemos cambiarlo a una variable si queremos que esta varíe según la dificultad
    public const int DINERO_INICIAL = 1150;
    //La constante por la que se multiplica los recursos para inicializarlos
    public const float PORCENTAJE_INICIAL = 0.6f;
    //Constante que guarda la dirección al archivo para leer todos los eventos
    public const string EVENT_DIR = "/Eventos/";
    //COnstante que guarde el número máximo de opciones que puede tener un evento
    public const int MAX_OPT = 4;

    //la constante indica cuando el dinero en la UI debe de estar de color verde
    public const float BIEN_DE_DINERO = 30;

    public const float MAX_POS_XY_EV = 365;    
    public const float MIN_POS_XY_EV = -365;


    //Sistema turnos
    public const int NUM_TURNOS_PARA_FIN = 10;

    //Sistemas de diálogos
    public const float VELOCIDAD_DE_ESCRITURA = 0.5f;


    //Eventos
    public const int NUM_EVENTOS = 25;
    public enum EVENTOS_ENUM { LISTAPRUEBA, FIESTA, BALONMANO, REFORESTACION, REP_SENDERO_POS, REP_SENDERO_NEG, REP_CORTAFUEGOS_POS, REP_CORTAFUEGOS_NEG,
        REP_PUENTE_POS, REP_PUENTE_NEG, INCENDIO_CONT_POS, INCENDIO_CONT_NEG, INCENDIO_CONT_VIENTO_POS, INCENDIO_CONT_VIENTO_NEG, 
        MICROORGANISMOS, CRIA_PAJARO, POZO_ILEGAL, BOTELLON, PASEO_PERROS, MODA_PESCA, EXCURSION, TORTUGA, RATONES, CONEJOS, PECES, CONCIENCIACION, 
        EROSION, AVISPAS, SEQUIA, HONGO, ALGAS};

    public static string[] EVENTOS = new string[]{ "ListaEventos",
        "Fiesta", "Balonmano", "Reforestacion", "RepSendero_positivo","RepSendero_Negativo", "RepCortafuegos_Positivo", "RepCortafuegos_Negativo",
        "RepPuente_Positivo", "RepPuente_Negativo", "IncendioControlado_Positivo","IncendioControlado_Negativo","VientoIncendioControlado_Positivo","VientoIncendioControlado_Negativo",
        "MicroorganismosBajos", "CriaPajaro", "PozoIlegal", "Botellon", "PaseoPerros", "ModaPesca", "Excursion", "Tortuga", "Ratones", "Conejos", "Peces", "Concienciacion", 
        "Erosion", "Avispas", "Sequia", "Hongo", "Algas"};

}
