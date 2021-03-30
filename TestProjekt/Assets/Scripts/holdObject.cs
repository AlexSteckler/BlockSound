using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class holdObject : MonoBehaviour
{

    public Vector3 rayPoint, targetPosition, mousePos;
    private bool dragging = false;
    private float distance;
 
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
        //this.transform.position = new Vector3(this.transform.position.x / 10,)
    }
 
    void Update()
    {
        mousePos=Input.mousePosition;
        targetPosition=Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x ,mousePos.y ,distance));
        
        if (dragging) {
            targetPosition.y = 1.0f;
            transform.position = targetPosition;
        }
    }
}
