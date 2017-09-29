using UnityEngine;
using System.Collections;

public class rotatePlayer : MonoBehaviour 
{
	public Camera buttonCamera;
	public Transform playerPos;
	public float rotationSpeed=1f;
	public float hitDist = 0f;
	public Quaternion targetRotation;
	public GameObject playerPlane;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		//playerPos = transform.position;
	//	playerPlane.transform.position = transform.position;
		if (Time.timeScale > 0)
		{
	
			Ray ray = buttonCamera.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			//Debug.DrawRay (Input.mousePosition,Quaternion.Euler(0,0,0),Color.green);
			//Debug.DrawRay (player.transform.position, Quaternion.Euler(0,i,0)*transform.forward, Color.red);
			if (Physics.Raycast (ray, out hit, Mathf.Infinity))
 				{		//if (Physics.RaycastAll (ray, out hit, Mathf.Infinity) && hit.transform.tag != "wallT")
				//		Debug.Log ("HitPlane");
				//targetRotation = Quaternion.LookRotation (new Vector3(hit.point.y - transform.position.y,0,hit.point.z - transform.position.z));
				targetRotation = Quaternion.LookRotation (new Vector3 (hit.point.x - transform.position.x, 0, hit.point.z - transform.position.z));
				//transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
				}
			/*if ( Physics.Raycast( ray, out hit, Mathf.Infinity ) )
			{
			//Debug.Log ("Hit");
			if (hit.collider.tag == "GPlane")
			{
			hit.transform.SendMessage( "SetRot", SendMessageOptions.DontRequireReceiver );
			//record each hit.point in order then make the dog move towards the transform in orders
			*/
		}
	}
}
