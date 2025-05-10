using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOATMAKER : MonoBehaviour
{
    public GameObject[] Enemies;
    public GameObject GOAT;
    public AudioSource bleat;

    [SerializeField] float remainingTime = 20;

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        if (seconds <= 0)
        {
            bleat.Play();
            for (int i = 0; i <= 5; i++)
            {
                this.remainingTime = 20;
                Vector2 position = new Vector2(GOAT.transform.position.x, GOAT.transform.position.y);
                Instantiate(Enemies[Random.Range(0, 2)], position, Quaternion.identity);
            }
        }
    }

}