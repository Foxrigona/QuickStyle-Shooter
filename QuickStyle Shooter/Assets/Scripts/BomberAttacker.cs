using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberAttacker : Shooter
{
    [SerializeField] private int bulletcount = 5;
    public override void attack()
    {
        for(int i = 1; i <= bulletcount; i++)
        {
            float angle = 360f/bulletcount * i + 45;
            Quaternion posRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Vector3 direction = (posRotation * Vector3.up);
            Debug.Log(this.transform.position + direction.normalized * this.radius);
            Instantiate(bullet, this.transform.position + direction.normalized * this.radius, posRotation);
        }
        Destroy(gameObject);
    }
}
