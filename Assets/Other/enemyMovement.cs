using UnityEngine;
using System.Collections;

public class enemyMovement : MonoBehaviour 
{
	public areaLayout Layout;
	public bool backwardsOn = false;
	public Vector3 separation;
	public int enemyNum;
	public int pathLength;
	public float UnitUser;
	public Vector3 separationUnit;
	public int pathLocation = 0;
	public float speed = .1f;
	public int directionDecider=1;
	public int rememberPathLoc;
	public bool followPath = true;
	public enemyVisible VisionStats;
	public GameObject player;
	public bool inPursuit = false;


	// Use this for initialization

	void Start () 
	{
		pathLocation = 0;
		Layout = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<areaLayout>();
		pathLength = Layout.pathLength;
		SetMoveDirectionForward ();
		//Debug.Log (Vector3.Distance (transform.position, Layout.pathLocations[enemyNum, pathLocation+1]));
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		if (Time.timeScale > 0) {
			transform.position += separationUnit * speed;
			if (followPath == true) {
				if (backwardsOn == false) {
					if (Vector3.Distance (transform.position, Layout.pathLocations [enemyNum, pathLocation + 1]) <= 2f) {
						if (pathLocation + 1 == Layout.pathLength - 1) {
							pathLocation = pathLength;
							SetMoveDirectionBackward ();
							backwardsOn = true;
						} else {
							pathLocation += 1;
							SetMoveDirectionForward ();
						}
					}
				}
				if (backwardsOn == true) {
					if (Vector3.Distance (transform.position, Layout.pathLocations [enemyNum, pathLocation - 1]) <= 2f) {
						if (pathLocation - 1 == 0) {
							pathLocation = 0;
							SetMoveDirectionForward ();
							backwardsOn = false;
						} else {
							pathLocation -= 1;
							SetMoveDirectionBackward ();
						}
					}
				}
			}

			if (VisionStats.enemyIsVisible == true && followPath == true) {
				followPath = false;
				inPursuit = true;
			}
			if (inPursuit == true && VisionStats.enemyIsVisible == false) {
				SetMoveDirectionAttack ();
			}
			if (VisionStats.enemyIsVisible == true && inPursuit == true) {
				SetMoveDirectionRetreat ();
			}
			/*
			if (VisionStats.enemyIsVisible == false && inPursuit == true) 
			{
				SetMoveDirectionReturn ();
				if (Vector3.Distance (transform.position, Layout.pathLocations [enemyNum, pathLocation]) <= 2f) 
				{
					inPursuit = false;
					if (pathLocation == pathLength - 1) 
					{
						SetMoveDirectionBackward ();
					} else 
					{
						SetMoveDirectionForward ();
					}
					followPath = true;
				}
			}
			*/
		}

	}
	void SetMoveDirectionForward()
	{
		separation = (Layout.pathLocations [enemyNum, pathLocation+1] - Layout.pathLocations [enemyNum, pathLocation]);
		UnitUser = (Mathf.Sqrt (Mathf.Pow (separation.x, 2) + Mathf.Pow (separation.z, 2)));
		separationUnit = new Vector3(separation.x / UnitUser,0,separation.z / UnitUser);
		
	}
	void SetMoveDirectionBackward()
	{
		separation = (Layout.pathLocations [enemyNum, pathLocation-1] - Layout.pathLocations [enemyNum, pathLocation]);
		UnitUser = (Mathf.Sqrt (Mathf.Pow (separation.x, 2) + Mathf.Pow (separation.z, 2)));
		separationUnit = new Vector3(separation.x / UnitUser,0,separation.z / UnitUser);
		
	}
	void SetMoveDirectionAttack()
	{
		separation = (player.transform.position - transform.position);
		UnitUser = (Mathf.Sqrt (Mathf.Pow (separation.x, 2) + Mathf.Pow (separation.z, 2)));
		separationUnit = new Vector3(separation.x / UnitUser,0,separation.z / UnitUser);
	}
	void SetMoveDirectionRetreat()
	{
		
		separationUnit = new Vector3(0,0,0);
	}
	void SetMoveDirectionReturn()
	{
		separation = (Layout.pathLocations [enemyNum, pathLocation] - transform.position);
		UnitUser = (Mathf.Sqrt (Mathf.Pow (separation.x, 2) + Mathf.Pow (separation.z, 2)));
		separationUnit = new Vector3(separation.x / UnitUser,0,separation.z / UnitUser);
	}
}

/*
	 * 		if (pathLocation == Layout.pathLength-1) 
			{
				backwardsOn = true;
				pathLocation +=1;
				directionDecider = -1;
			}
			if (pathLocation == 0 && backwardsOn == true)
			{
				backwardsOn = false;
				directionDecider = 1;
			}
			if (backwardsOn == false && pathLocation+1 <= pathLength)
			{
				pathLocation += 1;
				SetMoveDirectionForward ();

			}
			if (backwardsOn == true && pathLocation-1 >= 0) 
			{
				pathLocation -= 1;
				SetMoveDirectionBackward ();

			}
*/

