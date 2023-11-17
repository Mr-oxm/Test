using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseZoom : MonoBehaviour
{
    private Camera Cam;               // Reference to the Camera component
    public float TargetZoom = 3;      // The target orthographic size for zooming
    private float ScrollData;         // Stores the scroll input data
    public float ZoomSpeed = 3;       // The speed at which the camera zooms

    // Start is called before the first frame update
    void Start()
    {
        Cam = GetComponent<Camera>();  // Get the Camera component attached to the same GameObject
        TargetZoom = Cam.orthographicSize;  // Set the initial target zoom to the current orthographic size
    }

    // Update is called once per frame
    void Update()
    {
        ScrollData = Input.GetAxis("Mouse ScrollWheel");  // Get the scroll input data from the mouse

        // Adjust the target zoom based on the scroll input and clamp it to a specified range
        TargetZoom -= ScrollData;
        TargetZoom = Mathf.Clamp(TargetZoom, 3, 6);
    }
}

