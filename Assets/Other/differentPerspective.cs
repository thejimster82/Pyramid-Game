using UnityEngine;
using System.Collections;

public class differentPerspective : MonoBehaviour {
	public int cameraType = 3;
	public Camera firstP;
	public Camera thirdP;
	// Use this for initialization
	void Start () {
		//cameraType 1 is First Person;
		//cameraType 3 is Third Person;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.C))
	    {
			Debug.Log ("viewSwitch");
			if(cameraType == 3)
			{
				cameraType = 1;
				firstP.enabled = true;
				thirdP.enabled = false;
			}
			if(cameraType == 1)
			{
				cameraType = 3;
				firstP.enabled = false;
				thirdP.enabled = true;
			}
		}
	
	}
}
