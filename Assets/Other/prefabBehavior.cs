using UnityEngine;
using System.Collections;

public class prefabBehavior : MonoBehaviour {
	public GameObject doorNorth;
	public GameObject doorSouth;
	public GameObject doorEast;
	public GameObject doorWest;
	public GameObject poleNW;
	public GameObject poleNE;
	public GameObject poleSW;
	public GameObject poleSE;
	public GameObject Ceiling;
	public GameObject[] Pieces;
	public bool spawnLocation = false;
	public bool endLocation = false;
	public int xVar;
	public int zVar;

	public bool northPossible = true;
	public bool southPossible = true;
	public bool eastPossible = true;
	public bool westPossible = true;

	public bool enemyStartLocation = false;
	public int enemyAssign;
	public float Picker;

	public GameObject light1;

	//random objects
	public GameObject foreSight;
	public GameObject burnVision;
	public GameObject speedWalk;
	public GameObject omnivision;
	public GameObject[] instantiableObjects;
	public int objectNum = 4;
	public int objectSelector;
	void Awake ()
	{
		instantiableObjects = new GameObject[objectNum];
		instantiableObjects [0] = foreSight;
		instantiableObjects [1] = burnVision;
		instantiableObjects [2] = speedWalk;
		instantiableObjects [3] = omnivision;
	}


	// Use this for initialization
	void Start () 
	{
	Pieces = new GameObject[5];
	//	Pieces [0] = doorNorth;
		Picker = Random.value;
		if (Picker <= .1f) {
			light1.SetActive(true);
		}
		Picker = Random.value;
		if (Picker <= .1f && spawnLocation == false && endLocation == false) {
			Picker = Random.Range(0,objectNum-1);
			objectSelector = Mathf.RoundToInt (Picker);
			GameObject.Instantiate (instantiableObjects [objectSelector], new Vector3(transform.position.x,transform.position.y-4,transform.position.z), Quaternion.identity);

		}
	}
	
	// Update is called once per frame
	void Update () {
		if (doorNorth.activeSelf == false && doorEast.activeSelf == false) 
		{
			poleNE.SetActive(false);
		}
		if (doorNorth.activeSelf == false && doorWest.activeSelf == false) 
		{
			poleNW.SetActive(false);
		}
		if (doorSouth.activeSelf == false && doorEast.activeSelf == false) 
		{
			poleSE.SetActive(false);
		}
		if (doorSouth.activeSelf == false && doorWest.activeSelf == false) 
		{
			poleSW.SetActive(false);
		}
	}
}
