using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPowerUp : MonoBehaviour
{
    private float playerSpeed = 0.4f;
    private float finalVelocity = 0.4f;
    private float turnSpeed = 80f;



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false; //Turning off Mesh Renderer work around (Destroy(gameObject)) is deleting the script before the code is executed. (WILL FIX THIS LATER.)
            ThirdPersonCharacterMovement.instance.currentVelocity = playerSpeed;
            ThirdPersonCharacterMovement.instance.finalVelocity = finalVelocity;
            ThirdPersonCharacterMovement.instance.TurnSpeed = turnSpeed;
            Invoke("RegularSpeed", 3); //destroy object and regular speed have to be the same *BUG*
            Invoke("DestroyObject", 3); //An invoke of 1 second to make sure the code is executed before the gameObject destroys itself before the codes executed (WILL FIX THIS LATER.)

        }
    }
    void RegularSpeed()
    {
        ThirdPersonCharacterMovement.instance.currentVelocity = 0.25f;
        ThirdPersonCharacterMovement.instance.finalVelocity = 0.25f;
        ThirdPersonCharacterMovement.instance.TurnSpeed = 100f;
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
