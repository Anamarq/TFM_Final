using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public TMP_Text numActions;
    public TMP_Text timer;
    public Image fill;
    private void Awake()
    {
           instance = this;
    }
}
