using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //Skrypt do zarz¹dzania ruchomymi blokakami 
    [SerializeField]
    private WayPointPath _waypointPath;
    [SerializeField]
    private float _speed;

    private int _targetWaypointIndex;
    private Transform _previousWaypoint;
    private Transform _targetWaypoint;
    private float _timeToTaypoint;
    private float elapsedTime;
     
    void Start()
    {
        TargetNextWaypoint();
    }

    
    void FixedUpdate()
    {
        elapsedTime += Time.deltaTime;
        float elapsePercentage = elapsedTime / _timeToTaypoint;
        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsePercentage);
        if(elapsePercentage >= 1)
        {
            TargetNextWaypoint();
        }
    }
    private void TargetNextWaypoint()
    {
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);

        elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToTaypoint = distanceToWaypoint / _speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        other.transform.SetParent(transform);
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.SetParent(null);
    }
}
