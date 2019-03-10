using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    //Player Components
    //Initializing speed and the speed of rotation
    [HideInInspector] public float speed; //Current speed 
    [HideInInspector] public float rotationSpeed; //Current rotation speed
    public float maxSpeed; //The max speed
    public float maxRotationSpeed; //Max speed for rotation
    public float rateOfSpeed; //The amount of speed gained over time
    public float rateOfRotation; //The amount of rotation speed gained over time

    public bool enableReversedControl = true; //Reservsing the controls

    public float clockwise; //Reads the values 1 and -1, 1 for clockwise and -1 for counter clockwise
    public static float rotationValue; //Rotation controls, returns the value of the controller/keyboard (-1, 0, 1)

    public bool movement; //Detecting movement
    public bool reverseMovement; //Detecting reverse movement

    public Rigidbody2D rigidBody; //Giving a name that will reference the rigid body on the sprite
    public static Vector3 originPosition;

    public Transform tf; //Declaring the transform
    public Noisemaker noisemaker; //Creating the noisemaker for the player
    public float MoveVolume; //Moving volume
    public float TurnVolume; // Turning volume


    //AI Component
    public AISenses senses;

    //FSM
    public enum AIStates
    {
        Idle,
        Chase,
        LookAround,
        GoHome,
        Shoot
    }
    public Vector3 homePoint;
    public Vector3 goalPoint;
    public AIStates currentState;
    public float stopChaseDistance;
    public float closeEnough;

    public float moveSpeed = 1;
    public float turnSpeed = 1;

    public GameObject bulletPrefab;
    public GameObject enemyBulletPrefab;
    public IEnumerator coroutine;
    public bool canShoot = true;
    public Transform pointOfFire;

    // Start is called before the first frame update
    public virtual void Start()
    {
        // Store my senses component
        senses = GetComponent<AISenses>();

        tf = GetComponent<Transform>();

        // Load noisemaker
        noisemaker = GetComponent<Noisemaker>();

        // Save home point
        homePoint = tf.position;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void FixedUpdate()
    {
        rotationValue = Input.GetAxisRaw("Horizontal"); //Left or right arrow keys or A and D keys

        Rotate(-rotationValue); //rotationValue is used as a parameter for the rotate function

        if (Input.GetKey(KeyCode.W)) Forward();

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
    public virtual void Shoot()
    {

    }
    IEnumerator Recoil()
    {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }

}
