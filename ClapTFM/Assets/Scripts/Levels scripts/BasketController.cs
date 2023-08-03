using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    private bool isInit;
    private bool isEnd;

    private void OnTriggerEnter(Collider other)
    {
        //Si sale del límite del basket
        if (other.tag.Equals("LimitBasket"))
        {
            if (isEnd == false)
                isInit = true;
        }
        //Si entra en el límite del washer
        if (other.tag.Equals("LimitWasher"))
        {
            if (isInit == true)
                isEnd = true;
        }
        //Cuando toca la superficie del washer
        if (other.tag.Equals("EndSurface"))
        {
            if (isEnd == true)
            {
                ChangeBasket.instance.NewBasket();
                GetComponent<FadeOut>().StartFading();
            }
            isInit = false;
            isEnd = false;
        }
    }
}
