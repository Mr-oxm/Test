using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamZoom : MonoBehaviour
{
    private Camera cam;         // Reference to the Camera component
    public float ZoomSpeed;     // Speed at which the camera zooms
    public KeyCode Zbutton;     // Keycode for triggering the zoom (assigned in the Unity Editor)

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();  // Get the Camera component attached to the same GameObject
    }

    // Update is called once per frame
    void Update()
    {
        // Update code goes here if needed (empty in this case)
    }

    // FixedUpdate is called at a fixed time interval, good for physics calculations
    void FixedUpdate()
    {
        // Check if the specified key (Zbutton) is being held down
        if (Input.GetKey(Zbutton))
        {
            // If the key is held down, smoothly zoom in by adjusting the orthographic size
            // The orthographic size determines the camera's viewing volume in orthographic mode
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 4, Time.deltaTime * ZoomSpeed);
        }
        else
        {
            // If the key is not held down, smoothly zoom out to a default orthographic size
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 6, Time.deltaTime * ZoomSpeed);
        }
    }
}
