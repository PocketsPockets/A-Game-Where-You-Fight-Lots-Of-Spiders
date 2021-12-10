using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlackWidowBehavior : MonoBehaviour
{
    #region Variables
    NavMeshAgent nav;
    Transform player;
    [SerializeField]
    Animator animator;
    SpiderSenses spiderSenses;
    SpiderVitals spiderVitals;
    AudioSource audio;
    public bool aggro;
    public bool isAttack;
    bool dead;
    bool isPlayingAttackSong;
    bool isPlayingDeathSong;
    //Once this meter reaches 50, aggro will become true
    float aggroMeter;
    public GameObject spiderFangHitBox;
    public Collider boxCollider;
    public AudioClip blackWidowAggro;
    public AudioClip blackWidowDeath;
    public float attackRange;
    public float moveSpeed;
    //If the player is within this range the aggro meter will build
    public float aggroMeterRange;
    //If players gets this close they will automatically aggro, regardless of aggro meter
    public float autoAggroRange;
    public float desiredMoveSpeed = 4f;
    #endregion

    #region Monobehavior
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        spiderSenses = GetComponent<SpiderSenses>();
        spiderVitals = GetComponent<SpiderVitals>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        AnimationHandler();
        nav.speed = moveSpeed;
        if (aggro)
        {
            ChasePlayer();
        }
        else Idle();
        if(spiderSenses.alerted || spiderSenses.currentTargetRange <= autoAggroRange)
        {
            aggro = true;
        }
        if (spiderSenses.currentTargetRange <= attackRange)
        {
            isAttack = true;
        }
        else isAttack = false;
        if (spiderVitals.health <= 0f)
        {
            Dead();
        }
    }
    #endregion

    #region Behavior States
    void Idle()
    {
        return;
    }

    void ChasePlayer()
    {
        if(dead)
        {
            return;
        }
        nav.SetDestination(player.position);
        Vector3 playerPosition = new Vector3(player.transform.position.x,
                                                 transform.position.y,
                                                  player.transform.position.z);
        if (spiderSenses.currentTargetRange < 2.0f)
        {
            transform.LookAt(playerPosition);
        }

        if(!isPlayingAttackSong)
        {
            audio.clip = blackWidowAggro;
            audio.Play();
            isPlayingAttackSong = true;
        }
    }

    void Dead()
    {
        dead = true;
        nav.enabled = false;
        spiderFangHitBox.SetActive(false);
        isAttack = false;
        boxCollider.enabled = false;
        if(!isPlayingDeathSong)
        {
            audio.clip = blackWidowDeath;
            audio.Play();
            isPlayingDeathSong = true;
        }
        Destroy(gameObject, 8f);
    }
    #endregion

    #region Custom
    void AnimationHandler()
    {
        animator.SetBool("Aggro", aggro);
        animator.SetBool("IsAttack", isAttack);
        animator.SetBool("Dead", dead);
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            spiderFangHitBox.SetActive(true);
            moveSpeed = 0;
        }
        else
        {
            spiderFangHitBox.SetActive(false);
            moveSpeed = desiredMoveSpeed;
        }
    }
    #endregion
}
