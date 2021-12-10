using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectSpawnChance : MonoBehaviour
{
    #region Variables
    public int spawnChance;
    public GameObject go;
    #endregion

    #region Monobehavior
    void Start()
    {
        go = this.gameObject;
        int randomNum = Random.Range(0, 10);
        if (randomNum <= spawnChance)
        {
            go.SetActive(true);
        }
        else go.SetActive(false);
    }
    #endregion
}
