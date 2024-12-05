using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class GameOverLoader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;      // texto del final
    [SerializeField] UnityEngine.UI.Image image;    // imagen del final

    //Imagenes de cada final
    [SerializeField] Sprite dineroImage;
    [SerializeField] Sprite ecosistemaImage;
    [SerializeField] Sprite faunaImage;
    [SerializeField] Sprite felicidadImage;
    [SerializeField] Sprite winImage;

    void Start()
    {
        RecursosManager recursosManager = GameManager.Instance.getResMan();
        if (recursosManager.getDinero() <= 0)
        {
            textMesh.text = "Has perdido por falta de dinero.";
            image.sprite = dineroImage;
        }
        else if (recursosManager.getEcosistema() <= 0)
        {
            textMesh.text = "Has perdido por un ecosistema insostenible.";
            image.sprite = ecosistemaImage;
        }
        else if (recursosManager.getFauna() <= 0)
        {
            textMesh.text = "Has perdido por el colapso de la fauna.";
            image.sprite = faunaImage;
        }
        else if (recursosManager.getFelicidad() <= 0)
        {
            textMesh.text = "Has perdido por falta de felicidad.";
            image.sprite = felicidadImage;
        }
        else
        {
            textMesh.text = "¡HAS GANADO!";
            image.sprite = winImage;
        }
    }
}
