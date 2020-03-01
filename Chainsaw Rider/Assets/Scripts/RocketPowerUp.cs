using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPowerUp : MonoBehaviour
{

    public GameObject rocketObject;
    public Transform playerObject; //Position of the playerObject 
    public bool missileOnPlayer;
    public static RocketPowerUp instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            missileOnPlayer = true;
            Debug.Log("Collided with: ");
            //Instantiate(rocketObject, playerObject.position, playerObject.rotation);
        }
    }
}
