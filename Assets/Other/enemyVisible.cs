using UnityEngine;
using System.Collections;

public class enemyVisible : MonoBehaviour {
	//public Color newColor;
	public float Timer;
	public float TimerInterval = 5f;
	public Color EnemyColor;
	public bool enemyIsVisible;
	public Renderer rend;
	public GameObject player;
	public enemyMovement moveScript;
	public bool iAmEnemy = false;
	public bool foreSightOn;
	public bool alive = true;
	public playerFOV fieldOfViewScript;
	// Use this for initialization
	void Awake () {
		enemyIsVisible = false;
		EnemyColor = GetComponent<Renderer>().material.color;
		rend = GetComponent<MeshRenderer>();
		player = GameObject.FindGameObjectWithTag ("Player");
		fieldOfViewScript = player.GetComponent<playerFOV> ();
	}
	
	// Update is called once per frame
	void Update () {
		


		if (alive == true || iAmEnemy == false) {
			//Timer -= Time.deltaTime;
			enemyIsVisible = false;

			if (enemyIsVisible == false) {
				if (EnemyColor.a > 0) {
					EnemyColor.a -= 1.5f * Time.deltaTime;
				}
				if (EnemyColor.a < .1f) {
					rend.enabled = false;
				}

			}
			if (foreSightOn == true) {
				rend.enabled = true;
				EnemyColor.a = 1;
			}
			EnemyColor.a = Mathf.Clamp (EnemyColor.a, 0, 1);
			rend.material.color = EnemyColor;
	
			if (Vector3.Distance (transform.position, player.transform.position) <= 2) {
				if (iAmEnemy == true) {
					moveScript.speed = .03f;
				}
				if (EnemyColor.a < 1) {
					rend.enabled = true;
					EnemyColor.a += 3.0f * Time.deltaTime;
				}
			} else {
				if (iAmEnemy == true) {
					moveScript.speed = .07f;
				}
			}
			//Debug.Log (EnemyColor.a);
		} else
		{
			if (gameObject.activeSelf == true) 
			{
				EnemyColor.a -= 1.5f * Time.deltaTime;
				rend.material.color = EnemyColor;
				if (EnemyColor.a <= 0) 
				{
					gameObject.SetActive (false);
				}
			}
		}

	}

	public void Visible()
	{
		//Debug.Log (gameObject.name);
		//Debug.Log ("Visible???");
		if (EnemyColor.a < 1) 
		{
			rend.enabled = true;
			EnemyColor.a += 3.0f*Time.deltaTime;
		}
		enemyIsVisible = true;
		//Timer = TimerInterval;
		//Material EnemyColor = GetComponent<Material>();
		//EnemyColor.color = newColor;
	//	newColor.a += Mathf.Lerp (0, 255, .5f);
		if (fieldOfViewScript.burnVis == true) 
		{
			alive = false;
		}
	}
}

