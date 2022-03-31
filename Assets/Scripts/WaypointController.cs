using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWayPointIndex = 0;
    private float minDistance = 0.1f;
    private float lastwaypointindex;
    private int boost;

    public enum DiffMode { Easy, Normal, Hard};
    [Header("AI Difficulty")]
    public DiffMode diffMode;

    private float movementSpeed;
    private float rotationSpeed = 2.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //Changes movement speed based on difficulty selected
        switch (diffMode)
        {
            case DiffMode.Easy:
                movementSpeed = 5;
                break;
            case DiffMode.Normal:
                movementSpeed = 8;
                break;
            case DiffMode.Hard:
                movementSpeed = 10;
                break;
        }

        boost = Random.Range(5, 10);
        lastwaypointindex = waypoints.Count - 1;
        targetWaypoint = waypoints[targetWayPointIndex];
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Movement multiplier
        float movementStep = movementSpeed * boost * Time.deltaTime;

        //gives distance to next waypoint
        float distance = Vector3.Distance(transform.position, targetWaypoint.position);

        // Rotates the car
        Vector3 directionToTarget = targetWaypoint.position - transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(directionToTarget);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotationToTarget, rotationSpeed); // makes the rotation smooth

        //checks the distance
        CheckDistanceToWaypoint(distance);

        //moves computer
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movementStep);
    }

    void CheckDistanceToWaypoint(float distance)
    {
        if(distance <= minDistance)
        {
            targetWayPointIndex++;
            UpdateTargetWaypoint();
        }
    }

    void UpdateTargetWaypoint()
    {
        if(targetWayPointIndex > lastwaypointindex)
        {
            targetWayPointIndex = 0;
        }

        targetWaypoint = waypoints[targetWayPointIndex];
    }
}
