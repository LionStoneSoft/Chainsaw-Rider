﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonCharacterMovement : MonoBehaviour
{
    public static ThirdPersonCharacterMovement instance;
    public float Speed = 60;
    public float TurnForce = 30;
    public float BackwardsForce = 20;
    public float TurnSpeed;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
    private float lean;
    private float leanBack;
    Rigidbody rb;

    //this is our target velocity while decelerating
    public float initialVelocity = 0;

    //this is our target velocity while accelerating
    public float finalVelocity = 0.001f;

    //this is our current velocity
    public float currentVelocity = 0;

    //this is the velocity we add each second while accelerating
    public float accelerationRate = 0.2f;

    //this is the velocity we subtract each second while decelerating
    public float decelerationRate = 0.1f;

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
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * Speed, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * BackwardsForce, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * TurnForce, ForceMode.Force);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-transform.right * TurnForce, ForceMode.Force);
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
    }


    void PlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, Time.deltaTime * TurnSpeed * hor);

        //if (Input.GetKey(KeyCode.W))
        //{
        //    //add to the current velocity according while accelerating
        //    currentVelocity += (accelerationRate * Time.deltaTime);
        //    transform.Translate(0, 0, currentVelocity);
        //}
        //else
        //{
        //    //subtract from the current velocity while decelerating
        //    currentVelocity -= (decelerationRate * Time.deltaTime);
        //    if (currentVelocity > 0)
        //    {
        //        transform.Translate(0, 0, currentVelocity);
        //    }
        //    else
        //    {
        //        transform.Translate(0, 0, 0);
        //    }
        //}

        ////ensure the velocity never goes out of the initial/final boundaries
        //currentVelocity = Mathf.Clamp(currentVelocity, initialVelocity, finalVelocity);

        ////propel the object forward

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
            leanBack = 0;
        }

        float yAxis = transform.rotation.eulerAngles.y;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(leanBack, yAxis, lean), 100.0f * Time.deltaTime);
    }


}