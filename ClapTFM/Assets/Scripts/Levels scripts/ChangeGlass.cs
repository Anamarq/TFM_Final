using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGlass : MonoBehaviour
{
    public static ChangeGlass instance;
    public GameObject[] glasses;
    private int nglass = 0;
    public int pointGlass = 0;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        nglass = 0;
        pointGlass = 0;
        for (int i = 1; i < glasses.Length; i++)
        {
            glasses[i].SetActive(false);
        }
        glasses[0].SetActive(true);
    }

    public void NewGlass()
    {
        AudioManager.instance.PlaySFX(4);
        DeleteGlass();
        ++nglass;
        ++pointGlass;
        ChangeCanvas.instance.changeCanvasRelative( pointGlass.ToString(), 0);
        if (nglass < glasses.Length)
            glasses[nglass].SetActive(true);
        //else
        // GameManager.instance.Finish();
    }
    public void Reset()
    {
        glasses[nglass].SetActive(false);
        ++nglass;
        glasses[nglass].SetActive(true);
    }
    public void DeleteGlass()
    {
        if(nglass >= 1)
            glasses[nglass - 1].SetActive(false);
    }
}

