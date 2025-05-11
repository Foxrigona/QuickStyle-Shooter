using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(Collider2D))]
public class BulletReflector : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private String reflictiveTag = "Wall";
    [SerializeField] int damageAmount = 7;
    public void Start()
    {
        rb.velocity = transform.up * this.moveSpeed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals(reflictiveTag)) reflectBullet(collision);
        else
        {
            dealDamage(collision.transform.GetComponent<Health>());
        }
    }

    private void dealDamage(Health health)
    {
        if(health == null) Destroy(this.gameObject);
        if (health  is PlayerHealth){
            PlayerHealth h = health as PlayerHealth;
            h.decreaseHealth(this.damageAmount);
        }
        else health?.decreaseHealth(this.damageAmount);
        Destroy(this.gameObject);
    }

    private void reflectBullet(Collision2D collision)
    {
        float collisionAngle = 90 + Vector2.SignedAngle(-transform.up, collision.contacts[0].normal);
        this.transform.Rotate(0, 0, collisionAngle * 2);
        rb.velocity = transform.up * this.moveSpeed;
    }
}
