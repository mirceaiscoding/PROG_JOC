using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Chase : MonoBehaviour
{

    // Tag of the target. Set in the Unity Editor. Defaults to Player
    public string targetTag = "Player";

    // Movement component of game object
    Movement movement;

    // Distance from target at which to stop chasing. Set in the Unity Editor. Defaults to 1
    public float stoppingDistance = 1f;

    // PATHFINDING

    // How close to be to a waypoint before moving to the next one. Set in Unity Editor. Defaults to 2
    public float nextWaypointDistance = 2f;
    
    // Path to follow (list of waypoints)
    Path path;

    // Index of the current waypoint
    int currentWaypoint = 0;

    // True if the final waypoint was reached
    bool reachedEndOfPath = false;

    // Seeker script of game object
    Seeker seeker;

    void Start()
    {
        // Get components
        seeker = GetComponent<Seeker>();
        movement = GetComponent<Movement>();

        // Calculate path at a specified time interval
        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath() 
    {
        if (seeker.IsDone()) 
        {
            // Find the target
            GameObject target = GameObject.FindGameObjectWithTag(targetTag);

            // Calculate path
            seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
        }
    }

    // Callback function when a path is calculated
    void OnPathComplete(Path p) 
    {
        if (!p.error) 
        {
            // Update the path to the newly generated one and set currentWaypoint to 0
            path = p;
            currentWaypoint = 0;
        }
    }

    void Update()
    {

        if (Vector2.Distance(transform.position, path.vectorPath[path.vectorPath.Count-1]) < stoppingDistance)
        {
            reachedEndOfPath = true;
            movement.Stop();
            return;
        }

        if (path == null) {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count) 
        {
            reachedEndOfPath = true;
            movement.Stop();
            return;
        } else {
            reachedEndOfPath = false;
        }

        // Move towards waypoint
        movement.MoveTowards(path.vectorPath[currentWaypoint]);

        // Check if the distance was reached and update the current waypoint
        float distanceToWaypoint = Vector2.Distance(transform.position, path.vectorPath[currentWaypoint]);

        if (distanceToWaypoint < nextWaypointDistance) 
        {
            currentWaypoint++;
        }
    }

}
