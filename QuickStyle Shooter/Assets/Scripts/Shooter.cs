using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    protected Transform target;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected float radius  = 0.1f;

    public void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public abstract void attack();

    protected float calculateRotation()
    {
        float angle = - 180 - Vector2.SignedAngle(this.transform.position - target.position, Vector2.up);
        Debug.Log(angle);
        return angle;
    }

    protected float calculateRotation(Vector3 targetPosition)
    {
        float angle = -180 - Vector2.SignedAngle(this.transform.position - targetPosition, Vector2.up);
        Debug.Log(angle);
        return angle;
    }

    protected Vector2 bulletSpawnPosition()
    {
        Vector2 directionalVector = (target.position - this.transform.position).normalized;
        Vector2 spawnPosition = directionalVector * radius + new Vector2(transform.position.x, transform.position.y);
        return spawnPosition;
    }

    protected Vector2 bulletSpawnPosition(Vector3 targetPosition)
    {
        Vector2 directionalVector = (targetPosition - this.transform.position).normalized;
        Vector2 spawnPosition = directionalVector * radius + new Vector2(transform.position.x, transform.position.y);
        return spawnPosition;
    }

}
