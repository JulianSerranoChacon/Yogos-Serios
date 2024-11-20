using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UIElements;

public class EventManager : MonoBehaviour
{
    RecursosManager _recursosManager;
    UIManager _uiManager;
    Evento[] _listaEventos;

    [SerializeField] GameObject EventFrame;
    [SerializeField] TMP_Text TextoPrincipal;
    [SerializeField] GameObject[] Opciones;
    [SerializeField] TMP_Text[] TextosOpciones;
    [SerializeField] string evento;

    Evento evActual;
    #region Principio
    void Start()
    {
        GameManager.Instance.AssignEventManager(this);        
    }

    public void setEvento(string e)
    {
        evento = e;
    }

    //Método que lee del archivo de texto donde están todos los eventos y crea una lista con todos ellos
    public void getEventos()
    {
        _recursosManager = GameManager.Instance.getResMan();
        _uiManager = GameManager.Instance.getUIManager();
        string file = Application.dataPath + Constants.EVENT_DIR + evento + ".txt"; 

        StreamReader rd = new StreamReader(file);
        if (File.Exists(file))
        {
            string aux;
            aux = rd.ReadLine();
            int numEventos = int.Parse(aux);
            _listaEventos = new Evento[numEventos];

            for (int i = 0; i < numEventos; i++)
            {
                string textoPrincipal = rd.ReadLine();
                aux = rd.ReadLine();
                int numOpciones = int.Parse(aux);
                string[] textOp = new string[numOpciones];
                int[] din = new int[numOpciones];
                double[] eco = new double[numOpciones];
                double[] faun = new double[numOpciones];
                double[] feli = new double[numOpciones];

                for (int j = 0; j < numOpciones; j++)
                {
                    textOp[j] = rd.ReadLine();
                    aux = rd.ReadLine();
                    din[j] = int.Parse(aux);
                    aux = rd.ReadLine();
                    eco[j] = int.Parse(aux);
                    aux = rd.ReadLine();
                    faun[j] = int.Parse(aux);
                    aux = rd.ReadLine();
                    feli[j] = int.Parse(aux);
                }

                _listaEventos[i] = new Evento(textoPrincipal, numOpciones, textOp, din, eco, faun, feli);
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
    public void NewEvent()
    {
        EventFrame.SetActive(true);
        evActual = PickRandEvent();
        TextoPrincipal.text = evActual._textoPrincipal;
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
                EventFrame.SetActive(false);                
            }
            else
            {
                GameManager.Instance.EnJuego = false;
                Debug.Log("HAS PERDIDO");
            }
        }
    }
}