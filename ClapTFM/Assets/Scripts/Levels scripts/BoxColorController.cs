using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script que controla cada caja de la prueba. Fuciona con el scipt ColorShelfPoints
public class BoxColorController : MonoBehaviour
{
    //set una forma de decir que la caja está colocada en su sitio. 
    private bool set = false;

    private void OnTriggerEnter(Collider other)
    {
       // if (!set)
        {
            //Si la caja es azul y se coloca en el estante azul
            if (other.tag.Equals("shelfBlue") && gameObject.name == "BlueBox")
            {
                ++ColorsShelfPoints.instance.pointsSet;
                set = true;
            }
            //Si la caja es roja y se coloca en el estante rojo
            else if (other.tag.Equals("shelfRed") && gameObject.name == "RedBox")
            {
                ++ColorsShelfPoints.instance.pointsSet;
                set = true;
            }
            //Si points set llega a 2 es que se han colocado las 2 cajas,
            ////por lo que se reinician los puntos del set y se activan nuevas cajas
            if (ColorsShelfPoints.instance.pointsSet >= 2)
            {
               
                ColorsShelfPoints.instance.pointsSet = 0;
                ColorsShelfPoints.instance.NewBoxes();
            }
        }
        //Si se cae se reinicia
        if(other.tag.Equals("floor"))
        {
            ColorsShelfPoints.instance.pointsSet = 0;
            ColorsShelfPoints.instance.Reset();
        }
    }
}
