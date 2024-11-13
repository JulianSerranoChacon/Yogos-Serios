using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class EventManager : MonoBehaviour
{
    RecursosManager _recursosManager;
    Evento[] _listaEventos;

    #region Principio
    void Start()
    {
        GameManager.Instance.AssignEventManager(this);
        getEventos();
    }

    //Método que lee del archivo de texto donde están todos los eventos y crea una lista con todos ellos
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
    }
    #endregion
    //Método mediante el que elige un evento aleatorio de los que tiene en su lista de eventos
    Evento PickRandEvent()
    {
        int aux= Random.Range(0, _listaEventos.Length);
        return _listaEventos[aux];
    }

}