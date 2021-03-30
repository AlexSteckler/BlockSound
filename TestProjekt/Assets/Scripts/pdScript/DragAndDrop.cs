using System.Collections;
using UnityEngine;
 
class DragAndDrop : MonoBehaviour
{
    private bool dragging = false;
    private float distance;
    [Range(-0.44f, 0.44f)]
    public float floatRange;
    public static float percentage;

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
    }
    void Update() {
        Vector3 ray = Input.mousePosition;
        Vector3 rayPoint = Camera.main.ScreenToWorldPoint(new Vector3(ray.x ,ray.y , distance));
        if (dragging && transform.position.x <= 0.44f && transform.position.x >= -0.44f)
        {
            transform.position = new Vector3(rayPoint.x,transform.position.y,transform.position.z);
            percentage = 100 * (transform.position.x - (-0.44f)) / (0.44f - (-0.44f)); //x - a / b - a * percentage
        } 
        if (dragging && transform.position.x >= 0.44f || transform.position.x <= -0.44f) {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
            percentage = 100 * (transform.position.x - (-0.44f)) / (0.44f - (-0.44f));
        }
    }
    
}
 