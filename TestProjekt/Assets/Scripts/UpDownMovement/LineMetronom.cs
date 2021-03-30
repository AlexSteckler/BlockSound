using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMetronom : MonoBehaviour
{
    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    private float startPoint = 5f, endPoint = -5f;
    public float time, speedline = 12;
    private int lengthOfLineRenderer = 2;
    public float wert;
    LineRenderer lineRenderer;

    public GameObject metro;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = gameObject.GetComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.widthMultiplier = 0.2f;
        lineRenderer.positionCount = lengthOfLineRenderer;

        // A simple 2 color gradient with a fixed alpha of 1.0f.
        float alpha = 1.0f;
        Gradient gradient = new Gradient();
        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(c1, 0.0f), new GradientColorKey(c2, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
        );
        lineRenderer.colorGradient = gradient;
        lineRenderer.SetPosition(1, new Vector3(0, 0.3f, startPoint));
        lineRenderer.SetPosition(1, new Vector3(0, 0.3f, endPoint));
        
    }

    // Update is called once per frame
    void Update() {
        wert = Remap(metro.GetComponent<rotate>().angle, 0, 360, 360, 0);
        time += Time.deltaTime * wert / speedline;
        lineRenderer.SetPosition(0, new Vector3(time, 0.3f, startPoint));
        lineRenderer.SetPosition(1, new Vector3(time, 0.3f, endPoint));
        if ( time >= 16) {
            time = 2;
        }

    }
     
    private float Remap(float value, float from1, float to1, float from2, float to2) {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
   
}
