using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class cameraRayCast : MonoBehaviour 
{
	public Camera buttonCamera;
	public GameObject player;
	public bool gameInProgress = false;
	public Vector3 separation;
	public float UnitUser;
	public Vector3 separationUnit;
	public Vector3 playerGhostLoc;
	public Ray ray;
	public differentPerspective cameraDecider;
	// Update is called once per frame

	void Start()
	{
		separation = player.transform.position - buttonCamera.transform.position;
		UnitUser = (Mathf.Sqrt (Mathf.Pow (separation.x, 2) + Mathf.Pow (separation.y, 2) + Mathf.Pow (separation.z, 2)));
	//	separationUnit = new Vector3(separation.x / UnitUser, separation.y / UnitUser,separation.z/UnitUser);
	//	playerGhostLoc = buttonCamera.transform.position - separationUnit;
	}
	void Update () 
	{
	
		//if (cameraDecider.cameraType == 3) 
		//{
			
			//ray = new Ray(buttonCamera.transform.position, player.transform.position-buttonCamera.transform.position);
			Debug.DrawRay (buttonCamera.transform.position, player.transform.position - buttonCamera.transform.position, Color.red);
			RaycastHit[] hits;
			hits = Physics.RaycastAll (buttonCamera.transform.position, player.transform.position - buttonCamera.transform.position, UnitUser);
			for (int i=0; i< hits.Length; i++) 
			{
				RaycastHit hit = hits [i];
				//Debug.Log ("Hit");
				if (hit.collider.tag == "wallT" || hit.collider.tag == "roofT") 
				{
					hit.transform.SendMessage ("DimWall", SendMessageOptions.DontRequireReceiver);
						
						
					//record each hit.point in order then make the dog move towards the transform in orders
				}
			}
	}
}
