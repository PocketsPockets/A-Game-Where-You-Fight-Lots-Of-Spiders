using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleCombat : MonoBehaviour
{
    #region Variables
    Animator animator;
    bool isFiring;
    bool isReloading;
    bool isInReload;
    float damage;
    float fireTimer;
    public AudioClip gunShot;
    public AudioClip reload;
    public AudioClip weaponDraw;
    public float[] damageRange;
    public float fireRate;
    public int magSize;
    public float range;
    public float impactForce;
    public Camera camera;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;
    AudioSource audio;
    #endregion

    #region Monobehavior
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        audio.clip = weaponDraw;
        audio.Play();
    }

    void OnEnable()
    {
        audio.clip = weaponDraw;
        audio.Play();
    }

    void Update()
    {
        AnimationHandler();
        if (Input.GetKey(KeyCode.Mouse0) && magSize > 0 && Time.time > fireTimer && !isInReload)
        {
            isFiring = true;
            fireTimer = Time.time + 1f / fireRate;
            Fire();
        }
        else isFiring = false;
        if (Input.GetKeyDown(KeyCode.Mouse0) && magSize == 0 || Input.GetKeyDown(KeyCode.R) && magSize < 40)
        {
            Reload();
        }
    }
    #endregion

    #region Custom
    void Fire()
    {
        muzzleFlash.Play();
        damage = Random.Range(damageRange[0], damageRange[1]);
        RaycastHit hit;
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            SpiderVitals sV = hit.transform.GetComponent<SpiderVitals>();
            if (sV != null)
            {
                sV.TakeDamage(damage);
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
        magSize--;
        audio.clip = gunShot;
        audio.Play();
    }

    void Reload()
    {
        isReloading = true;
        audio.clip = reload;
        audio.Play();
    }

    void AnimationHandler()
    {
        animator.SetBool("IsFiring", isFiring);
        animator.SetBool("IsReloading", isReloading);
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Reload"))
        {
            magSize = 40;
            isInReload = true;
            isFiring = false;
            isReloading = false;
        }
        else isInReload = false;
    }
    #endregion
}
