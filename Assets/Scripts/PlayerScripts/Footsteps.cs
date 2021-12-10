using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    #region Variables
    CharacterController player;
    AudioSource audio;
    [SerializeField]
    AudioClip[] footSteps;
    PlayerController playerController;
    Vector3 lastPosition;
    int footStepInterval;
    #endregion

    #region Monobehavior
    void Start()
    {
        player = GetComponent<CharacterController>();
        audio = GetComponent<AudioSource>();
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        float speed = Vector3.Distance(lastPosition, player.transform.position) / Time.deltaTime;
        
        lastPosition = player.transform.position;
        
        if (player.isGrounded && speed > 2f && !audio.isPlaying)
        {
            audio.clip = footSteps[footStepInterval];
            audio.Play();
            if (footStepInterval == 0)
            {
                footStepInterval++;
            }
            else footStepInterval--;
        }
    }
    #endregion
}
