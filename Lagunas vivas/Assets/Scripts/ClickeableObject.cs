using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickeableObject : MonoBehaviour
{
    [SerializeField] Constants.EVENTOS_ENUM evento;

    public void enviaEvento()
    {
        GameManager.Instance.setEvent(Constants.EVENTOS[(int)evento]);
    }
}
