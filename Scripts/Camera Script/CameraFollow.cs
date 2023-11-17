using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;   // The target the camera will follow
    public float Cameraspeed;   // The speed at which the camera follows the target
    public float minX, maxX;    // Minimum and maximum X-axis values for camera position
    public float minY, maxY;    // Minimum and maximum Y-axis values for camera position

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code goes here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Update code goes here if needed (empty in this case)
    }

    // FixedUpdate is called at a fixed time interval, good for physics calculations
    void FixedUpdate()
    {
        // Check if a target is assigned
        if (Target != null)
        {
            // Calculate the new camera position using Vector2.Lerp for smooth movement
            Vector2 newCamPosition = Vector2.Lerp(transform.position, Target.position, Time.deltaTime * Cameraspeed);

            // Clamp the X and Y values to ensure the camera stays within specified bounds
            float ClampX = Mathf.Clamp(newCamPosition.x, minX, maxX);
            float ClampY = Mathf.Clamp(newCamPosition.y, minY, maxY);

            // Set the new camera position with the clamped values, maintaining the original Z position
            transform.position = new Vector3(ClampX, ClampY, -10f);
        }
    }
}
