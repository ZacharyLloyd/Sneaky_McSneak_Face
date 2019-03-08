using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start(); //Calling the parent start function
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // The player controller gets input from the keyboard and then moves the pawn.
        if (Input.GetKey(KeyCode.W))
        {
            pawn.Forward();
        }
        if (Input.GetKey(KeyCode.S))
        {
            pawn.Backwards();
        }

        // Only the person will rotate, but always handle the inpyut
        if (Input.GetKey(KeyCode.A))
        {
            pawn.Rotate(-PlayerMovement.rotationValue);
        }

        // Only the person pawn will rotate, but always handle the inpyut
        if (Input.GetKey(KeyCode.D))
        {
            pawn.Rotate(PlayerMovement.rotationValue);

        }
    }
}
