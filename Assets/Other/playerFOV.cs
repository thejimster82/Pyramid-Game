using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class playerFOV : MonoBehaviour {
	public Camera buttonCamera;
	public int hitPointCount;
	private Vector3[] pathOrder;
	public GameObject player;
	public List<Ray> FOVs = new List<Ray> ();


	public int degree=-75;
	public Ray[] degreeModifier;
	public Ray[] vertDegreeModifier;
	public int[] degrees;
	public int[] vertdegrees;


	public Light playerLight;
	public Light playerLight2;
	public Light playerLight3;
	public bool omniVis = false;
	public bool burnVis = false;
	public bool effectOn = false;
	public bool NormalOff = true;
	public float floatTimer = 0f;
	public float timerInterval = 5f;
	public Slider powerSlider;

	// Use this for initialization
	void Start () {
		degrees = new int[150];
		vertdegrees = new int[150];
		degreeModifier = new Ray[150];
		vertDegreeModifier = new Ray[150];
		for (int i=0; i < 150; i+=5) 
		{
			degrees[i] = i;
		}
	//	for (int q=0; q < 150; q+=10) 
	//	{
	//		vertdegrees[q] = q;
	//	}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (floatTimer >= 0f) 
		{
			floatTimer -= Time.deltaTime;
		}
		if (burnVis == true) 
		{
			
			playerLight.color = new Color (1, 0, 0, .7f);
			playerLight2.color = new Color (1, 0, 0, .7f);
			playerLight3.color = new Color (1, 0, 0, .7f);
		}
		if (omniVis == true)
		{
			
			degrees = new int[360];
			vertdegrees = new int[360];
			degreeModifier = new Ray[360];
			vertDegreeModifier = new Ray[360];
			for (int i=0; i < 360; i+=5) 
			{
				degrees[i] = i;
			}
			effectOn = true;
			NormalOff = true;
			playerLight2.gameObject.SetActive (true);
			playerLight3.gameObject.SetActive (true);
			playerLight.spotAngle = 123;
		}
		if (floatTimer <= 0) 
		{
			omniVis = false;
			burnVis = false;
			degrees = new int[150];
			vertdegrees = new int[150];
			degreeModifier = new Ray[150];
			vertDegreeModifier = new Ray[150];
			for (int i=0; i < 150; i+=5) 
			{
				degrees[i] = i;
			}
			effectOn = false;
			playerLight2.color = new Color(0.5f,0.5f,0.5f,0.5f); 
			playerLight3.color = new Color(0.5f,0.5f,0.5f,0.5f); 
			playerLight.color = new Color(0.5f,0.5f,0.5f,0.5f); 
			NormalOff = false;
			playerLight2.gameObject.SetActive (false);
			playerLight3.gameObject.SetActive (false);
			playerLight.spotAngle = 150;
		}
		foreach (int i in degrees)
		{
//			foreach (int q in vertdegrees)
//			{
			if (omniVis == false) {
				if (i <= 75) {
					degreeModifier [i] = new Ray (player.transform.position, Quaternion.Euler (0, i, 0) * player.transform.forward);
					//vertDegreeModifier[i] = new Ray (player.transform.position,Quaternion.Euler(q,i,0)*player.transform.forward); ;
					Debug.DrawRay (player.transform.position, Quaternion.Euler (0, i, 0) * transform.forward*15f, Color.red);
					//Debug.DrawRay (player.transform.position, Quaternion.Euler(0,i,q)*transform.forward, Color.green);
				}
				if (i > 76) {
					degreeModifier [i] = new Ray (player.transform.position, Quaternion.Euler (0, i - 150f, 0) * player.transform.forward);
					Debug.DrawRay (player.transform.position, Quaternion.Euler (0, i - 150f, 0) * transform.forward*15f, Color.red);
					//	Debug.DrawRay (player.transform.position, Quaternion.Euler(0,i-150f,q-150f)*transform.forward, Color.green);
				}
			}
			if (omniVis == true) {
				if (i <= 180) {
					degreeModifier [i] = new Ray (player.transform.position, Quaternion.Euler (0, i, 0) * player.transform.forward);
					//vertDegreeModifier[i] = new Ray (player.transform.position,Quaternion.Euler(q,i,0)*player.transform.forward); ;
					Debug.DrawRay (player.transform.position, Quaternion.Euler (0, i, 0) * transform.forward*15f, Color.red);
					//Debug.DrawRay (player.transform.position, Quaternion.Euler(0,i,q)*transform.forward, Color.green);
				}
				if (i > 180) {
					degreeModifier [i] = new Ray (player.transform.position, Quaternion.Euler (0, i - 360f, 0) * player.transform.forward);
					Debug.DrawRay (player.transform.position, Quaternion.Euler (0, i - 360f, 0) * transform.forward*15f, Color.red);
					//	Debug.DrawRay (player.transform.position, Quaternion.Euler(0,i-150f,q-150f)*transform.forward, Color.green);
				}
			}
//			}
			RaycastHit hit;
			
			if (Physics.Raycast (degreeModifier[i], out hit, 15f)) {
				//Debug.Log ("Hit");
				//if (hit.collider.tag == "Enemy" ||hit.collider.tag == "endArea")
				//{
					hit.transform.SendMessage ("Visible", SendMessageOptions.DontRequireReceiver);
				//}

			
					
					//Instantiate(PathObject,hit.point,Quaternion.identity);
					
					//pathOrder[hitPointCount] = hit.point;
					//Debug.Log(pathOrder[hitPointCount]);
					//hitPointCount += 1;
					
					//record each hit.point in order then make the dog move towards the transform in orders
				}
			}
		powerSlider.value = floatTimer * .2f;
		}
	}
