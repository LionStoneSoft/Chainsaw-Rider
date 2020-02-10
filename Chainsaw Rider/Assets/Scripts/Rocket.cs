using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public Transform rocketTarget;
    public Rigidbody rocketRigidbody;

    public float turn;
    public float rocketVelocity;

    private void FixedUpdate()
    {
        rocketRigidbody.velocity = transform.forward * rocketVelocity;

        var rocketTargetRotation = Quaternion.LookRotation(rocketTarget.position - transform.position);

        rocketRigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, rocketTargetRotation, turn));
    }
}