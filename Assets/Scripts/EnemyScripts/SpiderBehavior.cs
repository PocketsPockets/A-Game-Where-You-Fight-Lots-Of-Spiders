using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SpiderBehavior : MonoBehaviour
{
    #region Variables
    NavMeshAgent nav;
    Transform player;
    Animator animator;
    SpiderSenses spiderSenses;
    SpiderVitals spiderVitals;
    [SerializeField]
    float velX;
    float velY;
    bool aggro;
    bool isWander;
    bool isAttack;
    public bool isBigSpider;
    public bool isEating;
    public Transform[] wanderPoints;
    public GameObject spiderFangHitBox;
    public GameObject deathBurst;
    public float attackRange;
    #endregion

    #region Monobehavior

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
        spiderSenses = GetComponent<SpiderSenses>();
        spiderVitals = GetComponent<SpiderVitals>();
    }
    void LateUpdate()
    {
        AnimatorHandler();
        velX = nav.destination.x;
        velY = nav.destination.y;
        if(spiderVitals.health <= 0f)
        {
            Dead();
        }
        if (spiderSenses.alerted)
        {
            aggro = true;
            isWander = false;
            isEating = false;
            ChasePlayer();
        }
        else Wander();

        if (spiderSenses.currentTargetRange <= attackRange)
        {
            isAttack = true;
        }
        else isAttack = false;

        if (nav.isOnOffMeshLink)
        {
            nav.speed = 5f;
        }
        else nav.speed = 0.1f;
    }

    #endregion

    #region Behavior States
    void Wander()
    {
        if(isBigSpider)
        {
            return;
        }
        //isWander = true;
        //nav.SetDestination(wanderPoints[Random.Range(0, 4)].position);
    }
    void ChasePlayer()
    {
        nav.SetDestination(player.position);
        Vector3 playerPosition = new Vector3(player.transform.position.x,
                                                 transform.position.y,
                                                  player.transform.position.z);
        if (spiderSenses.currentTargetRange < 2.0f)
        {
            transform.LookAt(playerPosition);
        }
    }
    void Dead()
    {
        var death = (GameObject)Instantiate(deathBurst,
            this.transform.position,
            this.transform.rotation);
        Destroy(gameObject);
    }

    #endregion

    #region Other
    void AnimatorHandler()
    {
        //nav.speed = (animator.deltaPosition / Time.deltaTime).magnitude / 3f;
        animator.SetBool("Aggro", aggro);
        animator.SetBool("IsWander", isWander);
        animator.SetBool("IsAttack", isAttack);
        animator.SetBool("IsEating", isEating);
        animator.SetFloat("CurrentTargetRange", spiderSenses.currentTargetRange);
        animator.SetFloat("velX", velX);
        animator.SetFloat("velY", velY);
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            spiderFangHitBox.SetActive(true);
        }
        else spiderFangHitBox.SetActive(false);
    }
    #endregion
}
