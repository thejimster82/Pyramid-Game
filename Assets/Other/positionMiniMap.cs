using UnityEngine;
using System.Collections;

public class positionMiniMap : MonoBehaviour {
	public areaLayout determiner;
	public Camera miniCam;
	// Use this for initialization
	void Start () {
		transform.position = new Vector3((areaLayout.levelSideLength-1)*4,areaLayout.levelSideLength*3,(areaLayout.levelSideLength-1)*4);
		miniCam.orthographicSize = areaLayout.levelSideLength * 4.125f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
