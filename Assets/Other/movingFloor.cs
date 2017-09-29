using UnityEngine;
using System.Collections;

public class movingFloor : MonoBehaviour {
	public GameObject endPoint;
	public GameObject startPoint;
	public bool backwardsOn;
	// Use this for initialization
	void Start () {
		backwardsOn = false;
	}
	
	// Update is called once per frame
	void Update () {
	if (transform.position.x <= endPoint.transform.position.x && backwardsOn == false)
			transform.position = new Vector3 (transform.position.x + 10*Time.deltaTime,transform.position.y,transform.position.z);
	if (transform.position.x >= endPoint.transform.position.x)
			backwardsOn = true;
	
	if (backwardsOn == true)
			transform.position = new Vector3 (transform.position.x - 10*Time.deltaTime,transform.position.y,transform.position.z);
	if (transform.position.x <= startPoint.transform.position.x)
			backwardsOn = false;
	}
}
