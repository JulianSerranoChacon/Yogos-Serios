using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] TMP_Text TMPro ;
    [SerializeField] GameObject recuadroDeTexto;
    [SerializeField] private float typingTime = Constants.VELOCIDAD_DE_ESCRITURA;
    private string [] _dialogos;
    private int dialogoIndex;
    private bool inDialogue;

    public bool getDialogue()
    {
        return inDialogue;
    }

    public void startDialogue(string[] dialogos)
    {
        _dialogos = dialogos;
        if(_dialogos.Length == 0)
            return;
        recuadroDeTexto.SetActive(true);
        inDialogue = true;
        dialogoIndex = 0;
        if (_dialogos.Length > 0)
            StartCoroutine(Showline());
    }

    private void endDialogue()
    {
        recuadroDeTexto.SetActive(false);
        inDialogue=false;
    }

    public void saltaDialogo()
    {
        StopAllCoroutines();
        TMPro.text = _dialogos[dialogoIndex];
    }

    public void nextLine()
    {
        if(TMPro.text != _dialogos[dialogoIndex])
        {
            saltaDialogo();
            return;
        }


        dialogoIndex++;
        if( dialogoIndex < _dialogos.Length )
            StartCoroutine(Showline());
        else
            endDialogue();
    }

    private IEnumerator Showline()
    {
        TMPro.text = string.Empty;

        foreach(char ch in _dialogos[dialogoIndex])
        {
            TMPro.text += ch;
            yield return new WaitForSeconds(typingTime);
        }
    }
}
