using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script que controla la prueba de las cajas de colores.
public class ColorsShelfPoints : MonoBehaviour
{
    public static ColorsShelfPoints instance;
    public int pointsSet; //puntos del set
    private int nBoxes; //identifica el número de caja del array
    public int points; //Puntos totales, cada set completo
    public GameObject[] boxes;
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        nBoxes = 0;
        pointsSet = 0;
        points = 0;
        for (int i = 1; i < boxes.Length; i++)
        {
            boxes[i].SetActive(false);
        }
        boxes[0].SetActive(true);
    }

    public void NewBoxes()
    {
        AudioManager.instance.PlaySFX(4);
        //Fade out cada caja. El array boxes contiene 2 cajas, en cada posición,
        //hay que acceder a los hijos, 0 para la caja 0 y 1 para la caja 1.
        //La malla es hija del objeto, por lo que hay que acceder con GetComponentInChildren al script fadeOut. 
        boxes[nBoxes].transform.GetChild(0).GetComponentInChildren<FadeOut>().StartFading();
        boxes[nBoxes].transform.GetChild(1).GetComponentInChildren<FadeOut>().StartFading();

        //Desactiva el anterior
        if (nBoxes >= 1)
            boxes[nBoxes - 1].SetActive(false);
        ++nBoxes;
        ++points;
        ChangeCanvas.instance.changeCanvasRelative(points.ToString(), 5); //Actualiza canvas
        if (nBoxes < boxes.Length - 1)
        {
            boxes[nBoxes].SetActive(true); //Activa el nuevo elemento de cajas
        }
    }
    public void Reset()
    {
        //Resetear en caso de que se caiga una caja
        ++nBoxes;
        if (nBoxes < boxes.Length - 1)
        {
            boxes[nBoxes - 1].SetActive(false);
            boxes[nBoxes].SetActive(true);
        }
    }
}
