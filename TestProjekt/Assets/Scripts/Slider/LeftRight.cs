using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRight : MonoBehaviour
{
    private Vector3 targetPosition, mousePos;
    private bool dragging = false;
    private float distance;
    private float startPos;
 
    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
        //Cursor.visible = false;
    }
 
    void OnMouseUp()
    {
        dragging = false;
        //Cursor.visible = true;
        //this.transform.position = new Vector3(this.transform.position.x / 10,)
    }
 
    void Update() {
        mousePos=Input.mousePosition;
        targetPosition=Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x , mousePos.y ,distance));
        if (dragging) {
            transform.localPosition = new Vector3(targetPosition.x, 0.5f, transform.position.z);
        }
    }

    void Start() {
        startPos = gameObject.transform.position.x;
    }
}
