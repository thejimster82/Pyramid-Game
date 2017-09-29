using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {
	public GameObject player;
	public Vector3 separation;
	// Use this for initialization
	void Awake () {
		separation = transform.position -= player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + separation;
		//transform.rotation += player.transform.rotation;
	}
}
