using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickeableObject : MonoBehaviour
{
    [SerializeField] int numScene = -1; // -1 si no quieres que cambie de escena sino que sea solo un evento

    public int getNumScene()
    {
        return numScene;
    }
}
