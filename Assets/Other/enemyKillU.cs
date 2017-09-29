using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemyKillU : MonoBehaviour {
	public GameObject player;
	public Text deathText;
	public Text respawnText;
	public Button respawnButton;

	// Use this for initialization
	void Start () {
		deathText = GameObject.Find ("deathText").GetComponent<Text>();
		respawnButton = GameObject.Find ("respawnButton").GetComponent<Button>();
		respawnText = GameObject.Find ("respawnText").GetComponent<Text>();
		player = GameObject.Find ("Player");
		//respawnButton.IsInteractable = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Player")
		{
			respawnButton.interactable = true;
			Time.timeScale = 0;
			deathText.text = "You Lose";
			respawnText.text = "Retry?";
		//	respawnButton.gameObject.SetActive (true);
			//respawnButton.enabled 
		}
	}
}
