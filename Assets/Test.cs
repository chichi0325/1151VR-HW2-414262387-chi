using UnityEngine;

public class PlayerPathMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform[] waypoints;

    private int currentTargetIndex = 0;
    private bool isFinished = false;

    void Update()
    {
        if (isFinished || waypoints.Length == 0) return;

        Vector3 targetPosition = waypoints[currentTargetIndex].position;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.05f)
        {
            transform.position = targetPosition;
            currentTargetIndex++;

            if (currentTargetIndex >= waypoints.Length)
            {
                isFinished = true;
            }
        }
    }
}