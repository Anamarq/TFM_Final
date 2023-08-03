using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBasket : MonoBehaviour
{
    public static ChangeBasket instance;
    public GameObject[] baskets;
    public int nbasket = 0;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //Desactive baskets
        nbasket = 0;
        for (int i = 1; i < baskets.Length; i++)
        {
            baskets[i].SetActive(false);
        }
        baskets[0].SetActive(true);
    }
    public void NewBasket()
    {
        AudioManager.instance.PlaySFX(4);
        DeleteBasket(); //Borra el anterior
        ++nbasket;
        ChangeCanvas.instance.changeCanvasRelative(nbasket.ToString(), 4); //Actualiza el canvas
        if (nbasket < baskets.Length)
            baskets[nbasket].SetActive(true); //Activa la siguiente
        //else
        //    GameManager.instance.Finish(); //Termina si no quedan 
    }
    public void DeleteBasket()
    {
        if (nbasket >= 1)
            baskets[nbasket - 1].SetActive(false);
    }
}

