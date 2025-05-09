using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed; // Best when 1
    public float distanceToStartChase = 4;  //Start chase 15
    public float inDistanceExplode = 3;  //Best when 3

    private float distance;

    public Renderer ExplodeMan;

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

       

        if(distance < distanceToStartChase)
        {
           transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
           transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        if(distance < inDistanceExplode)
        {
            //Spawn in bullets
            Debug.Log("WithinRange");
            ExplodeMan.enabled = false;
            Destroy(this);

        }
    }
}
