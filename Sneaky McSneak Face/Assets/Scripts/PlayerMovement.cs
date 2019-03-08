using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Initializing speed and the speed of rotation
    [HideInInspector] public float speed; //Current speed 
    [HideInInspector] public float rotationSpeed; //Current rotation speed
    public float maxSpeed; //The max speed
    public float maxRotationSpeed; //Max speed for rotation
    public float rateOfSpeed; //The amount of speed gained over time
    public float rateOfRotation; //The amount of rotation speed gained over time

    public bool enableReversedControl = true; //Reservsing the controls

    private float clockwise; //Reads the values 1 and -1, 1 for clockwise and -1 for counter clockwise
    public static float rotationValue; //Rotation controls, returns the value of the controller/keyboard (-1, 0, 1)

    private bool movement; //Detecting movement
    private bool reverseMovement; //Detecting reverse movement

    private Rigidbody2D rigidBody; //Giving a name that will reference the rigid body on the sprite
    public static Vector3 originPosition;

    public Transform tf; //Declaring the transform
    public Noisemaker noisemaker; //Creating the noisemaker for the player
    public float MoveVolume; //Moving volume
    public float TurnVolume; // Turning volume

    //Awake is called before the first frame
    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>(); //Grabbing the component of the local rigid body
    }
 
    // Use this for initialization
    void Start()
    {
        tf = gameObject.transform;

        // Load noisemaker
        noisemaker = GetComponent<Noisemaker>();
    }

    // Update is called once per frame
    void Update()
    {
        tf = gameObject.transform;
    }

    private void FixedUpdate()
    {
        rotationValue = Input.GetAxisRaw("Horizontal"); //Left or right arrow keys or A and D keys

        Rotate(-rotationValue); //rotationValue is used as a parameter for the rotate function

        if (Input.GetKey(KeyCode.W)) Forward();
                else if (Input.GetKey(KeyCode.S)) Backwards();
         
    }

    float Rotate(float direction)
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

    void Forward()
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
    void Backwards()
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
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || collision.tag == "Asteroid")
        {
           if (gameManager.instance.playerLives > 0)
            {
                gameManager.instance.playerLives--;
                gameObject.transform.position = originPosition;
                gameManager.instance.RemoveEnemies();
                Debug.Log("You now have " + gameManager.instance.playerLives + " lives.");
            }
            else
            {
                Debug.LogWarning("Player ship was destroyed");
                Destroy(gameObject);
            }
            gameObject.transform.position = originPosition;
        }
    } */
}

