using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyItself : MonoBehaviour
{
    //Time in seconds to wait until destroying object
    public float timeToDestroy;
    void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }
}
