using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ToggleName : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text textShow;

    public void OnSelected()
    {
        textShow.text = text.text;
        string name = text.text;
        LoginUser.instance.SetNameUser(name);
    }
}
