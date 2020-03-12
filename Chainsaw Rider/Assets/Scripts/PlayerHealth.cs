using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public ThirdPersonCharacterMovement checkingRespawn;
    public float max_health = 100f;
    public float current_health = 1f;
    public bool tookDamage;
    public bool isRespawning;


    void Start()
    {
        current_health = max_health;
        Debug.Log(checkingRespawn.isNotRespawning);
    }

    void Update()
    {
        RespawnTimer();
    }

    public void SetHealthBar()
    {
        float my_health = current_health / max_health;
    }

    IEnumerator RespawnTimer()
    {
        checkingRespawn.isNotRespawning = true; //When this is true, no movement at all.

        Debug.Log("This is being checked" + checkingRespawn.isNotRespawning);

        yield return new WaitForSeconds(2); //Waits for 2 seconds when the player is respawning.
        gameObject.GetComponent<Respawning>().ResetCar(); //Resets car after 2 seconds, while resetting still can't move.

        yield return new WaitForSeconds(0.5f); //Another 0.5 seconds wait after respawning
        checkingRespawn.isNotRespawning = false; //Turns false to move player again.
    }

    public void TakeDamage(float amount)
    {
        current_health -= amount;
        tookDamage = true;

        if (current_health <= 0 && tookDamage == true)
        {
            StartCoroutine(RespawnTimer());
            tookDamage = false;
            current_health = 100f; //Health back to normal due to respawn
        }
    }
}
