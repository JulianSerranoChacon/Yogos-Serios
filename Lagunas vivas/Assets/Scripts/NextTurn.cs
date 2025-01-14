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

        GameManager gM = GameManager.Instance;
        gM.GetComponent<TurnosManager>().NextTurn();
        gameObject.SetActive(false);
        UIManager uIManager = gM.getUIManager();
        uIManager.ActualizarInterfaz();
        uIManager.chooseCharacter(1);
        uIManager.addDialogue(gM.getTurno());
        if(gM.getTurno()%2 == 0)
        {
            uIManager.addDialogue(gM.getRecursoDialogue("Felicidad"));
            uIManager.addDialogue(gM.getRecursoDialogue("Fauna"));
            uIManager.addDialogue(gM.getRecursoDialogue("Dinero"));
            uIManager.addDialogue(gM.getRecursoDialogue("Ecosistema"));

        }
    }
}
