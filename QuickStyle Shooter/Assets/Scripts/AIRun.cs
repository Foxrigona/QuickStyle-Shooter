using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRun : MonoBehaviour
{
    public GameObject player;
    public float speed; // Best when 1.5
    public float distanceToStartChase = 4;  //Start chase 10

    private float distance;

    public Renderer ExplodeMan;

    void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;



        if (distance < distanceToStartChase)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, - 1 * speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        
    }

    void shootBullet()
    {
        
    }
}
