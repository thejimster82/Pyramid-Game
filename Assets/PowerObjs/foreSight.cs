using UnityEngine;
using System.Collections;

public class foreSight : MonoBehaviour {
	public playerFOV fovScript;
	public powerInv inventoryScript;
	public enemyVisible visScript;
	// Use this for initialization
	void Start () {
		fovScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<playerFOV> ();
		visScript = GameObject.FindGameObjectWithTag ("endArea").GetComponent<enemyVisible> ();
		inventoryScript = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<powerInv>();
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			inventoryScript.currentVal = 3;
			inventoryScript.fillingSlot = true;
			inventoryScript.fillSlot ();
			gameObject.SetActive (false);
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
