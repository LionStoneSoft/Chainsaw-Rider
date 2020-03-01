using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Transform rocketTarget;
    public Rigidbody rocketRigidbody;

    public float turn;
    public float rocketVelocity;
    public float missileDamage;
    public static Rocket instance;


    private void Start()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        rocketOnPlayers();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //This will need changing eventually when there's multiplayer, can't hard-code a player tag as the rocket will target random ID's
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(missileDamage);
            Destroy(gameObject);
            Debug.Log("damage");
        }
    }

    public void rocketOnPlayers() //change back to void later if possible
    {
        rocketRigidbody.velocity = transform.forward * rocketVelocity;

        var rocketTargetRotation = Quaternion.LookRotation(rocketTarget.position - transform.position);

        rocketRigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, rocketTargetRotation, turn));
    }
}
