using UnityEngine;
using System.Collections;

public class omniVision : MonoBehaviour {
	public playerFOV fovScript;
	public powerInv inventoryScript;
	// Use this for initialization
	void Start () {
		fovScript = GameObject.FindGameObjectWithTag ("Player").GetComponent<playerFOV> ();
		inventoryScript = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<powerInv>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			inventoryScript.currentVal = 2;
			inventoryScript.fillingSlot = true;
			inventoryScript.fillSlot ();
			gameObject.SetActive (false);
		}
	}
}
