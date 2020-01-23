using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    public GameObject CountDown;
    public AudioSource GetReady; //Add this later
    public AudioSource GoAudio; //Add this later
    public GameObject LapTimer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountStart());
    }
    IEnumerator CountStart() //Count down (UI)
    {
        yield return new WaitForSeconds(1);
        CountDown.GetComponent<Text>().text = "3";
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<Text>().text = "2";
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);
        CountDown.GetComponent<Text>().text = "1";
        CountDown.SetActive(true);
        yield return new WaitForSeconds(1);
        CountDown.SetActive(false);

        LapTimer.SetActive(true);
        //Controls for chainsaw later
    }
}
