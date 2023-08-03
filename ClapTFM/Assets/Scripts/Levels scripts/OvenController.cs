using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenController : MonoBehaviour
{
    public GameObject lightOn;
    private bool on;
    public int nOven;
    //public Transform pomoPos;
    public static OvenController instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
       // pomoPos.position = new Vector3(0.733899951f, 1.82800007f, -0.966499984f);
      //  pomoPos.rotation = Quaternion.Euler(0f, 0f, 0f);
        on = false;
        nOven = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        //Horno encendido
        if (other.tag.Equals("ovenOn"))
        {
            if (on == false)
            {
                ++nOven;
                
                lightOn.GetComponent<Renderer>().material.color = Color.red;
                ChangeCanvas.instance.changeCanvasRelative(nOven.ToString(), 7);
                on = true;
                AudioManager.instance.PlaySFX(2);
            }
        }
        //Horno apagado
        if (other.tag.Equals("ovenOff"))
        {
            if (on == true)
            {
                ++nOven;
                
                lightOn.GetComponent<Renderer>().material.color = Color.black;
                ChangeCanvas.instance.changeCanvasRelative(nOven.ToString(), 7);
                on = false;
                AudioManager.instance.PlaySFX(2);
            }
        }
    }
}
