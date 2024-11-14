using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickeableObject : MonoBehaviour
{
    [SerializeField] int numScene = -1; // -1 si no quieres que cambie de escena sino que sea solo un evento
    [SerializeField] Constants.EVENTOS_ENUM evento;

    public int getNumScene()
    {
        return numScene;
    }

    public void enviaEvento()
    {
        GameManager.Instance.setEvent(Constants.EVENTOS[(int)evento]);
    }
}
