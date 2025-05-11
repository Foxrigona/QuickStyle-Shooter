using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] float remainingTime = 60; //1 minute for first wave, 2 minutes for second, 3 for third, 4 for fourth
    [SerializeField] int waveNum = 1;
    Timer t;
    WaveSpawner ws;

    [SerializeField] float CooldownTime = 10f;

    public GameObject[] obstaclesTemplate;
    public Transform[] spawnPoints;
    public AudioSource spawn;

    void Start()
    {
        t = FindObjectOfType<Timer>();
        ws = FindObjectOfType<WaveSpawner>();

        WaveOne();
    }
    
    private IEnumerator delay(float cool)
    {
        yield return new WaitForSeconds(cool);
    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        if (remainingTime <= 0)
        {
            spawn.Play();
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
            else if(waveNum  == 5)
            {
                SceneTransition.Win();
            }

        }
    }

    void WaveOne()
    {
        Debug.Log("Wave1 Start");
        remainingTime = 10;
        t.setRemainingTime(remainingTime);

        StartCoroutine(ws.delay(CooldownTime));
        //Spawn enemies
        for (int i=0; i<30; i++)
        {
            //int randomObstacle = Random.Range(0, obstaclesTemplate.Length);
            int randomHeight = Random.Range(0, spawnPoints.Length);
            Vector2 position = new Vector2(spawnPoints[randomHeight].position.x, spawnPoints[randomHeight].position.y);

            Instantiate(obstaclesTemplate[0], position, Quaternion.identity);
        }
    }

    void WaveTwo()
    {
        Debug.Log("Wave2 Start");
        remainingTime = 10;//120
        t.setRemainingTime(remainingTime);

        //Spawn
        for (int i = 0; i < 40; i++)
        {
            int randomHeight = Random.Range(0, spawnPoints.Length);
            Vector2 position = new Vector2(spawnPoints[randomHeight].position.x, spawnPoints[randomHeight].position.y);

            Instantiate(obstaclesTemplate[0], position, Quaternion.identity);
        }
    }
    void WaveThree()
    {
        Debug.Log("Wave3 Start");
        remainingTime = 20;//240
        t.setRemainingTime(remainingTime);

        //Spawn
        for (int i = 0; i < 20; i++)
        {
            int randomHeight = Random.Range(0, spawnPoints.Length);
            Vector2 position = new Vector2(spawnPoints[randomHeight].position.x, spawnPoints[randomHeight].position.y);

            Instantiate(obstaclesTemplate[0], position, Quaternion.identity);
            Instantiate(obstaclesTemplate[1], position, Quaternion.identity);
        }
    }
    void WaveFour()
    {
        Debug.Log("Wave4 Start");
        remainingTime = 60;//240
        t.setRemainingTime(remainingTime);

        int randomHeight = Random.Range(0, spawnPoints.Length);
        Vector2 position = new Vector2(spawnPoints[randomHeight].position.x, spawnPoints[randomHeight].position.y);
        Instantiate(obstaclesTemplate[2], position, Quaternion.identity);

        randomHeight = Random.Range(0, spawnPoints.Length);
        position = new Vector2(spawnPoints[randomHeight].position.x, spawnPoints[randomHeight].position.y);
        Instantiate(obstaclesTemplate[2], position, Quaternion.identity);

        //Spawn
        for (int i = 0; i < 30; i++)
        {
            randomHeight = Random.Range(0, spawnPoints.Length);
            position = new Vector2(spawnPoints[randomHeight].position.x, spawnPoints[randomHeight].position.y);
            Instantiate(obstaclesTemplate[0], position, Quaternion.identity);
            Instantiate(obstaclesTemplate[1], position, Quaternion.identity);
        }
        

    }
}
