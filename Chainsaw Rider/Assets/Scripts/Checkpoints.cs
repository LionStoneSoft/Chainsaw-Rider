using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Checkpoints : MonoBehaviour
{

    public int countingLaps; //THIS WILL PROB NEED DELETING
    public Text checkPointPassed;
    public static bool checkpointbool1 = false;
    public static bool checkpointbool2 = false;
    public static bool checkpointbool3 = false;
    public static bool finish = false;
    public static int countingWrongLaps;
    public static int lapCounter = 3;
    public static int lapCounting = 0;
    public bool isLapStarted = false;

    public Text lapTime;
    public GameObject[] lapTimesArray;

    public GameObject canvas;
    public GameObject RaceFinishCanvas;
    public bool pause;


    // public float LastLapTime { get; private set; }
    // public float BestLapTime { get; private set; }

    float currentLapStartTime;

    // [SerializeField] private string loadLevel;

    private float pauseUntil;
    private bool paused;

    // Start is called before the first frame update
    void Start()
    {
        checkpointbool1 = false;
        checkpointbool2 = false;
        checkpointbool3 = false;
        finish = false;
        lapCounting = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // if (paused) CheckPause();

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
        else if (checkpointbool1 == true && countingWrongLaps >= 2)
        {
            checkPointPassed.text = "Wrong Way!!";
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


    /*  public float CurrentLapTime
      {
          get
          {
              return Time.realtimeSinceStartup - currentLapStartTime;
          }
      }*/

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Checkpoint1": //Checks Tag names Checkpoint1 
                checkpointbool1 = true;

                Debug.Log("Player goes through..");
                countingWrongLaps = countingWrongLaps + 1;

                if (countingWrongLaps >= 2)
                {
                    Debug.Log("Wrong Way");
                }
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
                    lapCounting = lapCounting + 1;
                    // lapTimes();

                    if (checkpointbool1 == true && checkpointbool2 == true && checkpointbool3 == true && lapCounting < 3)
                    {
                        checkpointbool1 = false;
                        checkpointbool2 = false;
                        checkpointbool3 = false;
                        countingWrongLaps = 0;
                    }
                    else
                    {
                        finish = true;
                        canvas.SetActive(true);
                        RaceFinishCanvas.SetActive(true);
                    }
                }
                break;
        }
    }

    //   void PauseForDuration()
    // {
    //      paused = true;
    //      pauseUntil = Time.realtimeSinceStartup + duration;
    //      Time.timeScale = 0.0f;
    //  }

    //    void CheckPause()
    //    {
    //       if (Time.realtimeSinceStartup >= pauseUntil)
    //     {
    //         Time.timeScale = 1.0f;
    //        paused = false;
    //       SceneManager.LoadScene("YouWin");
    //  }
    // }

    /*   void lapTimes()
       {
           LapTimeManager.MilliCount += Time.deltaTime * 1000;
           LapTimeManager.MilliDisplay = LapTimeManager.MilliCount.ToString("F0");

           string lapTime1 = "" + LapTimeManager.MinuteCount + ":" + LapTimeManager.SecondCount + "." + LapTimeManager.MilliCount.ToString("F0");

           if (countingLaps == 0)
           {
               lapTimesArray[0].GetComponent<Text>().text = lapTime1;
               countingLaps = countingLaps + 1;

           }
           else if(countingLaps == 1)
           {
               lapTimesArray[1].GetComponent<Text>().text = lapTime1;
               countingLaps = countingLaps + 1;
           }
           else if (countingLaps == 2)
           {
               lapTimesArray[2].GetComponent<Text>().text = lapTime1;
               countingLaps = countingLaps + 1;
           }
    */
}

