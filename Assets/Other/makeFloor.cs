using UnityEngine;
using System.Collections;

public class makeFloor : MonoBehaviour {
	public GameObject floor;
	public areaLayout theLayout;
	// Use this for initialization
	void Start () {
		floor.transform.localScale = new Vector3 (areaLayout.levelSideLength * 8, .5f, areaLayout.levelSideLength * 8);
		Instantiate (floor, new Vector3 ((areaLayout.levelSideLength - 1) * 4, -.55f, (areaLayout.levelSideLength - 1) * 4), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
