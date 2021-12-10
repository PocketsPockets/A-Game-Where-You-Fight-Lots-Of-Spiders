using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayGame : MonoBehaviour
{
    AudioSource audio;
    PlayGame playGame;
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;
    public AudioClip click;
    void Start()
    {
        audio = GetComponent<AudioSource>();
        playGame = GetComponent<PlayGame>();
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
    }
    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }
    void OnMouseUp()
    {
        audio.clip = click;
        audio.Play();
        SceneManager.LoadScene("M1L1");
    }
}
