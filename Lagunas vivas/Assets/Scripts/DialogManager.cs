using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] TMP_Text TMPro ;
    [SerializeField] GameObject recuadroDeTexto;
    [SerializeField] private float typingTime = 0.05f;
    [SerializeField, TextArea(4, 6)] private string [] dialogos;
    private int dialogoIndex;

    private bool inDialogue;

    public bool getDialogue()
    {
        return inDialogue;
    }

    public void startDialogue()
    {
        recuadroDeTexto.SetActive(true);
        inDialogue = true;
        dialogoIndex = 0;
        if (dialogos.Length > 0)
            StartCoroutine(Showline());
    }

    private void endDialogue()
    {
        recuadroDeTexto.SetActive(false);
        inDialogue=false;
    }

    public void nextLine()
    {
        dialogoIndex++;
        if( dialogoIndex < dialogos.Length )
            StartCoroutine(Showline());
        else
            endDialogue();
    }

    private IEnumerator Showline()
    {
        TMPro.text = string.Empty;

        foreach(char ch in dialogos[dialogoIndex])
        {
            TMPro.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }
}