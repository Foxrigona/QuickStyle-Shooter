using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BomberAttacker))]
public class AIChase : MonoBehaviour
{
    public GameObject player;
    public float speed; // Best when 1
    public float inDistanceExplode = 3;  //Best when 2

    private float distance;

    public Renderer ExplodeMan;

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if(distance < inDistanceExplode)
        {
            //Spawn in bullets
            Debug.Log("WithinRange");
            GetComponent<BomberAttacker>().attack();
        }
    }
}
