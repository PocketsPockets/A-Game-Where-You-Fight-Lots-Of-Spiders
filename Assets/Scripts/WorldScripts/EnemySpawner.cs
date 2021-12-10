using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region Variables
    AudioSource audio;
    bool canSwarm = true;
    float swarmTimer;
    public AudioClip swarmMusic;
    public GameObject[] spiderPool;
    public GameObject[] spawnPositions;
    public GameObject[] desiredConfig;
    public GameObject[] swarmPrefabs;
    public GameObject fastSpider;
    public GameObject bigSpider;
    public GameObject spawnTrigger;
    public int desiredPoolSize;
    float randomSwarmChance;
    #endregion

    #region MonoBehavior
    void Start()
    {
        audio = GetComponent<AudioSource>();
        desiredConfig[Random.Range(0, 4)].SetActive(true);
        spawnPositions = GameObject.FindGameObjectsWithTag("SpawnPosition");
        SpiderPoolInitialize(desiredPoolSize);
        SetSpiderPosition();
        EnableSpider();
        randomSwarmChance = Random.Range(30f, 120f);
    }

    void Update()
    {
        swarmTimer += Time.deltaTime * 1.0f;
        if (swarmTimer > randomSwarmChance && canSwarm)
        {
            swarmTimer = 0f;
            canSwarm = false;
            SpawnSwarm();
        }
    }
    #endregion

    #region Class Methods
    void SpiderPoolInitialize(int poolSize)
    {
        int randomNum;
        for (int i = 0; i < poolSize; i++)
        {
            randomNum = Random.Range(1, 11);

            if (randomNum == 1)
            {
                spiderPool[i] = GameObject.Instantiate(bigSpider);
            }
            else spiderPool[i] = GameObject.Instantiate(fastSpider);

            spiderPool[i].SetActive(false);
        }
    }
    //Set the spider position based on the config position with a random y-axis rotation
    void SetSpiderPosition()
    {
        for (int i = 0; i < desiredPoolSize; i++)
        {
            spiderPool[i].transform.position = spawnPositions[i].transform.position;
            spiderPool[i].transform.rotation = Quaternion.Euler(0, Random.Range(0f, 180f), 0);
        }
    }

    void EnableSpider()
    {
        for (int i = 0; i < desiredPoolSize; i++)
        {
            spiderPool[i].SetActive(true);
        }
    }

    void SpawnSwarm()
    {
        swarmPrefabs[0].SetActive(true);
        swarmPrefabs[1].SetActive(true);
        audio.clip = swarmMusic;
        audio.Play();
    }
    #endregion
}
