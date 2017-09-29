using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class spawnPlayer : MonoBehaviour {
	public areaLayout Layout;
	public GameObject camera1;
	public cameraFollow cameraScript;
	public bool Spawned = false;
	public GameObject spawnLocation;
	public GameObject endArea;
	public float timerMax = 1f;
	public float timer;
	public bool timesUp = false;
	public float timerMax2 = 1f;
	public float timer2;
	public GameObject pathMarker;
	// Use this for initialization

	void Start () {
		//Debug.Log (Layout.spawnIndicator.transform.position);
		GetComponent<BoxCollider>().isTrigger = true;
		timer2 = timerMax2;
	}
	
	// Update is called once per frame
	void Update () {
		timer2 -= Time.deltaTime;
		if (timer2 <= 0) {
			Instantiate(pathMarker,transform.position,Quaternion.identity);
			timer2 = timerMax2;
		}
		/*
		if (timesUp == false) {
			timer -= Time.deltaTime;
			if (timer<=0)
			{
				timesUp = true;
			}
		}
*/

		if (Spawned == false) {
			transform.position = GameObject.FindGameObjectWithTag ("spawnArea").transform.position;
			camera1.transform.position = transform.position + cameraScript.separation;

			Spawned = true;
		}
	}
	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "endArea") 
		{
			//timer = timerMax;
			//timesUp = false;
		//	Debug.Log ("collided");
			GetComponent<BoxCollider>().isTrigger = false;
			areaLayout.levelSideLength += 1;
			SceneManager.LoadScene(1);

		}
	}
}
