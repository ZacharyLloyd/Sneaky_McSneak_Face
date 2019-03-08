using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPawn : Pawn
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
    public override float Rotate(float direction)
    {
        // Turning makes noise! Change volume to whichever is more -- current volume or the turn volume
        if (noisemaker != null)
        {
            noisemaker.PlayerVolume = Mathf.Max(noisemaker.PlayerVolume, TurnVolume);
        }

        if (Mathf.Abs(rotationSpeed) < Mathf.Abs(maxRotationSpeed))
        {
            rotationSpeed += rateOfRotation; //The rotation speed is not assigned to a number
                                             //It will increment the rateOfRotation times direction (which has values of -1 and 1
        }
        transform.Rotate(direction * Vector3.forward, rotationSpeed); //Then update the rotation of the GameObject every frame, rotationSpeed being how fast the rotation is

        return direction; //Returning the value direction for the update function
        //Controls the rotation of the player
    }

    public override void Forward()
    {

        movement = Input.GetKey(KeyCode.W);

        // Turning makes noise! Change volume to whichever is more -- current volume or the turn volume
        if (noisemaker != null)
        {
            noisemaker.PlayerVolume = Mathf.Max(noisemaker.PlayerVolume, MoveVolume);
        }

        //Going forwards
        if (movement == true)
        {
            if (Mathf.Abs(speed) * -1 > Mathf.Abs(maxSpeed) * -1)
                speed += rateOfSpeed;

            rigidBody.AddForce(speed * (transform.localRotation * new Vector2(rotationSpeed, 0f)));
        }
        else
        {
            if (Mathf.Abs(speed) * -1 < 0)
                speed -= rateOfSpeed * Mathf.Sign(speed);
        }
    }
    //Moving backwards
    public override void Backwards()
    {

        reverseMovement = Input.GetKey(KeyCode.S);

        // Turning makes noise! Change volume to whichever is more -- current volume or the turn volume
        if (noisemaker != null)
        {
            noisemaker.PlayerVolume = Mathf.Max(noisemaker.PlayerVolume, MoveVolume);
        }

        if (reverseMovement == true)
        {
            if (Mathf.Abs(speed) < Mathf.Abs(maxSpeed))
                speed += rateOfSpeed;

            rigidBody.AddForce(speed * (transform.localRotation * new Vector2(-rotationSpeed, 0f)));
        }
        else
        {
            if (Mathf.Abs(speed) > 0)
                speed -= rateOfSpeed * Mathf.Sign(-speed);
        }
    }
}
