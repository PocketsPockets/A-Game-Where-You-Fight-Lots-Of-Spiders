using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GibsBehavior : MonoBehaviour
{
    #region Variables
    Rigidbody rb;
    public float[] forceAmount;
    public float radius;
    #endregion

    #region Monobehavior
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddExplosionForce(Random.Range(forceAmount[0], forceAmount[1]), this.transform.position, radius);
    }
    #endregion
}
