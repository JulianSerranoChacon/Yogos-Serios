using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaImagenes : MonoBehaviour
{
    [SerializeField] Sprite[] _listImages;
    [SerializeField] Sprite[] _listIconos;

    public Sprite getImage(int i)
    {
        return _listImages[i];
    }

    public Sprite getIcono(int i)
    {
        return _listIconos[i];
    }
}
