using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringeBehavior : MonoBehaviour
{
    #region Variables
    //has the player used the shot
    Animator animator;
    AudioSource audio;
    public AudioClip takeShot;
    public ItemManager itemManager;
    public bool usedShot = false;
    bool fireShot;
    #endregion

    #region Monobehavior
    void Start()
    {
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        animator.SetBool("FireShot", fireShot);
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            audio.clip = takeShot;
            audio.Play();
            fireShot = true;
        }
        if(animator.GetCurrentAnimatorStateInfo(0).IsTag("UsingShot"))
        {
            usedShot = true;
            itemManager.hasSyringe = false;
            itemManager.primaryWeaponOnHand.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
    #endregion
}
