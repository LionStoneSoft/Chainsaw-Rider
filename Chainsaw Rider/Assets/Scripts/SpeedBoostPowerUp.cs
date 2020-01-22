using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPowerUp : MonoBehaviour
{
    private float playerSpeed = 50f;
    private float turnSpeed = 200f;
    private bool didTrigger;



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false; //Turning off Mesh Renderer work around (Destroy(gameObject)) is deleting the script before the code is executed. (WILL FIX THIS LATER.)
            ThirdPersonCharacterMovement.instance.currentVelocity = playerSpeed;
            ThirdPersonCharacterMovement.instance.TurnSpeed = turnSpeed;
            Invoke("RegularSpeed", 1);
            Invoke("DestroyObject", 1); //An invoke of 1 second to make sure the code is executed before the gameObject destroys itself before the codes executed (WILL FIX THIS LATER.)
        }
    }
    void RegularSpeed()
    {
        ThirdPersonCharacterMovement.instance.currentVelocity = 5f;
        ThirdPersonCharacterMovement.instance.TurnSpeed = 120f;
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
