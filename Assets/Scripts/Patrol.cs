using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {
    public Transform[] patrolpoints;
    public float movespeed;
    private int currentPoint;
	// Use this for initialization
	void Start () {
        transform.position = patrolpoints[0].position;
        currentPoint = 0;

    }
	
	// Update is called once per frame
	void Update () {
		if(transform.position == patrolpoints[currentPoint % patrolpoints.Length].position)
        {
            currentPoint++;
            //transform.position = patrolpoints[currentPoint % patrolpoints.Length].position;
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolpoints[currentPoint % patrolpoints.Length].position, movespeed * Time.deltaTime);
	}
}
