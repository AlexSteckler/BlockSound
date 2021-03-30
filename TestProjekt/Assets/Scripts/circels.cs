using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circels : MonoBehaviour
{
	public Transform objectToMove;
	[Range(0.1f, 50.0f)]
    
	public float radius = 10.0f;
	private float circleIndex, distance;
	private Vector3 centrePos = new Vector3(0, 0, 0);
    public bool dragging;
    public Vector3 targetPosition, mousePos;
	void Start()
	{

	}
	
	void Update()
	{
        mousePos=Input.mousePosition;
        targetPosition=Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x ,mousePos.y ,distance));
        if (dragging){
        Vector3 pos = centrePos;
		circleIndex = targetPosition.x;
        if(circleIndex > (2.0f * Mathf.PI))
			circleIndex -= 2.0f * Mathf.PI;
		pos.x = Mathf.Sqrt(Mathf.Pow(2,radius)-Mathf.Pow(2,targetPosition.z));
		pos.z += Mathf.Cos(circleIndex) * radius;
        // pos.z = targetPosition.z;
		gameObject.transform.position = pos;
        }
	}
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
}
