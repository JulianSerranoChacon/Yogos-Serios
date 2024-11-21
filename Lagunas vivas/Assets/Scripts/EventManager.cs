using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;
using UGUIImage = UnityEngine.UI.Image;

public class EventManager : MonoBehaviour
{
    RecursosManager _recursosManager;
    UIManager _uiManager;
    Evento[] _listaEventos;

    [SerializeField] GameObject EventFrame;
    [SerializeField] GameObject _GOImagen;
    [SerializeField] TMP_Text TextoPrincipal;
    [SerializeField] GameObject[] Opciones;
    [SerializeField] TMP_Text[] TextosOpciones;
    [SerializeField] string evento;
    UGUIImage _imagenPrincipal;

    Evento evActual;
    #region Principio
    void Start()
    {
        GameManager.Instance.AssignEventManager(this);        
        _recursosManager = GameManager.Instance.getResMan();
        _uiManager = GameManager.Instance.getUIManager();
        _imagenPrincipal = _GOImagen.GetComponent<UGUIImage>();
    }

    public void setEvento(string e)
    {
        evento = e;
    }

    private Evento createEvent(StreamReader rd)
    {
        string textoPrincipal = rd.ReadLine();
        rd.ReadLine();
        int NumImagen = int.Parse(rd.ReadLine());
        int numOpciones = int.Parse(rd.ReadLine());
        string[] textOp = new string[numOpciones];
        int[] din = new int[numOpciones];
        double[] eco = new double[numOpciones];
        double[] faun = new double[numOpciones];
        double[] feli = new double[numOpciones];
        bool[] continuar = new bool[numOpciones];

        for (int j = 0; j < numOpciones; j++)
        {
            textOp[j] = rd.ReadLine();
            string aux = rd.ReadLine();
            din[j] = int.Parse(aux);
            aux = rd.ReadLine();
            eco[j] = int.Parse(aux);
            aux = rd.ReadLine();
            faun[j] = int.Parse(aux);
            aux = rd.ReadLine();
            feli[j] = int.Parse(aux);
            aux = rd.ReadLine();
            continuar[j] = (aux == "Cont");

        }
        return new Evento(textoPrincipal, NumImagen, numOpciones, textOp, din, eco, faun, feli, continuar);
    }
    //Método que lee del archivo de texto donde están todos los eventos y crea una lista con todos ellos
    public void getEventos()
    {
        string file = Application.dataPath + Constants.EVENT_DIR + evento + ".txt"; 

        StreamReader rd = new StreamReader(file);
        if (File.Exists(file))
        {
            string aux;
            aux = rd.ReadLine();
            switch (aux){
                case "r":
                    {
                        int numEventos = int.Parse(rd.ReadLine());
                        _listaEventos = new Evento[numEventos];
                        for (int i = 0; i < numEventos; i++)
                        {
                            _listaEventos[i] = createEvent(rd);
                        }
                        break;
                    }
                case "s":
                    {
                        int numEventos = int.Parse(rd.ReadLine());
                        _listaEventos = new Evento[1];
                        _listaEventos[0] = createEvent(rd);
                        Evento ev = _listaEventos[0];
                        for (int i = 1; i < numEventos; i++)
                        {                            
                            ev.addNextEv(createEvent(rd));
                            ev = ev.getNextEv();
                        }
                        break;
                    }
                default:                    
                    break;
            }

        }
        else
            Debug.Log("no existe el evento");
        rd.Close();        
    }
    #endregion
    //Método mediante el que elige un evento aleatorio de los que tiene en su lista de eventos
    Evento PickRandEvent()
    {
        int aux= Random.Range(0, _listaEventos.Length);
        return _listaEventos[aux];
    }
    //Void que pilla un nuevo evento y lo renderiza
    public void NewEvent(Evento ev = null)
    {
        EventFrame.SetActive(true);
        if(ev == null) evActual = PickRandEvent();
        else evActual = ev;
        TextoPrincipal.text = evActual._textoPrincipal;
        if (evActual._mySprite != -1)
        {
            _imagenPrincipal.sprite = GameManager.Instance.getImageEv(evActual._mySprite);             
        }
        else
        {
            _imagenPrincipal.sprite = null;
        }
        for (int i = 0; i < Constants.MAX_OPT; i++)  //Preparación de botones
        {
            if(i < evActual._numOpciones)   //Si ese botón tiene que estar activo
            {
                Opciones[i].SetActive(true);    //Se muestra
                TextosOpciones[i].text = evActual.opciones[i]._textOpcion;  //Se cambia el texto del botón

            }
            else
            {
                Opciones[i].SetActive(false);   //Se oculta si no
            }
        }

    }
    //Método al que se llama una vez se elige alguna de las opciones
    public void CooseOpcion(int i)
    {        
        _recursosManager = GameManager.Instance.getResMan();
        _uiManager = GameManager.Instance.getUIManager();        
        if (i <= evActual._numOpciones && GameManager.Instance.EnJuego)
        {
            _recursosManager.AddToFelicidad(evActual.opciones[i]._feli);
            _recursosManager.AddToEcosistema(evActual.opciones[i]._eco);
            _recursosManager.AddToFauna(evActual.opciones[i]._faun);
            _recursosManager.AddToDinero(evActual.opciones[i]._din);            
            _uiManager.ActualizarInterfaz();
            //Esto de abajo se deberá cambiar a medida que cambie la UI y todo lo que haga falta
            if (_recursosManager.CheckIfGameOver())
            {
                if(evActual.getNextEv() != null && evActual.opciones[i]._continueNextEv)
                {
                    NewEvent(evActual.getNextEv());
                }
                else {
                    GameManager.Instance.EventFinsihed();
                    EventFrame.SetActive(false);    
                }
            }
            else
            {
                GameManager.Instance.EnJuego = false;
                Debug.Log("HAS PERDIDO");
            }
        }
    }
}