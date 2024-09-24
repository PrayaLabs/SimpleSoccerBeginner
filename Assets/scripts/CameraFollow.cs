using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Reference to the football (player) object
    public Transform football;

    // Offsets for the camera's position
    public Vector3 offset;

    // Smoothing factor for smooth camera movement
    public float smoothSpeed = 0.125f;

    // References to the two goalposts
    public Transform goalPost1;
    public Transform goalPost2;

    // Boolean to check if camera should target a goal
    private bool isTargetingGoal = false;
    private Transform targetGoal;

    void LateUpdate()
    {
        // Calculate the desired camera position based on football position and offset
        Vector3 desiredPosition = football.position + offset;

        // Smoothly interpolate the camera's position to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Set the camera's position to the smoothed position
        transform.position = smoothedPosition;

        // If a goal is targeted, rotate the camera toward the goalpost
        if (isTargetingGoal && targetGoal != null)
        {
            RotateCameraTowardsGoal(targetGoal);
        }
        else
        {
            // Keep looking at the football if not targeting a goal
            transform.LookAt(football);
        }
    }

    // This method should be called when the ball enters the goal trigger
    public void OnBallGoal(string goalTag)
    {
        if (goalTag == "Goal1")
        {
            targetGoal = goalPost1;
            isTargetingGoal = true;
            Debug.Log("Goal1_scored");
        }
        else if (goalTag == "Goal2")
        {
            targetGoal = goalPost2;
            isTargetingGoal = true;
            Debug.Log("Goal2_scored");
        }
    }

    // Smoothly rotate the camera toward the selected goalpost
    void RotateCameraTowardsGoal(Transform goal)
    {
        // Calculate the desired rotation to look at the goalpost
        Quaternion targetRotation = Quaternion.LookRotation(goal.position - transform.position);

        // Smoothly interpolate the camera's rotation towards the goalpost
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothSpeed);
    }
}
