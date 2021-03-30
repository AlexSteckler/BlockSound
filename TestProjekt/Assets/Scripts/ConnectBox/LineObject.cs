using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineObject : MonoBehaviour
{
    // Creates a line renderer that follows a Sin() function
    // and animates it.
    public bool triggerActive = false;

    public GameObject line,lineCopy; 
    public bool lineActive;
    public GameObject paredObj;
    public GameObject metro;
    public float dist,speed,amplitude = 0.5f;
    public int lengthOfLineRenderer = 20;

    void Start() {

    }

    void Update() {
        if (triggerActive && lineActive) {
            LineRenderer lineRenderer = lineCopy.GetComponent<LineRenderer>();
            createLine(lineRenderer, gameObject.transform, paredObj.transform);
        }
        if (amplitude < 1f) amplitude = 1f;

        speed = metro.GetComponent<LineMetronom>().wert / 10;
    }

    public void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("noNote"))
        {
            if(!lineActive) {
                lineCopy = Instantiate(line);
                lineCopy.transform.parent = gameObject.transform;
                lineActive = true;
            }
            triggerActive = true;
            paredObj = other.gameObject;
            this.transform.parent = paredObj.transform;
        }
    }
 
    public void OnTriggerExit(Collider other) {
        if (!other.CompareTag("noNote")){
            triggerActive = false;
            Destroy(lineCopy);
            lineActive = false;
            
        }
    }

    void createLine(LineRenderer lineRenderer, Transform o1, Transform o2) {
        dist = Vector3.Distance(o1.position, o2.position);
        float parts = dist / lengthOfLineRenderer;
        var points = new Vector3[lengthOfLineRenderer];
        var t = Time.time;
        for (int i = 0; i < lengthOfLineRenderer; i++)
        {
            points[i] = new Vector3( Mathf.Sin(i + t * speed)/amplitude + o1.position.x + i * (o2.position.x - o1.position.x) / 20, 1f, o1.position.z + i * (o2.position.z - o1.position.z) / 20 );
        }
        lineRenderer.SetPositions(points);
    }

}
