using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonCharacterMovement : MonoBehaviour
{
    // [SerializeField] float normalSpeedMax = 60f;
    public static ThirdPersonCharacterMovement instance;
    //   PlayerHealth respawnChecking = new PlayerHealth();
    public float NormalSpeedMax = 60f;
    public float MaxSpeed = 120f;
    public float TurnForce = 30f;
    public float BackwardsForce = 20f;
    public float TurnSpeed;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    public bool isNotRespawning = false;


    private float lean;
    private float leanBack;
    Rigidbody rb;


    void Start()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == ("Ground") && isGrounded == false)
        {
            isGrounded = true;
        }
    }

    private void FixedUpdate()
    {
        rb.drag = 0.8f;
        {
            if (isNotRespawning == false)
            {
                if (Input.GetKey(KeyCode.W) && isNotRespawning == false)
                {
                    rb.AddForce(transform.forward * NormalSpeedMax, ForceMode.Force);
                }
                if (Input.GetKey(KeyCode.LeftShift) && isNotRespawning == false)
                {
                    rb.AddForce(-transform.forward * BackwardsForce, ForceMode.Force);
                }
                if (Input.GetKey(KeyCode.D) && isNotRespawning == false)
                {
                    rb.AddForce(transform.right * TurnForce, ForceMode.Force);
                }
                if (Input.GetKey(KeyCode.A) && isNotRespawning == false)
                {
                    rb.AddForce(-transform.right * TurnForce, ForceMode.Force);
                }
            }
            else
            {
                //If isNotRespawning = false, allow movement. If it's true, no movement.
                Debug.Log("Respawning dont move");
            }
        }
    }

    void Update()
    {

        PlayerMovement();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }

        MissileReady(); //This is new needs work check down below for the function

        if (Input.GetKeyDown("space") && RandomPowerUp.instance.boostOnPlayer == true) //Checks both keydownspace and boolean from another script
        {
            SpeedBoostPowerUp boostOnSpace = new SpeedBoostPowerUp();
            boostOnSpace.SpeedBoostingPowerUp();
            RandomPowerUp.instance.boostOnPlayer = false; //Set it false again
            Invoke("SpeedTurnForce", 3); //check this later
        }
        else
        {
            return;
        }

        if (NormalSpeedMax > 100)
        {
            Invoke("SpeedBackToNormal", 3); //Calls this function then waits for 3 seconds.
        }

        void PlayerMovement()
        {
            float hor = Input.GetAxis("Horizontal");
            transform.Rotate(Vector3.up, Time.deltaTime * TurnSpeed * hor);

            if (Input.GetKey(KeyCode.D))
            {
                lean = -60;
                leanBack = 0;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                lean = 60;
                leanBack = 0;
            }
            else
            {
                lean = 0;
                if (Input.GetKey(KeyCode.W))
                {
                    leanBack = 10;
                }
                else
                {
                    leanBack = 0;
                }
            }
            float yAxis = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(leanBack, yAxis, lean), 100.0f * Time.deltaTime);
        }
    }


    void MissileReady() //Missile script
    {
        if (Input.GetKeyDown("space") && RocketPowerUp.instance.missileOnPlayer == true)
        {
            Debug.Log("Worked");
            Rocket missileOnPress = new Rocket();
            missileOnPress.rocketOnPlayers();
        }
    }
    void SpeedTurnForce()
    {
        NormalSpeedMax = 60;
        TurnForce = 30;
    }

    void SpeedBackToNormal() //Speed back to normal after the speed boost (Can Invoke this)
    {
        NormalSpeedMax = 60;
    }
}
