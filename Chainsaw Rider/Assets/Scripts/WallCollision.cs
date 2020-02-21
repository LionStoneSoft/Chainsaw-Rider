using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{

    float slowDamage = 20f;
    float mediumDamage = 50f;
    float KnockOut = 100f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("HELP!");
        if (ThirdPersonCharacterMovement.instance.Speed < 60 && ThirdPersonCharacterMovement.instance.Speed > 30)
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(slowDamage); //Damage is 20 under 60 speed
            Debug.Log("Hit");
        }
        if (ThirdPersonCharacterMovement.instance.Speed > 60 && ThirdPersonCharacterMovement.instance.Speed < 90)
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(mediumDamage);
            Debug.Log("Medium Damage, OUCH!");
        }
    }
}
