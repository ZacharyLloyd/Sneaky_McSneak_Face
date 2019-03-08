using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    // Start is called before the first frame update
    public virtual void Start()
    {
        
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    //This is the player's functions
    public virtual void Forward()
    {

    }
    public virtual void Backwards()
    {

    }
    public virtual float Rotate(float direction)
    {
        return direction;
    }


    //This is the enemy's functions
    public virtual void Idle()
    {

    }
    public virtual void Chase()
    {

    }
    public virtual void GoHome()
    {

    }
    public virtual void LookAround()
    {

    }
    public virtual void MoveTowards(Vector3 target)
    {

    }
    public virtual void Move(Vector3 direction)
    {

    }
    public virtual void Turn(bool isTurnClockwise)
    {

    }
}
