using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float zoomSpeed = 0.4f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scroll = Input.mouseScrollDelta.y;
        transform.Translate(scroll * zoomSpeed, 0, 0, Space.World);
    }
}
