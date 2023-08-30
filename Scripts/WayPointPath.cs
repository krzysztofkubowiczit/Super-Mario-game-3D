using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointPath : MonoBehaviour
{
    //Skrypt do zarz¹dzania œciê¿k¹ Waypoint dla obiektów ruchomych
    public Transform GetWaypoint(int waypointIndex)
    {
        return transform.GetChild(waypointIndex);
    }
    public int GetNextWaypointIndex(int currentWaypointIndex)
    {
        int nextWaypointIndex = currentWaypointIndex + 1;
        if(nextWaypointIndex == transform.childCount)
        {
            nextWaypointIndex = 0;
        }
        return nextWaypointIndex;
    }
}
