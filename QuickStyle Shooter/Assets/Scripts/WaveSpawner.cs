using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] float remainingTime = 60; //1 minute for first wave, 2 minutes for second, 3 for third, 4 for fourth
    [SerializeField] int waveNum = 1;
    Timer t;

    public GameObject[] obstaclesTemplate;
    public Transform[] spawnPoints;


    void Start()
    {
        t = FindObjectOfType<Timer>();
        
        WaveOne();
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        if (remainingTime <= 0)
        {
            Debug.Log("End of Wave");
            waveNum++;

            if (waveNum == 2)
            {
                Debug.Log("INSIDE");
                WaveTwo();
            }
            else if (waveNum == 3)
            {
                WaveThree();
            }
            else if (waveNum == 4)
            {
                WaveFour();
            }

        }
    }

    void WaveOne()
    {
        Debug.Log("Wave1 Start");
        remainingTime = 10;
        t.setRemainingTime(remainingTime);

        //Spawn enemies
        for(int i=0; i<10; i++)
        {
            //int randomObstacle = Random.Range(0, obstaclesTemplate.Length);
            int randomHeight = Random.Range(0, spawnPoints.Length);
            Vector2 position = new Vector2(transform.position.x, spawnPoints[randomHeight].position.y);

            Instantiate(obstaclesTemplate[0], position, Quaternion.identity);
        }
    }

    void WaveTwo()
    {
        Debug.Log("Wave2 Start");
        remainingTime = 120;
        t.setRemainingTime(remainingTime);

        //Spawn
        for (int i = 0; i < 20; i++)
        {
            int randomHeight = Random.Range(0, spawnPoints.Length);
            Vector2 position = new Vector2(transform.position.x, spawnPoints[randomHeight].position.y);

            Instantiate(obstaclesTemplate[0], position, Quaternion.identity);
        }
    }
    void WaveThree()
    {
        Debug.Log("Wave3 Start");
        remainingTime = 180;
        t.setRemainingTime(remainingTime);

        //Spawn
        for (int i = 0; i < 20; i++)
        {
            int randomHeight = Random.Range(0, spawnPoints.Length);
            Vector2 position = new Vector2(transform.position.x, spawnPoints[randomHeight].position.y);

            Instantiate(obstaclesTemplate[0], position, Quaternion.identity);
            //Instantiate(obstaclesTemplate[1], position, Quaternion.identity);
        }
    }
    void WaveFour()
    {
        Debug.Log("Wave4 Start");
        remainingTime = 240;
        t.setRemainingTime(remainingTime);

        //Spawn
        for (int i = 0; i < 30; i++)
        {
            int randomHeight = Random.Range(0, spawnPoints.Length);
            Vector2 position = new Vector2(transform.position.x, spawnPoints[randomHeight].position.y);

            Instantiate(obstaclesTemplate[0], position, Quaternion.identity);
            //Instantiate(obstaclesTemplate[1], position, Quaternion.identity);
            //Instantiate(obstaclesTemplate[2], position, Quaternion.identity);
        }

    }
}
