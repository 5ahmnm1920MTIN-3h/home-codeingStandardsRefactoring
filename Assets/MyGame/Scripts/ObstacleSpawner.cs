﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner instance;
    public GameObject[] obstacles;
    public bool isisGameOver = false;
    public float minSpawnTime, maxSpawnTime;
    const string coroutineSpawmKeyword = "Spawn";
    const float defaultWaitTime = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(coroutineSpawmKeyword);
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator Spawn()
    {
        float waitTime = defaultWaitTime;
        yield return new WaitForSeconds (waitTime);

        while (!isGameOver)
        {
            SpawnObstacle();
        
            waitTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void SpawnObstacle()
    {
        int randomPosition = Random.Range(0,obstacles.Length);
        Instantiate(obstacles[random],transform.position,Quaternion.identity);
    }
}
