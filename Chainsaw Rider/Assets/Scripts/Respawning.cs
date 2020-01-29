using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour
{

    public Transform[] safePoints;
    Transform closestTransform;

    void Update()
    {
        // You have to set up an input button in the Input manager for this!
        if (Input.GetButtonDown("reset"))
        {
            // put this in a different function for general cleanliness
            ResetCar();
        }
    }
    void ResetCar()
    {
        // first, find the closest safe place
        float closestDistance = 9999999999;
        Vector3 currentPos = transform.position;
        // This goes through every possible safe place and picks the best one
        foreach (Transform trans in safePoints)
        {
            float currentDistance = Vector3.Distance(currentPos, trans.position);
            if (currentDistance < closestDistance)
            {
                closestDistance = currentDistance;
                closestTransform = trans;
            }
        }

        // Now we reset the car!
        transform.position = closestTransform.position;
        transform.rotation = closestTransform.rotation;
    }
}