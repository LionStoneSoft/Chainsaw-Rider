using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerUp : MonoBehaviour
{
    public GameObject playerObject; //might need to change to transform
    public GameObject powerUps; //array eventually
    public GameObject powerUpsPrefab;
    Transform tempTrans;
    public bool boostOnPlayer;
    public static RandomPowerUp instance;

    //THIS SCRIPT MAY HELP FOR MISSILES, THE MISSILE WILL BE ON THE TRANSFORM OF THE PLAYER.

    void Update()
    {
        instance = this;
    }

    void randomPowerUp(Transform parent)
    {
        GameObject go = Instantiate(playerObject) as GameObject;
        go.transform.parent = parent;
    }

    void OnTriggerEnter(Collider gameObjects)
    {
        if (gameObjects.tag == "Player")
        {
            // changeParent();
            Debug.Log("Collided");
        }
        boostOnPlayer = true;
    }

    void changeParent()
    {
        //THIS COULD BE USED FOR MISSILES?
        boostOnPlayer = true;
        tempTrans = playerObject.transform.parent;
        powerUps.transform.parent = playerObject.transform;
    }
}