using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAfterSeconds : MonoBehaviour
{
    float timer;
    public GameObject go;

    void Start()
    {
        go.SetActive(true);
    }
}
