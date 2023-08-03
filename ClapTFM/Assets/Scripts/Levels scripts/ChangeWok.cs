using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWok : MonoBehaviour
{
    public static ChangeWok instance;
    public GameObject[] woks;
    public int nwok = 0;
    public int points;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        points = 0;
        for (int i = 1; i < woks.Length; i++)
        {
            woks[i].SetActive(false);
        }
        woks[0].SetActive(true);
    }

    public void NewWok()
    {
        AudioManager.instance.PlaySFX(4);
        DeleteWok();
        ++nwok;
        ++points;
        ChangeCanvas.instance.changeCanvasRelative(points.ToString(), 1);
        if (nwok < woks.Length)
            woks[nwok].SetActive(true);
        //else
        //GameManager.instance.Finish();
    }
    public void DeleteWok()
    {
        if (nwok >= 1)
            woks[nwok - 1].SetActive(false);
    }
    public void Reset()
    {
        woks[nwok].SetActive(false);
        ++nwok;
        if (nwok < woks.Length)
        {
            woks[nwok].SetActive(true);
            DeleteWok();
        }
    }
}
