using System.Collections;
using UnityEngine;
 
class DragAndDrop2 : MonoBehaviour
{
    private Color mouseOverColor = Color.blue;
    private Color originalColor = Color.yellow;
    private bool dragging = false;
    private float distance;
    
    public static float percentage;
    
    void OnMouseDown()
    {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }
 
    void OnMouseUp()
    {
        dragging = false;
    }
 
    void Update()
    {
        Vector3 ray = Input.mousePosition;
        Vector3 rayPoint = Camera.main.ScreenToWorldPoint(new Vector3(ray.x ,ray.y ,distance));
        if (dragging && transform.position.z <= 0.44f && transform.position.z >= -0.44f)
        {
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Vector3 rayPoint = ray.GetPoint(distance);
            transform.position = new Vector3(transform.position.x,transform.position.y,rayPoint.z);
            //Debug.Log("f" + transform.position.z);
            percentage = 100 * (transform.position.z - (-0.44f)) / (0.44f - (-0.44f));
            //Debug.Log("p" +(int) percentage);
        }
        if (dragging && transform.position.z > 0.45f || transform.position.z < -0.45f) {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0.0f);
            percentage = 100 * (transform.position.z - (-0.44f)) / (0.44f - (-0.44f));
        }
    }
}
 