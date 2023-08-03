using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public float fadeSpeed = 1;
    public static FadeOut instance;
    private void Awake()
    {
        instance = this;
    }

    private void SetCompatibility()
    {
        Renderer renderer = GetComponent<Renderer>();
        Material material = renderer.material;

        // asegurarse de que el material tenga un modo de renderizado compatible con transparencia
        material.SetFloat("_Mode", 2); // 2 = modo "Fade" en Unity 5.x y posteriores
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.EnableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = 3000; // valor de cola de renderizado para transparencia
    }

    public void StartActivate()
    {
        SetCompatibility();
        if (gameObject.activeSelf)
            StartCoroutine(Activate());
    }
    private IEnumerator Activate()
    {
        Color color = GetComponent<Renderer>().material.color;
        color.a = 0f;
        GetComponent<Renderer>().material.color = color;
        color = GetComponent<Renderer>().material.color;
        while (color.a < 1f)
        {
            color.a += Time.deltaTime / fadeSpeed;
            GetComponent<Renderer>().material.color = color;
            yield return null;
        }
    }
    public void StartFading()
    {

        if (gameObject.activeSelf)
            StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        yield return new WaitForSeconds(2f);
        SetCompatibility();
        Color color = GetComponent<Renderer>().material.color;
 
        while (color.a > 0f)
        {
            color.a -= Time.deltaTime / fadeSpeed;
            GetComponent<Renderer>().material.color = color;
            yield return null;
        }
    }
}
