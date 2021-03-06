﻿using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //Targeted GameObject to change iys location through its transform component
    public Transform target;

    //Setting the duration of the camera smoothing out/in towards the player
    public float smoothDuration;

    //Setting offset of camera
    public Vector3 offset;

    // Calls every frame after regular update but there is none in this case
    void FixedUpdate()
    {
        Vector3 setCoordinate = target.position + offset;

        Vector3 smoothPosition = Vector3.Lerp(transform.position, setCoordinate, smoothDuration);

        transform.position = smoothPosition;
        /*
        Creating a Vector3 that will grab the player's position and add it to the camera offset.
        Create another Vector3 that will go from it's current spot to the player in a smooth motion with a set amount of time.
        smoothPosition variable will then be added to the camera's transform component, applying the change
        in postion every frame assuring that it smoothes out.
        */
    }
}
