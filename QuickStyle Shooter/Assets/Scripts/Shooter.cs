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

    public float calculateRotation()
    {
        float angle = - 180 - Vector2.SignedAngle(this.transform.position - target.position, this.transform.up);
        Debug.Log(angle);
        return angle;
    }
}
