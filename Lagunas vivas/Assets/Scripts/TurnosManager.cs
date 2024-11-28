using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnosManager : MonoBehaviour
{
    #region recursos
    int TurnoActual;
    #endregion

    #region Prefabs eventos
    [SerializeField] GameObject _pref;
    struct ParaPrefab
    {
        public Constants.EVENTOS_ENUM NumEv;
        public float PosX;
        public float PosY;
        public Sprite spr;
        public bool initialized;
    }
    int LastBeen;
    ParaPrefab[,] Lagunas;
    int numGran;
    int numChic;
    int numSal;

    int NumEvLeft;

    int max_bool;

    void ResetPrefabs()
    {
        NumEvLeft = GameManager.Instance.getTurno()+1;    //A cambiar para numero de eventos por turno
        Lagunas = new ParaPrefab[3, NumEvLeft];        
        numGran = 0;
        numChic = 0;
        numSal = 0;

        bool[,] guia = new bool[3, max_bool];
        int donde = Random.Range(0, 2);
        for (int i = 0; i < NumEvLeft; i++)
        {
            GeneratePrefab(donde, guia);
            donde++;
            if (donde == 3) donde = 0;
        }
    }
    void GeneratePrefab(int donde, bool[,] guia)
    {
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
        if (guia[donde, ev]) GeneratePrefab(ev, guia);
        else
        {
            guia[donde, ev] = true;            
            ListaEventosPrefabs l = GetComponent<ListaEventosPrefabs>();
            switch (donde)
            {
                case 0:
                    Lagunas[donde, numGran].NumEv = l.NumEvGrande[ev];
                    Lagunas[donde, numGran].spr = l.numSpriteGrande[ev];
                    Lagunas[donde, numGran].PosX = l.posXGrande[ev];
                    Lagunas[donde, numGran].PosY = l.posYGrande[ev];
                    Lagunas[donde, numGran].initialized = true;
                    numGran++;
                    break;
                case 1:
                    Lagunas[donde, numChic].NumEv = l.NumEvChica[ev];
                    Lagunas[donde, numChic].spr = l.numSpriteChica[ev];
                    Lagunas[donde, numChic].PosX = l.posXChica[ev];
                    Lagunas[donde, numChic].PosY = l.posYChica[ev];
                    Lagunas[donde, numChic].initialized = true;
                    numChic++;
                    break;
                case 2:
                    Lagunas[donde, numSal].NumEv = l.NumEvSal[ev];
                    Lagunas[donde, numSal].spr = l.numSpriteSal[ev];
                    Lagunas[donde, numSal].PosX = l.posXSal[ev];
                    Lagunas[donde, numSal].PosY = l.posYSal[ev];
                    Lagunas[donde, numSal].initialized = true;
                    numSal++;
                    break;
                default:
                    break;
            }
        }
    }

    public void Show(int donde)
    {
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
        }
    }

    public void Uncheck(int pos)
    {
        Lagunas[LastBeen, pos].initialized = false;
        NumEvLeft--;
    }
    public bool AllEventsDone()
    {
        return NumEvLeft <= 0;
    }

    #endregion
    private void Start()
    {
        TurnoActual = 0;
        max_bool = GetComponent<ListaEventosPrefabs>().MaxEventosGrande;
        if (max_bool < GetComponent<ListaEventosPrefabs>().MaxEventosChica) max_bool = GetComponent<ListaEventosPrefabs>().MaxEventosChica;
        if (max_bool < GetComponent<ListaEventosPrefabs>().MaxEventosSal) max_bool = GetComponent<ListaEventosPrefabs>().MaxEventosSal;
        //NextTurn(); //Esto lo hará el game Manager y todo eso
    }

    public int GetTurno()
    { 
        return TurnoActual; 
    }

    public void NextTurn()
    {
        TurnoActual++;

        if(TurnoActual >= Constants.NUM_TURNOS_PARA_FIN)
        {
            Debug.Log("HAS GANADO :D");
        }
        else
        {
            ResetPrefabs();
        }
    }
}
