using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerAdditionals : MonoBehaviour
{
    #region Variables
    bool flashLightOn = true;
    AudioSource audio;
    public AudioClip flashLightSwitch;
    [SerializeField]
    GameObject flashlightObj;
    #endregion

    #region Monobehavior
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        FLashlightToggle();
    }
    #endregion

    #region Other
    void FLashlightToggle()
    {
        if (Input.GetKeyDown(KeyCode.F) && flashLightOn)
        {
            flashLightOn = false;
            flashlightObj.SetActive(false);
            audio.clip = flashLightSwitch;
            audio.Play();
        }else if(Input.GetKeyDown(KeyCode.F) && !flashLightOn)
        {
            flashLightOn = true;
            flashlightObj.SetActive(true);
            audio.clip = flashLightSwitch;
            audio.Play();
        }
    }
    #endregion
}
