using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSoundController : MonoBehaviour
{
    #region Variables
    AudioSource audio;
    Animator animator;
    public AudioClip spiderScurry;
    public AudioClip spiderAttack;
    public bool[] isPlaying;
    #endregion

    #region Monobehavior
    void Start()
    {
        audio = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        SoundController();
    }
    #endregion

    #region Other
    void SoundController()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            if(!isPlaying[1])
            {
                isPlaying[0] = false;
                isPlaying[1] = true;
                audio.clip = spiderAttack;
                audio.Play();
            }
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Chase"))
        {
            if (!isPlaying[0])
            {
                isPlaying[0] = true;
                isPlaying[1] = false;
                audio.loop = true;
                audio.clip = spiderScurry;
                audio.Play();
            }
        }
    }
    #endregion
}
