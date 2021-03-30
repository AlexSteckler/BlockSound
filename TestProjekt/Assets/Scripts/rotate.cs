using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {
    float smooth = 5;
    public float tiltAngle = 60.0f, tiltAroundZ, tiltAroundX, angle;
    public Vector3 tilt;
    public float targetGrabed;
    public bool drag;

    Quaternion target;

    void Update() {
        tilt = Input.mousePosition;
    }

    private void OnMouseEnter() {
        targetGrabed = Input.mousePosition.y;
    }

    private void OnMouseDrag() {
        angle = Mathf.Clamp(tilt.y, 0, 360);
        target = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, smooth);
        //Cursor.visible = false;
    }
    private void OnMouseUp() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}