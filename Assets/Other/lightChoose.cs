using UnityEngine;
using System.Collections;

public class lightChoose : MonoBehaviour {
	public Light[] sampleLight;
	public int Decider;
	public areaLayout layoutInfo;
	// Use this for initialization
	/*
	void Start () {
		sampleLight = new Light[areaLayout.levelSideLength*areaLayout.levelSideLength];
		sampleLight += (GameObject.FindGameObjectsWithTag ("extralight") as Light);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnPreRender()
	{
		if (Decider == 1)
		{
			foreach (Light lit in sampleLight)
			{
		lit.enabled = false;
			}
		}
		if (Decider == 2)
		{
			foreach (Light lit in sampleLight)
			{
				lit.enabled = true;
			}
		}
	}
	*/
}
