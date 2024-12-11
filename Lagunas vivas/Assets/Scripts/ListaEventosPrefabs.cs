using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaEventosPrefabs : MonoBehaviour
{
    [Header("Laguna Grande")]
    [SerializeField] public int MaxEventosGrande;
    [SerializeField] public Constants.EVENTOS_ENUM[] NumEvGrande;
    [SerializeField] public Sprite[] numSpriteGrande;
    
    [Header("Laguna Chica")]
    [SerializeField] public int MaxEventosChica; 
    [SerializeField] public Constants.EVENTOS_ENUM[] NumEvChica;
    [SerializeField] public Sprite[] numSpriteChica;    
    
    [Header("Laguna de la Sal")]
    [SerializeField] public int MaxEventosSal;
    [SerializeField] public Constants.EVENTOS_ENUM[] NumEvSal;
    [SerializeField] public Sprite[] numSpriteSal;    



}
