using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    private Vector3 targetPosition, mousePos;
    public float notePos;
    private bool dragging = false;
    private float distance;
    public float percentage;
 
    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        Cursor.visible = false;
    }
 
    void OnMouseUp()
    {
        dragging = false;
        Cursor.visible = true;
    }
 
    void Update()
    {
        mousePos=Input.mousePosition;
        targetPosition=Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x ,mousePos.y ,distance));
        float wertZ = Mathf.Clamp(targetPosition.z, -5f, 5f);
        if (dragging) {
            transform.position = new Vector3 (notePos, 0.5f, wertZ);
        }

        percentage = (transform.position.z - (-5f)) / (5f - (-5f));
    }

    void Start() {
        transform.position = new Vector3(notePos, 0.5f, 0f);
    }
}
