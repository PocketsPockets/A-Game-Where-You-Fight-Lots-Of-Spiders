using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderVitals : MonoBehaviour
{
    #region Variables
    public float health;
    public ParticleSystem bloodBurst;
    [SerializeField]
    SpiderSenses spiderSenses;
    #endregion

    #region Custom
    public void TakeDamage(float damage)
    {
        bloodBurst.Play();
        health = health - damage;
        if(!spiderSenses.alerted)
        {
            spiderSenses.alerted = true;
        }
    }
    #endregion
}
