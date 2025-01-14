using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TurnosManager : MonoBehaviour
{
    #region recursos
    int TurnoActual;
    int End = 0; //Variable que tiene que llegar a 5 para pasar a la escena final
    #endregion

    #region Prefabs eventos
    [SerializeField] GameObject _pref;
    /*struct ParaPrefab
    {
        public Constants.EVENTOS_ENUM NumEv;
        public float PosX;
        public float PosY;
        public Sprite spr;
        public bool initialized;
    }*/
    int LastBeen;
    //ParaPrefab[,] Lagunas;
    int numGran;
    int numChic;
    int numSal;

    int NumEvLeft;

    int max_bool;

    void ResetPrefabs()
    {
        NumEvLeft = GameManager.Instance.getTurno();    //A cambiar para numero de eventos por turno
        /*
        Lagunas = new ParaPrefab[3, NumEvLeft];        
        numGran = 0;
        numChic = 0;
        numSal = 0;

        bool[,] guia = new bool[3, max_bool];
        int donde = Random.Range(0, 3);
        for (int i = 0; i < NumEvLeft; i++)
        {
            if (donde >= 3) donde = 0;
            GeneratePrefab(donde, guia);
            donde++;
        }
        */
    }
    void GeneratePrefab(int donde, bool[,] guia)
    {
        /*
        int max;
        switch (donde)
        {
            case 0:
                max = GetComponent<ListaEventosPrefabs>().MaxEventosGrande;
                break;
            case 1:
                max = GetComponent<ListaEventosPrefabs>().MaxEventosChica;
                break;
            case 2:
                max = GetComponent<ListaEventosPrefabs>().MaxEventosSal;
                break;
            default:
                max = 0;
                break;
        }
        int ev = Random.Range(0, max);
        if (guia[donde, ev]) GeneratePrefab(donde, guia);
        else
        {
            guia[donde, ev] = true;            
            ListaEventosPrefabs l = GetComponent<ListaEventosPrefabs>();
            switch (donde)
            {
                case 0:
                    Lagunas[donde, numGran].NumEv = l.NumEvGrande[ev];
                    Lagunas[donde, numGran].spr = l.numSpriteGrande[ev];
                    Lagunas[donde, numGran].PosX = Random.Range(Constants.MIN_POS_XY_EV/100.0f, Constants.MAX_POS_XY_EV/100.0f);
                    Lagunas[donde, numGran].PosY = Random.Range(Constants.MIN_POS_XY_EV / 100.0f, Constants.MAX_POS_XY_EV / 100.0f);
                    Lagunas[donde, numGran].initialized = true;
                    numGran++;
                    break;
                case 1:
                    Lagunas[donde, numChic].NumEv = l.NumEvChica[ev];
                    Lagunas[donde, numChic].spr = l.numSpriteChica[ev];
                    Lagunas[donde, numChic].PosX = Random.Range(Constants.MIN_POS_XY_EV / 100.0f, Constants.MAX_POS_XY_EV / 100.0f);
                    Lagunas[donde, numChic].PosY = Random.Range(Constants.MIN_POS_XY_EV / 100.0f, Constants.MAX_POS_XY_EV / 100.0f);
                    Lagunas[donde, numChic].initialized = true;
                    numChic++;
                    break;
                case 2:
                    Lagunas[donde, numSal].NumEv = l.NumEvSal[ev];
                    Lagunas[donde, numSal].spr = l.numSpriteSal[ev];
                    Lagunas[donde, numSal].PosX = Random.Range(Constants.MIN_POS_XY_EV / 100.0f, Constants.MAX_POS_XY_EV / 100.0f);
                    Lagunas[donde, numSal].PosY = Random.Range(Constants.MIN_POS_XY_EV / 100.0f, Constants.MAX_POS_XY_EV / 100.0f);
                    Lagunas[donde, numSal].initialized = true;
                    numSal++;
                    break;
                default:
                    break;
            }
        }*/
    }

    public void Show(int donde)
    {
        /*
        LastBeen = donde;
        int max = 0;
        switch(donde)
        {
            case 0:
                max = numGran;
                break;
            case 1:
                max = numChic;
                break;
            case 2:
                max = numSal;
                break;
            default : break;
        }        
        for(int i = 0; i < max; i++)
        {
            if (Lagunas[donde, i].initialized)
            {                
                GameObject g = Instantiate(_pref, new Vector3(Lagunas[donde, i].PosX, Lagunas[donde, i].PosY, 0), Quaternion.identity);                                
                g.GetComponent<ClickeableObject>().SetEvento(Lagunas[donde, i].NumEv, i);
                g.GetComponent<SpriteRenderer>().sprite = Lagunas[donde, i].spr;
            }            
        }*/
    }

    public void Uncheck(int pos)
    {
        /*
        Lagunas[LastBeen, pos].initialized = false;
        NumEvLeft--;*/
    }
    public bool AllEventsDone()
    {
        return NumEvLeft <= 0;
    }

    public void subEvLeft()
    {
        NumEvLeft -= 1;        
    }
    /*
    public bool LagunaTieneEventos(int donde) // Determina si una laguna tiene eventos
    {
        int max = 0;
        switch (donde)
        {
            case 0: max = numGran; break;
            case 1: max = numChic; break;
            case 2: max = numSal; break;
            default: return false;
        }
        for (int i = 0; i < max; i++)
        {
            if (Lagunas[donde, i].initialized) return true;
        }
        return false;
    }
    */

    #endregion
    private void Start()
    {
        TurnoActual = 0;
        max_bool = GetComponent<ListaEventosPrefabs>().MaxEventosGrande;
        if (max_bool < GetComponent<ListaEventosPrefabs>().MaxEventosChica) max_bool = GetComponent<ListaEventosPrefabs>().MaxEventosChica;
        if (max_bool < GetComponent<ListaEventosPrefabs>().MaxEventosSal) max_bool = GetComponent<ListaEventosPrefabs>().MaxEventosSal;        
    }

    public int GetTurno()
    { 
        return TurnoActual; 
    }

    public void NextTurn()
    {
        //if (TurnoActual == 1) TurnoActual = 9;
        TurnoActual++;

        if(TurnoActual < Constants.NUM_TURNOS_PARA_FIN)
        {           
            ResetPrefabs();
            GameManager.Instance.DrawCards();
        }        
    }
    public void CheckIfVictory()
    {
        if (TurnoActual >= Constants.NUM_TURNOS_PARA_FIN)
        {
            End++;
            if(End >= 5)
            {
                SceneManager.LoadScene(7);
            }
        }
    }
}
