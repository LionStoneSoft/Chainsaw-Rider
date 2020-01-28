using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostPowerUp : MonoBehaviour
{
    private float playerSpeed = 140f;
    private float turnSpeed = 20f;



    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false; //Turning off Mesh Renderer work around (Destroy(gameObject)) is deleting the script before the code is executed. (WILL FIX THIS LATER.)
            ThirdPersonCharacterMovement.instance.Speed = playerSpeed;
            ThirdPersonCharacterMovement.instance.TurnForce = turnSpeed;
            Invoke("RegularSpeed", 3); //destroy object and regular speed have to be the same *BUG*
            Invoke("DestroyObject", 3); //An invoke of 1 second to make sure the code is executed before the gameObject destroys itself before the codes executed (WILL FIX THIS LATER.)

        }
    }
    void RegularSpeed()
    {
        ThirdPersonCharacterMovement.instance.Speed = 100f;
        ThirdPersonCharacterMovement.instance.TurnForce = 30f;
    }

    void DestroyObject()
    {
        Destroy(gameObject);
    }
}
