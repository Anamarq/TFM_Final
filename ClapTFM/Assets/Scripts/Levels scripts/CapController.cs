using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script que controla cada tapón de la prueba
public class CapController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("trash"))
        {
            //consigue un punto para el set si entra en la basura
            ++CapPoints.instance.pointsSet;
            if(CapPoints.instance.pointsSet >= 3)
            {
                CapPoints.instance.pointsSet = 0;
                CapPoints.instance.NewCaps();
            }
        }
        //si se cae
        if(other.tag.Equals("floor"))
        {
            CapPoints.instance.pointsSet = 0;
            CapPoints.instance.Reset();
        }
    }
}
