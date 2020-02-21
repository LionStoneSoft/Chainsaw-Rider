using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecrementSpeedCollision : MonoBehaviour
{
    private float playerSpeed = 140f;
    private float turnSpeed = 20f;
    private float halfSpeed = 20f;
    private bool onGrassPenalty = false; //Grass Penalty is speed reduction being on grass (will change name later)


    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            onGrassPenalty = true;
            ThirdPersonCharacterMovement.instance.Speed = playerSpeed / halfSpeed;
            ThirdPersonCharacterMovement.instance.TurnForce = turnSpeed;
        }
    }

    private void OnTriggerExit(Collider other) //Checks whether or not the "Player" tag has exited the collision (if off the grass reset speed back to normal
    {                                          //(The speed will need to be incremental over time will do this later)
        if (other.tag == "Player")
        {
            onGrassPenalty = false;
            ThirdPersonCharacterMovement.instance.Speed = playerSpeed;   //Changes speed back to 140f (in this case)
            ThirdPersonCharacterMovement.instance.TurnForce = turnSpeed; //Changes turn speed back to 20f;
        }
    }
}
