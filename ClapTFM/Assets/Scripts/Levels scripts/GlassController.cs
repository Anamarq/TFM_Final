using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script que controla los vasos de la prueba
public class GlassController : MonoBehaviour
{
    private bool isInit;
    private bool isEnd;

    void Start()
    {
        isInit = false;
        isEnd = false; 
    }

    private void OnTriggerEnter(Collider other)
    {
        //Si está dentro del límite del estante inicial
        if (other.tag.Equals("InitLimit"))
        {
            if (isEnd == false)
                isInit = true;
        }
        //Si está dentro del límite del estante final
        if (other.tag.Equals("EndLimit"))
        {
            if (isInit == true)
                isEnd = true;
        }
        //Si toca la superficie del estante final
        if (other.tag.Equals("EndSurface"))
        {
            if (isEnd == true)
            {
                ChangeGlass.instance.NewGlass();
                GetComponentInChildren<FadeOut>().StartFading();
            }
            isInit = false;
            isEnd = false;
        }
        //Si se cae
        if (other.tag.Equals("floor"))
        {
            ChangeGlass.instance.Reset();
            isInit = false;
            isEnd = false;
        }
    }
}
