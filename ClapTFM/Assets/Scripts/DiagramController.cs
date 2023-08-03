using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiagramController : MonoBehaviour
{
    public GameObject diagram;
    public static DiagramController instance;
    public TMP_Text[] difPoints;
    public TMP_Text textMax;
    public TMP_Text textMedia;
    private void Awake()
    {
        instance = this;
    }
    public void LoadDiagrams()
    {
        GameObject actualDiagram;
        int total;
        if (SceneData.instance.totalTries == 0)
            total = 1;
        else
        {
            total = 3;
            textMedia.gameObject.SetActive(true);
            textMax.gameObject.SetActive(true);
        }
        for (int i = 0; i < total; ++i)
        {
            actualDiagram = Instantiate(diagram);
            actualDiagram.GetComponent<ShowDiagram>().Show(i);
        }
    }
    public void differencePoints(float[] maxPoints, float[] actPoints)
    {
        for (int i = 0; i < 8; ++i)
        {
            difPoints[i].gameObject.SetActive(true);
            difPoints[i].text = (actPoints[i] - maxPoints[i]).ToString();
        }
    }
}
