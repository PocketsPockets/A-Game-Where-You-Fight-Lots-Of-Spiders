using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerVitals : MonoBehaviour
{
    #region Variables
    public bool isInfected = false;
    public bool blackWidowInfection = false;
    public SyringeBehavior syringeBehavior;
    public float health = 100f;
    public Text healthText;
    public AudioSource audio;
    public AudioClip[] painSounds;
    #endregion

    #region Monobehavior
    void Update()
    {
        int healthInt = (int)health;
        healthText.text = "+" + healthInt.ToString();
        if (isInfected)
        {
            Infected();
        }
        if(blackWidowInfection)
        {
            BlackWidowInfected();
        }
        if (syringeBehavior.usedShot)
        {
            isInfected = false;
            blackWidowInfection = false;
        }
        if (!isInfected && !blackWidowInfection)
        {
            healthText.color = Color.black;
        }
        if(health <= 0f)
        {
            Death();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SpiderFangs")
        {
            audio.clip = painSounds[0];
            audio.Play();
            health = health - 1f;
        }
        if (other.gameObject.tag == "SpiderFangsVenom")
        {
            audio.clip = painSounds[0];
            audio.Play();
            health = health - 3f;
            isInfected = true;
        }
        if(other.gameObject.tag == "BlackWidowFangs")
        {
            audio.clip = painSounds[0];
            audio.Play();
            health = health - 5f;
            blackWidowInfection = true;
        }
        if(other.gameObject.tag == "DeathCube")
        {
            health = health - 1000f;
        }
        if(other.gameObject.tag == "LevelTransition")
        {
            SceneManager.LoadScene("M1L2");
        }
        if (other.gameObject.tag == "WinGame")
        {
            SceneManager.LoadScene("WinScene");
        }
    }
    #endregion

    #region Custom
    void Infected()
    {
        health -= 1.0f * Time.deltaTime / 4;
        healthText.color = Color.red;
    }

    void BlackWidowInfected()
    {
        health -= 2.0f * Time.deltaTime / 2;
        healthText.color = Color.red;
    }

    void Death()
    {
        SceneManager.LoadScene("DeathScene");
    }
    #endregion
}
