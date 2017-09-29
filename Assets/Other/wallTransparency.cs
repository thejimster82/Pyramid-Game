using UnityEngine;
using System.Collections;

public class wallTransparency : MonoBehaviour {
	//public Color newColor;
	public float Timer = 0;
	public float TimerInterval = .1f;
	public Color WallColor;
	public bool wallIsVisible = false;
	public Renderer rend;
//	public bool increasing;
//	public bool decreasing;
	// Use this for initialization
	void Start () {
		WallColor = GetComponent<Renderer>().material.color;
		rend = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		while (Timer > 0) 
		{
			Timer -= Time.deltaTime;
		}
		if (Timer < 0) 
		{
			WallColor.a += 2.0f*Time.deltaTime;
			WallColor.a = Mathf.Clamp (WallColor.a, 0, 1);
			rend.material.color = WallColor;
		}
		
	//	Debug.Log (WallColor.a);
		
	}
	void DimWall()
	{
		Debug.Log ("DIMMEBABY");
		if (WallColor.a > 0) 
		{
		//	rend.enabled = true;
			WallColor.a -= 3.0f*Time.deltaTime;
		}
	//	wallIsVisible = true;
	//	decreasing = true;
		Timer = TimerInterval;
		//Timer = TimerInterval;
		//Material WallColor = GetComponent<Material>();
		//WallColor.color = newColor;
		//	newColor.a += Mathf.Lerp (0, 255, .5f);
		
	}
}
