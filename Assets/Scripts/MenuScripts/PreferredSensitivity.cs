using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferredSensitivity : MonoBehaviour
{
    public float preferredMouseLookSensitivity = 5f;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
