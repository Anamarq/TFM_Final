using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapPoints : MonoBehaviour
{
    public static CapPoints instance;
    private int nCaps; //identifica el número de tapón del array
    public int points; //Puntos totales
    public int pointsSet; //puntos por set
    public GameObject[] caps;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        nCaps = 0;
        points = 0;
        pointsSet = 0;
        for (int i = 1; i < caps.Length; i++)
        {
            caps[i].SetActive(false);
        }
        caps[0].SetActive(true);
    }

    public void NewCaps()
    {
        AudioManager.instance.PlaySFX(4);
        ++nCaps;
        ++points;
        ChangeCanvas.instance.changeCanvasRelative(points.ToString(), 3);
        if (nCaps < caps.Length - 1)
        {
            caps[nCaps - 1].SetActive(false);
            caps[nCaps].SetActive(true);
        }
    }
    public void Reset()
    {
        ++nCaps;
        if (nCaps < caps.Length - 1)
        {
            caps[nCaps - 1].SetActive(false);
            caps[nCaps].SetActive(true);
        }
    }
}
