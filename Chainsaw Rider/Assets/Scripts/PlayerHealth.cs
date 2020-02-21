using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float max_health = 100f;
    public float current_health = 0f;
    public bool tookDamage;
    // Start is called before the first frame update
    void Start()
    {
        current_health = max_health;
    }

    public void SetHealthBar()
    {
        float my_health = current_health / max_health;
    }


    IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponent<Respawning>().ResetCar();
    }

    public void TakeDamage(float amount)
    {

        current_health -= amount;
        tookDamage = true;

        if (current_health <= 0 && tookDamage == true)
        {
            StartCoroutine(RespawnTimer());
            current_health = 100f; //Health back to normal due to respawn
            tookDamage = false;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
