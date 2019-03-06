using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guard : MonoBehaviour
{
    //Values
    public float sightDistance = 10; //How far enemies can see
    public float fieldOfView = 60; //View angle
    public float hearingScale = 1.0f; //How well enemy can hear. 1.0 = normal hearing, otherwise there would be deafness/superhearing

    const float DebugAngleDistance = 2.0f;
    const float DegreesToRadians = Mathf.PI / 180.0f;
    private Transform tf;

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    
}
