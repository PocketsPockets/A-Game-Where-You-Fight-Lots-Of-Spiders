using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCredits : MonoBehaviour
{
    AudioSource audio;
    PlayGame playGame;
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;
    public AudioClip click;
    public GameObject CreditsGO;
    public GameObject mainMenuGO;
    public GameObject backGO;
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
        CreditsGO.SetActive(true);
        mainMenuGO.SetActive(false);
        backGO.SetActive(true);
    }
}
