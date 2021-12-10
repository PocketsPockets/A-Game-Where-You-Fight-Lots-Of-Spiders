using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSenses : MonoBehaviour
{
    #region Variables
    Transform player;
    public Transform lineCastStart;
    public float visDistance;
    public float viewAngle;
    public float currentTargetRange;
    public bool targetInView;
    public bool alerted = false;
    bool viewIsBlocked = false;
    bool targetInRange = false;
    #endregion

    #region Monobehavior
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        LineOfSight();
        if (targetInView)
        {
            alerted = true;
        }
    }
    #endregion

    #region Custom
    void LineOfSight()
    {
        Vector3 targetDirection = player.position - this.transform.position;
        currentTargetRange = targetDirection.magnitude;
        float angle = Vector3.Angle(targetDirection, transform.forward);
        if (targetDirection.magnitude < visDistance && angle < viewAngle)
        {
            targetInRange = true;
        }
        else targetInRange = false;

        RaycastHit hit;
        if (Physics.Linecast(lineCastStart.position, player.transform.position, out hit))
        {
            Debug.DrawLine(lineCastStart.position, player.position, Color.yellow);
            if (hit.transform.tag == "Player")
            {
                viewIsBlocked = false;
            }
            else viewIsBlocked = true;
        }
        
        if (targetInRange && !viewIsBlocked)
        {
            targetInView = true;
        }
        else targetInView = false;
    }
    #endregion
}
