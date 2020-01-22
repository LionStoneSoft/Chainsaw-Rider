using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonCharacterMovement : MonoBehaviour
{
    public static ThirdPersonCharacterMovement instance;

    public float Speed;
    public float TurnSpeed;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public bool isGrounded;
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
        float ver = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * Time.deltaTime * Speed * ver);
        transform.Rotate(Vector3.up, Time.deltaTime * TurnSpeed * hor);
        //Quaternion rotat = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);
        if (Input.GetKey(KeyCode.D))
        {
            lean = -80;
            leanBack = -30;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            lean = 80;
            leanBack = -30;
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
