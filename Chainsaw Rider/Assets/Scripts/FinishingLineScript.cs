using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishingLineScript : MonoBehaviour
{
    public GameObject canvas;
    public bool pause;

    [SerializeField] private string loadLevel;


    private float pauseUntil;
    private bool paused;

    void Update()
    {
        if (paused) CheckPause();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            canvas.SetActive(true);
            PauseForDuration(1.0f);
        }
    }

    void CheckpointTrig()
    {

    }
    void PauseForDuration(float duration)
    {
        paused = true;
        pauseUntil = Time.realtimeSinceStartup + duration;
        Time.timeScale = 0.0f;
    }

    void CheckPause()
    {
        if (Time.realtimeSinceStartup >= pauseUntil)
        {
            Time.timeScale = 1.0f;
            paused = false;
            SceneManager.LoadScene("YouWin");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canvas.SetActive(false);
        }
    }
}
