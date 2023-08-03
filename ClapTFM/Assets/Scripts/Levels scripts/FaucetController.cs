using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaucetController : MonoBehaviour
{
    public GameObject water;
    private bool on;
    public int nfaucet;
    public static FaucetController instance;
    private void Awake()
    {
        instance = this;   
    }
    void Start()
    {
        on = false;
        nfaucet = 0;
        water.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        //grifo abierto
        if(other.tag.Equals("faucetOn"))
        {
            if (on == false)
            {
                ++nfaucet;
                water.SetActive(true);
                ChangeCanvas.instance.changeCanvasRelative(nfaucet.ToString(), 6);
                on = true;
                AudioManager.instance.PlaySFX(1);
            }
        }
        //grifo cerrado
        if (other.tag.Equals("faucetOff"))
        {
            if (on == true)
            {
                ++nfaucet;
                water.SetActive(false);
                ChangeCanvas.instance.changeCanvasRelative(nfaucet.ToString(), 6);
                on = false;
                AudioManager.instance.StopSFX(1);
            }
        }
    }
}
