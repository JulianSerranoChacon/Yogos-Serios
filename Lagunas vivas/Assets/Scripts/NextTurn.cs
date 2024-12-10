using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTurn : MonoBehaviour
{
    void Start()
    {
        gameObject.SetActive(GameManager.Instance.GetComponent<TurnosManager>().AllEventsDone());
    }

    public void Next()
    {

        if (GameManager.Instance.getUIManager().getInDialgue())
            return;

        GameManager.Instance.GetComponent<TurnosManager>().NextTurn();
        gameObject.SetActive(false);
        UIManager uIManager = GameManager.Instance.getUIManager();
        uIManager.ActualizarInterfaz();
        uIManager.startDialogue(GameManager.Instance.getTurno());
    }
}
