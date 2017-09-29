using UnityEngine;
using System.Collections;

public class WalkScript : MonoBehaviour {
	//float Speed = 50;
	Animator anim;
	//int walkHash = Animator.StringToHash("Walk");
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		float move = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Speed", move);

	//	AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo (0);
	//	if(Input.GetKeyDown(KeyCode.W) && stateInfo.nameHash == walkHash)
	//	{
	//		anim.SetTrigger (walkHash);
	//	}
	}
}
