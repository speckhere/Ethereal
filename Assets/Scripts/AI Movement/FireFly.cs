using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFly : MonoBehaviour
{
     public float speed;
     private Waypoints Wpoints;
     public Transform[] waypoints;

     private int waypointIndex;
     private float dist;

    void Start()
    {
       waypointIndex = 0;
       Wpoints = GameObject.FindGameObjectWithTag("FF-Waypoints").GetComponent<Waypoints>();
    }

   void Update()
    {

        if(Vector2.Distance(transform.position, Wpoints.waypoints[waypointIndex].position) < 0.1f)
        {
            IncreaseIndex();
        }
        Patrol();
    }


    void Patrol()
    {
       transform.position = Vector2.MoveTowards(transform.position, Wpoints.waypoints[waypointIndex].position, speed * Time.deltaTime);
    }

    void IncreaseIndex()
    {
        waypointIndex++;
        if(waypointIndex >= waypoints.Length)
        {
            waypointIndex = 0;
        }

    }
}
