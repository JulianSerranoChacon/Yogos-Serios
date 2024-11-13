using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class EventManager : MonoBehaviour
{
    RecursosManager _recursosManager;
    Evento[] _listaEventos;

    [SerializeField] TMP_Text TextoPrincipal;
    [SerializeField] GameObject[] Opciones;
    [SerializeField] TMP_Text[] TextosOpciones;

    Evento evActual;
    #region Principio
    void Start()
    {
        GameManager.Instance.AssignEventManager(this);
        getEventos();
        _recursosManager = GameManager.Instance.getResMan();
    }

    //M�todo que lee del archivo de texto donde est�n todos los eventos y crea una lista con todos ellos
    void getEventos()
    {
        string file = Application.dataPath + Constants.EVENT_DIR;
        StreamReader rd = new StreamReader(file);
        if (File.Exists(file))
        {
            string aux;
            aux = rd.ReadLine();
            int numEventos = int.Parse(aux);
            _listaEventos = new Evento[numEventos];           

            for(int i = 0; i < numEventos; i++)
            {
                string textoPrincipal = rd.ReadLine();
                aux = rd.ReadLine();
                int numOpciones = int.Parse(aux);
                string[] textOp = new string[numOpciones];
                int[] din = new int[numOpciones];
                double[] eco = new double[numOpciones];
                double[] faun = new double[numOpciones];
                double[] feli = new double[numOpciones];

                for(int j = 0; j < numOpciones; j++)
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
        rd.Close();


        NewEvent();
    }
    #endregion
    //M�todo mediante el que elige un evento aleatorio de los que tiene en su lista de eventos
    Evento PickRandEvent()
    {
        int aux= Random.Range(0, _listaEventos.Length);
        return _listaEventos[aux];
    }
    //Void que pilla un nuevo evento y lo renderiza
    public void NewEvent()
    {
        evActual = PickRandEvent();
        TextoPrincipal.text = evActual._textoPrincipal;
        for (int i = 0; i < Constants.MAX_OPT; i++)  //Preparaci�n de botones
        {
            if(i < evActual._numOpciones)   //Si ese bot�n tiene que estar activo
            {
                Opciones[i].SetActive(true);    //Se muestra
                TextosOpciones[i].text = evActual.opciones[i]._textOpcion;  //Se cambia el texto del bot�n

            }
            else
            {
                Opciones[i].SetActive(false);   //Se oculta si no
            }
        }

    }
    //M�todo al que se llama una vez se elige alguna de las opciones
    public void CooseOpcion(int i)
    {
        if(i <= evActual._numOpciones && GameManager.Instance.EnJuego)
        {
            _recursosManager.AddToFelicidad(evActual.opciones[i]._feli);
            _recursosManager.AddToEcosistema(evActual.opciones[i]._eco);
            _recursosManager.AddToFauna(evActual.opciones[i]._faun);
            _recursosManager.AddToDinero(evActual.opciones[i]._din);
            //Esto de abajo se deber� cambiar a medida que cambie la UI y todo lo que haga falta
            if (_recursosManager.CheckIfGameOver())
            {
                _recursosManager.DebugStats();

                GameManager.Instance.GenerateNewEvent();
            }
            else
            {
                GameManager.Instance.EnJuego = false;
                Debug.Log("HAS PERDIDO");
            }
        }
    }
}