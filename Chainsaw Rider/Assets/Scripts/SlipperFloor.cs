using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipperyFloor : MonoBehaviour
{
    public ThirdPersonCharacterMovement angle;
    float spinSpeed = 50;
    public GameObject player;

    public float smooth = 2f;
    public float target = 360f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            Debug.Log("Should rotate");

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            float angle = Mathf.MoveTowardsAngle(transform.eulerAngles.y, target, smooth * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }
}
