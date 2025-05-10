using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : Shooter
{
    public override void attack()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(mousePosition);
        Instantiate(bullet, this.bulletSpawnPosition(mousePosition), Quaternion.AngleAxis(this.calculateRotation(mousePosition), Vector3.forward));
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            attack();
        }
    }
}
