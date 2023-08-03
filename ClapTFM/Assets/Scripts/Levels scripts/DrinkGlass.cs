using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkGlass : MonoBehaviour
{
    public Transform overCameraRig;
    public static DrinkGlass instance;
    public int nDrink;
    public GameObject[] drinks;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        nDrink = 0;
        for (int i = 1; i < drinks.Length; i++)
        {
            drinks[i].SetActive(false);
        }
        drinks[0].SetActive(true);
    }

    void Update()
    {
        //Mira si la distancia entre el vaso y la cámara es menor que 0.2
        float dist = Vector3.Distance(drinks[nDrink].transform.position, overCameraRig.position);
        if (dist < 0.2)
        {
            AudioManager.instance.PlaySFX(4);
            NewGlass();
        }
    }
    public void NewGlass()
    {
        ++nDrink;
        ChangeCanvas.instance.changeCanvasRelative(nDrink.ToString(), 2);
        if (nDrink < drinks.Length)
        {
            drinks[nDrink - 1].SetActive(false);
            drinks[nDrink].SetActive(true); 
        }
        //else
        //{
        //    GameManager.instance.Finish();
        //}
    }
}
