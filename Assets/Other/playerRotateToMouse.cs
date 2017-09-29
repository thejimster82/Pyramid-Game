﻿using UnityEngine;
using System.Collections;

public class playerRotateToMouse : MonoBehaviour {
	public float speed = 4.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// LookAtMouse will cause an object to rotate toward the cursor, along the y axis.
	//
	// To use, drop on an object that should always look toward the mouse cursor.
	// Change the speed value to alter how quickly the object rotates toward the mouse.
	
	
	// speed is the rate at which the object will rotate


	public void Update () {
		// Generate a plane that intersects the transform's position with an upwards normal.
		/*
		Plane playerPlane = new Plane(Vector3.up, transform.position);
		
		
		// Generate a ray from the cursor position
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		// Determine the point where the cursor ray intersects the plane.
		// This will be the point that the object must look towards to be looking at the mouse.
		// Raycasting to a Plane object only gives us a distance, so we'll have to take the distance,
		//   then find the point along that ray that meets that distance.  This will be the point
		//   to look at.
		float hitdist = Mathf.Infinity;
		// If the ray is parallel to the plane, Raycast will return false.
		if (playerPlane.Raycast (ray, hitdist)) {
			// Get the point along the ray that hits the calculated distance.
			Vector3 targetPoint = ray.GetPoint(hitdist);
			// Determine the target rotation.  This is the rotation if the transform looks at the target point.
			float targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			// Smoothly rotate towards the target point.
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
			// Move the object forward.
			//transform.position += transform.forward * speed * Time.deltaTime;
		}
	*/}
}