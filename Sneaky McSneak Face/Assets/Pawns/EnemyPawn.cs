using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPawn : Pawn
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }

    public override void Idle()
    {
        //Does nothing
    }

    public override void Chase()
    {
        goalPoint = GameManager.instance.player.tf.position;
        MoveTowards(goalPoint);
    }

    public override void GoHome()
    {
        goalPoint = homePoint;
        MoveTowards(goalPoint);
    }

    public override void LookAround()
    {
        Turn(true);
    }

    public override void MoveTowards(Vector3 target)
    {
        if (Vector3.Distance(tf.position, target) > closeEnough)
        {
            //Look at target
            Vector3 vectorToTarget = target - tf.position;
            tf.right = vectorToTarget;

            //Move Forward
            Move(tf.right);
        }
    }

    public override void Move(Vector3 direction)
    {
        //Move in the direction passed through, at speed "moveSpeed"
        tf.position += (direction.normalized * moveSpeed * Time.deltaTime);
    }

    public override void Turn(bool isTurnClockwise)
    {
        //Rotate based on turnSpeed and direction enemies are turning
        if (isTurnClockwise)
        {
            tf.Rotate(0, 0, turnSpeed * Time.deltaTime);
        }
        else
        {
            tf.Rotate(0, 0, -turnSpeed * Time.deltaTime);
        }
    }

    public override void Shoot()
    {
        if (canShoot == true)
        {
            coroutine = Recoil();
            Instantiate(bulletPrefab, pointOfFire);
            canShoot = false;
            StartCoroutine(coroutine);
        }

    }
    IEnumerator Recoil()
    {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
