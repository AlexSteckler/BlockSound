using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doLine : MonoBehaviour
{

    public Color c1 = Color.yellow;
    public Color c2 = Color.red;
    public int lengthOfLineRenderer = 20;
    public float dist,speed;
    public Transform o1, o2;
    LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start() {
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
            dist = Vector3.Distance(o1.position, o2.position);
            float parts = dist / lengthOfLineRenderer;
            lineRenderer = GetComponent<LineRenderer>();
            var points = new Vector3[lengthOfLineRenderer];
            var t = Time.time;
            for (int i = 0; i < lengthOfLineRenderer; i++)
            {
                points[i] = new Vector3((o1.position.x + i * (o2.position.x - o1.position.x)/20), 1+ Mathf.Sin(i + t * speed)/5, (o1.position.z + i * (o2.position.z - o1.position.z) /20 ));
            }
            lineRenderer.SetPositions(points);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
