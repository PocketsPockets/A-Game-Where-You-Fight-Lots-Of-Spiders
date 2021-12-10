using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWallSpiders : MonoBehaviour
{
    #region Variables
    public int poolSize;
    public GameObject[] wallSpiders;
    #endregion

    #region MonoBehavior
    void Start()
    {
        EnableSpiders(poolSize);
    }
    #endregion

    #region Class Methods
    void EnableSpiders(int size)
    {
        for (int i = 0; i < size; i++)
        {
            wallSpiders[i].SetActive(true);
        }
    }
    #endregion
}
