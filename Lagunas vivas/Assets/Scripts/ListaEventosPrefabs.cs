using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaEventosPrefabs : MonoBehaviour
{
    [Header("Laguna Grande")]
    [SerializeField] public int MaxEventosGrande;
    [SerializeField] public Constants.EVENTOS_ENUM[] NumEvGrande;
    [SerializeField] public Sprite[] numSpriteGrande;
    [SerializeField] public float[] posXGrande;
    [SerializeField] public float[] posYGrande;
    
    [Header("Laguna Chica")]
    [SerializeField] public int MaxEventosChica; 
    [SerializeField] public Constants.EVENTOS_ENUM[] NumEvChica;
    [SerializeField] public Sprite[] numSpriteChica;
    [SerializeField] public float[] posXChica;
    [SerializeField] public float[] posYChica;
    
    [Header("Laguna de la Sal")]
    [SerializeField] public int MaxEventosSal;
    [SerializeField] public Constants.EVENTOS_ENUM[] NumEvSal;
    [SerializeField] public Sprite[] numSpriteSal;
    [SerializeField] public float[] posXSal;
    [SerializeField] public float[] posYSal;



}
