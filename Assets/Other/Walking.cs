using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Walking : MonoBehaviour {
	private float speed = 5;
	private float gravity = -30;
	private float verticalVelocity = 0;
	private float jumpHeight = 5;
	public Animator anim;
	public CharacterController controller;
	public GameObject modelObject;
	public GameObject[] ladders;
	public List<Collider> ladderColliders = new List<Collider> ();
	public bool gravityOn;
	public bool sneakMode = false;
	public float horizontal;
	public float vertical;
	public Color playerColor;
	public Renderer rend;
	public rotatePlayer ROT;
	// Use this for initialization
	void Awake ()
	{
		ladders = GameObject.FindGameObjectsWithTag("ladder");
		foreach (GameObject ladder in ladders)
		{

		ladderColliders.Add (ladder.GetComponent<Collider> ());

		}
		
		//foreach (GameObject respawn in respawns) {
		//	Instantiate(respawnPrefab, respawn.transform.position, respawn.transform.rotation);
		//}
		controller = gameObject.GetComponent<CharacterController> ();
		playerColor = GetComponent<Renderer>().material.color;
		rend = GetComponent<MeshRenderer>();
	}

	void Update()
		//FixedUpdate is called just before performing physics calculations//
	{
		if(Input.GetButton("Jump"))
		{
			sneakMode = true;
		}
		else
		{
			sneakMode = false;

		}
		if (sneakMode == false) {
			horizontal = Input.GetAxis ("Horizontal");
			vertical = Input.GetAxis ("Vertical");

		}
		if (sneakMode == true) {
			horizontal = Input.GetAxis ("Horizontal") * .7f;
			vertical = Input.GetAxis ("Vertical") * .7f;
			playerColor.a -= Time.deltaTime;
		} else {
			playerColor.a += 1.5f * Time.deltaTime;
		}

	//	if (gravityOn == true) 
	//	{
			verticalVelocity += gravity * Time.deltaTime;
	//	}
		Mathf.Clamp (verticalVelocity, -20, 1000);
		//if (Input.GetButtonDown ("Jump")) {
		//	verticalVelocity = Mathf.Sqrt (.1f * jumpHeight * -gravity);
		//	anim.SetTrigger( "Jump");
		//}
	

		
		Vector3 movement = Vector3.zero;
	//	Vector3 rotater = Vector3.zero;
		movement.x = horizontal * speed * Time.deltaTime;
		movement.y = verticalVelocity * speed * Time.deltaTime;
		movement.z = vertical * speed * Time.deltaTime;

		controller.Move (movement);
		controller.transform.rotation = ROT.targetRotation;
		Vector3 xzVelocity = controller.velocity;
		xzVelocity.y = 0;

		float currentSpeed = xzVelocity.magnitude;
		//anim.SetFloat ("speed", currentSpeed);
		//anim.SetBool ("Grounded", controller.isGrounded);
		if (currentSpeed > .1) {
		//	modelObject.transform.rotation = Quaternion.LookRotation (xzVelocity);

		
		//playerColor.a = Mathf.Clamp(playerColor.a,.75f,1f);
		}
		playerColor.a = Mathf.Clamp (playerColor.a, .7f,1f);
		rend.material.color = playerColor;
	}

		void OnTriggerStay(Collider other)
		{
		if (ladderColliders.Contains (other) && Input.GetButton ("Jump")) {
			gravityOn = false;
		//	Debug.Log ("COLLIDED");
		//	verticalVelocity = Mathf.Sqrt (.1f * jumpHeight * -gravity);
			verticalVelocity = Mathf.Sqrt (.12f * jumpHeight * -gravity);
			//anim.SetTrigger ("Climb");
		} else {
		//	gravityOn = true;
		}
		}
	void playerFade()
	{

	}

}
