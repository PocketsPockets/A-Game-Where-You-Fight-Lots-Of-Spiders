using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTriggerZone : MonoBehaviour
{
    bool hasCalled = false;
    public GameObject enemiesToSpawn;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !hasCalled)
        {
            hasCalled = true;
            ActionZone();
        }
    }
    void ActionZone()
    {
        enemiesToSpawn.SetActive(true);
    }
}
