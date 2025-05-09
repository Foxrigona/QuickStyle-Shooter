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
    public void Start()
    {
        rb.velocity = transform.up * this.moveSpeed;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall") reflectBullet(collision);
        else dealDamage();
    }

    private void dealDamage()
    {
        Destroy(this.gameObject);
    }

    private void reflectBullet(Collision2D collision)
    {
        float collisionAngle = 90 + Vector2.SignedAngle(-transform.up, collision.contacts[0].normal);
        Debug.Log(collisionAngle);
        this.transform.Rotate(0, 0, collisionAngle * 2);
        rb.velocity = transform.up * this.moveSpeed;
    }
}
