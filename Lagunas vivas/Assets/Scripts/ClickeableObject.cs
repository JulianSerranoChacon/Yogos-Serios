using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickeableObject : MonoBehaviour
{
    [SerializeField] int numScene = -1; // -1 si no quieres que cambie de escena sino que sea solo un evento
    [SerializeField] Constants.EVENTOS_ENUM evento;    
    public int posEnArray = -1;    

    public int getNumScene()
    {
        return numScene;
    }

    public void enviaEvento()
    {
        GameManager.Instance.setEvent(Constants.EVENTOS[(int)evento]);        
    }

    public void CreateEvento(Constants.EVENTOS_ENUM ev, float _x, float _y, Sprite im)
    {
        evento = ev;
        GetComponent<Transform>().position = new Vector3(_x, _y, 0);        
        GetComponent<SpriteRenderer>().sprite = im;
    }
    
    public void SetEvento(Constants.EVENTOS_ENUM i, int PosEnArr = -1)
    {
        evento = i;
        if (PosEnArr != -1) posEnArray = PosEnArr;
    }
}
