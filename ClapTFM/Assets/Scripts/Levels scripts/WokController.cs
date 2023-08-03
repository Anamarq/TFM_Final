using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WokController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("stove"))
        {
            ChangeWok.instance.NewWok();
            GetComponentInParent<FadeOut>().StartFading();
            Destroy(gameObject);
        }
        if(other.tag.Equals("floor"))
        {
            ChangeWok.instance.Reset();
        }
    }
}
