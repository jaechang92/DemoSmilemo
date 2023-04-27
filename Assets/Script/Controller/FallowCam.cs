using UnityEngine;

public class FallowCam : MonoBehaviour
{
    public Transform target; // The transform of the character to follow
    public Vector3 offset = new Vector3(0f, 0f, -10f); // The offset from the target position
    public float smoothSpeed = 0.125f; // The smoothness of camera movement

    public Vector2 minBounds; // The minimum bounds for camera movement
    public Vector2 maxBounds; // The maximum bounds for camera movement

    private void Start()
    {
        target = GameManager.Instance.GetPlayer().transform;
    }


    void LateUpdate()
    {
        // Check if there is a target to follow
        if (target != null)
        {
            // Calculate the desired position of the camera
            Vector3 desiredPosition = target.position + offset;

            // Clamp the desired position to be within the specified bounds
            desiredPosition.x = Mathf.Clamp(desiredPosition.x, minBounds.x, maxBounds.x);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, minBounds.y, maxBounds.y);

            // Smoothly move the camera towards the desired position
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Update the camera's position
            transform.position = smoothedPosition;
        }
    }
}

