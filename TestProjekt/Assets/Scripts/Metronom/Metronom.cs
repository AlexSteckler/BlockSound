using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronom : MonoBehaviour
{
    public float valueMetronom, distance;
    public bool drag = false;
    public Vector3 mousePos, targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        targetPosition=Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x ,mousePos.y ,distance));
        if(drag == true) {
            
            transform.Rotate(Vector3.up * 180f  * Time.deltaTime);
            
            //transform.Rotate(new Vector3(targetPosition.y, targetPosition.x, 0) * Time.deltaTime * speed);
        }
        
    }

    private void OnMouseDown() {
        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        drag = true;
    }
    private void OnMouseUp() {
        drag = false;
    }
}
