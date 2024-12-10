using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{
    [Header("DialogoInicial")]
    [SerializeField, TextArea(4, 6)] public string[] dialogoInicial;

    [Header("Dialogos por semanas")]
    [SerializeField, TextArea(4, 6)] public string[] semana1;
    [SerializeField, TextArea(4, 6)] public string[] semana2;
    [SerializeField, TextArea(4, 6)] public string[] semana3;
    [SerializeField, TextArea(4, 6)] public string[] semana4;
    [SerializeField, TextArea(4, 6)] public string[] semana5;
    [SerializeField, TextArea(4, 6)] public string[] semana6;
    [SerializeField, TextArea(4, 6)] public string[] semana7;
    [SerializeField, TextArea(4, 6)] public string[] semana8;
    [SerializeField, TextArea(4, 6)] public string[] semana9;
    [SerializeField, TextArea(4, 6)] public string[] semana10;

    [Header("Dialogos para la felicidad")]
    [SerializeField, TextArea(4, 6)] public string[] pocoFe;
    [SerializeField, TextArea(4, 6)] public string[] bastanteFe;
    [SerializeField, TextArea(4, 6)] public string[] muchoFe;

    [Header("Dialogos para el dinero")]
    [SerializeField, TextArea(4, 6)] public string[] pocoD;
    [SerializeField, TextArea(4, 6)] public string[] bastanteD;
    [SerializeField, TextArea(4, 6)] public string[] muchoD;

    [Header("Dialogos para la fauna")]
    [SerializeField, TextArea(4, 6)] public string[] pocoFa;
    [SerializeField, TextArea(4, 6)] public string[] bastanteFa;
    [SerializeField, TextArea(4, 6)] public string[] muchoFa;

    [Header("Dialogos para el ecosistema")]
    [SerializeField, TextArea(4, 6)] public string[] pocoE;
    [SerializeField, TextArea(4, 6)] public string[] bastanteE;
    [SerializeField, TextArea(4, 6)] public string[] muchoE;
}
