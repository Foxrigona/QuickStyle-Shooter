using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WimpyAttacker : Shooter
{
    override
    public void attack()
    {
        Instantiate(this.bullet, this.transform.position + new Vector3(radius,0), Quaternion.AngleAxis(calculateRotation(), Vector3.forward));
    }

    public void Start()
    {
        base.Start();
        attack();
    }
}
