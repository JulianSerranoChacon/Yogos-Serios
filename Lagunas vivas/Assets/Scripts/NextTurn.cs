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
        GameManager.Instance.GetComponent<TurnosManager>().NextTurn();
        GameManager.Instance.getUIManager().ActualizarInterfaz();
        gameObject.SetActive(false);
    }
}
