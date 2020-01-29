using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Checkpoints : MonoBehaviour
{
    public Text checkPointPassed;
    public static bool checkpointbool1 = false;
    public static bool checkpointbool2 = false;
    public static bool checkpointbool3 = false;
    public static bool finish = false;

    public GameObject canvas;
    public bool pause;

    [SerializeField] private string loadLevel;

    private float pauseUntil;
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (paused) CheckPause();

        if (finish == true)
        {
            checkPointPassed.text = "Finished";
            //Add later code to start new scene as the race is over. (or something else)
        }
        else if (checkpointbool3 == true)
        {
            checkPointPassed.text = "Checkpoint 3 passed";
        }
        else if (checkpointbool2 == true)
        {
            checkPointPassed.text = "Checkpoint 2 passed";
        }
        else if (checkpointbool1 == true)
        {
            checkPointPassed.text = "Checkpoint 1 passed";
        }
        else
        {
            checkPointPassed.text = "No checkpoints passed yet";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Checkpoint1": //Checks Tag names Checkpoint1 
                checkpointbool1 = true;
                break;
            case "Checkpoint2":  //Checks Tag names Checkpoint2
                if (checkpointbool1 == true)
                {
                    checkpointbool2 = true;
                }
                break;
            case "Checkpoint3":  //Checks Tag names Checkpoint3 
                if (checkpointbool2 == true)
                {
                    checkpointbool3 = true;
                }
                break;

            case "FinishingLine":
                if (checkpointbool3 == true)
                {
                    finish = true;
                    canvas.SetActive(true);
                    PauseForDuration(1.0f);
                }
                break;
        }
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
}
