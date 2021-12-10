using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackToMainMenu : MonoBehaviour
{
    MeshRenderer meshRenderer;
    BoxCollider boxCollider;
    AudioSource audio;
    public AudioClip click;
    public GameObject mainMenuGO;
    public GameObject[] otherMenusGO;

    void Start()
    {
        audio = GetComponent<AudioSource>();
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
        meshRenderer.enabled = false;
        boxCollider.enabled = false;
        mainMenuGO.SetActive(true);
        otherMenusGO[0].SetActive(false);
        otherMenusGO[1].SetActive(false);
        otherMenusGO[2].SetActive(false);
    }
}
