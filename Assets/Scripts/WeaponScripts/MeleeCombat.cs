using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    #region Variables
    Animator animator;
    AudioSource audio;
    bool isAttack;
    float damage;
    float attackTimer;
    public AudioClip swing;
    public AudioClip swingHit;
    public AudioClip axeDraw;
    public float[] damageRange;
    public float fireRate;
    public float range;
    public float impactForce;
    public Camera camera;
    public GameObject impactEffect;
    #endregion

    #region Monobehavior
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        audio.clip = axeDraw;
        audio.Play();
    }

    void OnEnable()
    {
        audio.clip = axeDraw;
        audio.Play();
    }

    void Update()
    {
        AnimationHandler();
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > attackTimer)
        {
            isAttack = true;
            attackTimer = Time.time + 1f / fireRate;
            audio.clip = swing;
            audio.Play();
            Attack();
        }
    }
    #endregion

    #region Custom
    void Attack()
    {
        damage = Random.Range(damageRange[0], damageRange[1]);
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            SpiderVitals sV = hit.transform.GetComponent<SpiderVitals>();
            if (sV != null)
            {
                sV.TakeDamage(damage);
            }
            if(sV == null)
            {
                audio.clip = swingHit;
                audio.Play();
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }
            if (hit.rigidbody == null && sV == null)
            {
                Vector3 offSetPoint = Vector3.Lerp(hit.point, camera.transform.position, 0.005f);
                GameObject impact = Instantiate(impactEffect, offSetPoint, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 2.0f);
            }
        }
    }

    void AnimationHandler()
    {
        animator.SetBool("IsAttack", isAttack);
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            isAttack = false;
        }
    }
    #endregion
}

