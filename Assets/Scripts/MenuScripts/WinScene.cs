using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinScene : MonoBehaviour
{
    AudioSource audio;
    public AudioClip click;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.E))
            {
                audio.clip = click;
                audio.Play();
                SceneManager.LoadScene("MainMenu");
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                audio.clip = click;
                audio.Play();
                Application.Quit();
            }
        }
    }

