using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassTop : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("EndSurface"))
        {
            --ChangeGlass.instance.pointGlass;
            ChangeCanvas.instance.changeCanvasRelative(ChangeGlass.instance.pointGlass.ToString(), 0);
        }
    }
}
