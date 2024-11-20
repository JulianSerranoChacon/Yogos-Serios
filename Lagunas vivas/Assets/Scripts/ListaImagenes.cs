using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListaImagenes : MonoBehaviour
{
    [SerializeField] Sprite[] _listImages;

    public Sprite getImage(int i)
    {
        return _listImages[i];
    }
}
