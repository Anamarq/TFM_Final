using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartButton : MonoBehaviour
{
    public GameObject button;
    public void StartTimer()
    {
        Timer.instance.timerIsRunning = true;
        button.SetActive(false);
    }
}
