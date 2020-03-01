using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinishedRaceUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }


    public void changeMenuScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
    // Update is called once per frame
    void Update()
    {
        //  OnMouseUp();
    }
}
