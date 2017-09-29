using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class areaLayout : MonoBehaviour {
	public List<GameObject> Areas = new List<GameObject> ();
	public Vector3 startPoint = new Vector3(30,4,0);
	public bool generating;
	public static int levelSideLength=4;
	public prefabBehavior Stats;
	public prefabBehavior checkedStats;
	public prefabBehavior NorthStats;
	public prefabBehavior EastStats;
	public prefabBehavior SouthStats;
	public prefabBehavior WestStats;
	public GameObject currentArea;
	public Vector3 currentPoint;
	public Vector3 secondaryCurrentPoint;
	//public GameObject edgeArea;
	public int pieceSize = 8;
	public int floorNumber = 3;
	public GameObject[,] generatedPrefabs;
	public float randDecider;
	public GameObject indicatorThing;
	public int enemyNumber = 0;

	public int[,] currentLocation;



	public Vector3 spawnLocation;
	public GameObject spawnIndicator;
	public bool spawnSet = false;


	public Vector3 endLocation;
	public GameObject endIndicator;
	public GameObject testIndicator;
	public bool endSet = false;

	public bool northPossible = true;
	public bool southPossible = true;
	public bool eastPossible = true;
	public bool westPossible = true;

	public bool searchingNow = true;

	public List<int> xPosition = new List<int> ();
	public List<int> zPosition = new List<int> ();
	public List<GameObject> beingChecked = new List<GameObject> ();
	public List<GameObject> tempChecked = new List<GameObject> ();
	public List<GameObject> alreadyChecked = new List<GameObject> ();

	
	public Vector3[,] pathLocations;
	public bool directionSetting = true;
	public int referenceX;
	public int referenceZ;
	public prefabBehavior referenceStats;
	public int pathLength;

	public bool differentLocations;


	//use one prefab with doors on all sides, put a script on it that references each door and then set them to be open or closed based on
	//their neighbors, use the data to make sure there is a path to the end from the spawn point

	public enum RoomType
	{
		Floor,
		FloorBack,
		FloorBackLeft
	}
	// Use this for initialization
	void Awake () 
	{
		differentLocations = false;
		pathLength = Mathf.RoundToInt (levelSideLength / 2);
		generatedPrefabs = new GameObject[levelSideLength, levelSideLength];
		pathLocations = new Vector3[levelSideLength*4,levelSideLength*4];
		//Areas.AddRange(GameObject.FindGameObjectsWithTag ("Area"));
		/*foreach(GameObject area in Areas)
		{
			//Debug.Log (area.name);
			if(area.name == "type0")
			{
					//	Stats.oneNeed.AddRange (0,1,2);
				//		Stats.twoNeed.AddRange(1);
				//		Stats.threeNeed.AddRange(1);
				//		Stats.fourNeed.AddRange(1);
				//		Stats.fiveNeed.AddRange(1);
				//		Stats.sixNeed.AddRange(1);
			}
		}
		*/

		generating = true;



		//generates blocks beneath and above
		for (int j=-1; j<floorNumber*(pieceSize+1); j+=pieceSize) 
		{
			//generates multiple floors
			if (j > -1 && j < pieceSize * floorNumber) 
			{
				startPoint += new Vector3 (0, pieceSize, 0);
				//Debug.Log (startPoint);

				//RUN 1: GENERATE AREA OF GIVEN SIZE
				for (int x=0; x<levelSideLength; x++) 
				{
					currentPoint = startPoint + new Vector3 (pieceSize * x, 0, 0);
			
					//Instantiate(currentArea,currentPoint,Quaternion.identity);
			
					//	generatedPrefabs[(int)currentPoint.x ,(int)currentPoint.y] = currentArea;
					//then in z direction
					for (int z=0; z<levelSideLength; z++) 
					{
						secondaryCurrentPoint = currentPoint + new Vector3 (0, 0, pieceSize * z);
				
				
						GameObject instance = Instantiate (currentArea, secondaryCurrentPoint, Quaternion.identity) as GameObject;
						generatedPrefabs [x, z] = instance;
						//		generatedPrefabs[(int)secondaryCurrentPoint.x,(int)secondaryCurrentPoint.y] = currentArea;
					}
				}
			}
		}





		//GENERATION 1: MAKE SPAWN, END
//generates spawn point
		randDecider = Random.Range (0, (levelSideLength - 1));
		spawnLocation.x = Mathf.Round (randDecider);
		randDecider = Random.Range (0, (levelSideLength - 1));
		spawnLocation.z = Mathf.Round (randDecider);

		GameObject spawnArea = generatedPrefabs [(int)spawnLocation.x, (int)spawnLocation.z];
		Stats = spawnArea.GetComponent<prefabBehavior> ();
		Stats.spawnLocation = true;

		Instantiate (spawnIndicator, pieceSize * spawnLocation, Quaternion.identity);





//generates end point
		while (differentLocations == false) 
		{
			randDecider = Random.Range (0, (levelSideLength - 1));
			endLocation.x = Mathf.Round (randDecider);
			randDecider = Random.Range (0, (levelSideLength - 1));
			endLocation.z = Mathf.Round (randDecider);
		
			if (endLocation.x != spawnLocation.x && endLocation.z != spawnLocation.z) 
			{
				differentLocations = true;
			}
		}

		GameObject endArea = generatedPrefabs [(int)endLocation.x, (int)endLocation.z];
		Stats = endArea.GetComponent<prefabBehavior> ();
		Stats.endLocation = true;

		Instantiate (endIndicator, pieceSize * endLocation, Quaternion.identity);




		//RUN 2: CREATE BOUNDARIES AND RANDOM WALLS
		for (int x = 0; x < levelSideLength; x++) 
		{
			for (int z = 0; z < levelSideLength; z++) 
			{
				GameObject currentArea = generatedPrefabs [x, z];
				Stats = currentArea.GetComponent<prefabBehavior> ();
				Stats.xVar = x;
				Stats.zVar = z;


				if (x == 0) 
				{
					Stats.doorWest.SetActive (true);
					Stats.westPossible = false;
				}
				if (x == (levelSideLength - 1)) 
				{
					Stats.doorEast.SetActive (true);
					Stats.eastPossible = false;
				}
				if (z == 0) 
				{
					Stats.doorSouth.SetActive (true);
					Stats.southPossible = false;
				}
				if (z == (levelSideLength - 1)) {
					Stats.doorNorth.SetActive (true);
					Stats.northPossible = false;
				}





				randDecider = Random.value;
				//Debug.Log (randDecider);
				if (randDecider <= .25f && randDecider > 0) 
				{
					Stats.doorNorth.SetActive (true);
					if (z < (levelSideLength - 1)) 
					{
						//	Instantiate(testIndicator, generatedPrefabs [x, z].transform.position,Quaternion.identity);
						GameObject NorthArea = generatedPrefabs [x, z + 1];
						NorthStats = NorthArea.GetComponent<prefabBehavior> ();

						NorthStats.doorSouth.SetActive (true);
						NorthStats.southPossible = false;
					}
					Stats.northPossible = false;

				}
				if (randDecider <= .50f && randDecider > .25f) 
				{
					Stats.doorEast.SetActive (true);
					if (x < (levelSideLength - 1)) 
					{
						//Instantiate(testIndicator, generatedPrefabs [x, z].transform.position,Quaternion.identity);
						GameObject EastArea = generatedPrefabs [x + 1, z];
						EastStats = EastArea.GetComponent<prefabBehavior> ();

						EastStats.doorWest.SetActive(true);
						EastStats.westPossible = false;
						//	Debug.Log ("West Checked");
					}
					Stats.eastPossible = false;
				}
				if (randDecider <= .75f && randDecider > .50f) 
				{
					Stats.doorWest.SetActive (true);
					if (x > 0) 
					{
						GameObject WestArea = generatedPrefabs [x - 1, z];
						WestStats = WestArea.GetComponent<prefabBehavior> ();

						WestStats.doorEast.SetActive(true);
						WestStats.eastPossible = false;
					}
					Stats.westPossible = false;
				}
				if (randDecider <= 1f && randDecider > .75f) 
				{
					Stats.doorSouth.SetActive (true);
					if (z > 0) 
					{
						GameObject SouthArea = generatedPrefabs [x, z - 1];
						SouthStats = SouthArea.GetComponent<prefabBehavior> ();

						SouthStats.doorNorth.SetActive(true);
						SouthStats.northPossible = false;
						
					}
					Stats.southPossible = false;
				}
			}
		}




















		//RUN 3: CONNECT PIECES, MAKE PATH FROM SPAWN TO END










		for (int x = 0; x < levelSideLength; x++) 
		{
			for (int z = 0; z < levelSideLength; z++) 
			{
				GameObject currentArea = generatedPrefabs [x, z];
				Stats = currentArea.GetComponent<prefabBehavior> ();
				if (Stats.spawnLocation == true) 
				{
					beingChecked.Add (currentArea);
					tempChecked.Add (currentArea);

					while (searchingNow == true) 
					{

						for (int xx = 0; xx < levelSideLength; xx++) 
						{
							for (int zz = 0; zz < levelSideLength; zz++) 
							{

								if (beingChecked.Contains (generatedPrefabs [xx, zz])) 
								{
									checkedStats = generatedPrefabs [xx, zz].GetComponent<prefabBehavior> ();
									//	prefabBehavior checkedStats = fab.GetComponent<prefabBehavior> ();

									if (checkedStats.endLocation == true) 
									{
										searchingNow = false;
										Debug.Log ("Path found");
										break;
									}

								
									


									if (checkedStats.northPossible == true && !alreadyChecked.Contains (generatedPrefabs [xx, zz + 1])) 
									{
										tempChecked.Add (generatedPrefabs [xx, zz + 1]);
										//Instantiate(indicatorThing,8*xx,0,8*(zz+1),Quaternion.identity);
										//Debug.Log("north thing added");
									}
									if (checkedStats.southPossible == true && !alreadyChecked.Contains (generatedPrefabs [xx, zz - 1])) 
									{
										tempChecked.Add (generatedPrefabs [xx, zz - 1]);

										//Debug.Log("south thing added");
									}
									if (checkedStats.eastPossible == true && !alreadyChecked.Contains (generatedPrefabs [xx + 1, zz])) 
									{
										tempChecked.Add (generatedPrefabs [xx + 1, zz]);

										//	Debug.Log("east thing added");
									}
									if (checkedStats.westPossible == true && !alreadyChecked.Contains (generatedPrefabs [xx - 1, zz])) 
									{
										tempChecked.Add (generatedPrefabs [xx - 1, zz]);

										//	Debug.Log("west thing added");
									}
									//Debug.Log ("before" + tempChecked.Count);
									tempChecked.Remove (generatedPrefabs [xx, zz]);
									alreadyChecked.Add (generatedPrefabs [xx, zz]);
									if (tempChecked.Count == 0) 
									{
										searchingNow = false;
										//Debug.Log ("no path");
										SceneManager.LoadScene (1);
									}
								//	Debug.Log ("after" + tempChecked.Count);

								}
							}
						}
						beingChecked.Clear ();
						beingChecked.AddRange (tempChecked);
					}
				}
			}
		}

		foreach (GameObject prefab in generatedPrefabs) 
		{
			Stats = prefab.GetComponent<prefabBehavior> ();
			if (Stats.doorEast.activeSelf == true && Stats.doorWest.activeSelf == true && Stats.doorNorth.activeSelf == true && Stats.doorSouth.activeSelf == true && Stats.endLocation == false && Stats.spawnLocation == false) 
			{
				prefab.SetActive(false);
			}
		}
		







		//RUN 4: TIME TO MAKE ENEMY PATHS
		/*number of enemies determined by sidelength +-1
		 * for every block out of generatedPrefabs, 100/sidelength% chance to start a path
		 * inside of that, path script
		 * path gets randomly chosen to go north,south,east,west, length of path is 1/2 sideLength
		 * each path is a single dimensional array of transforms, each one is placed in the array in order as it is created
		 * the enemy uses this array to cycle between the different points, or periodically stop based on a bool called pathing
		 * with a timer that turns it off or on that leaves them idle in random places for 5-10 seconds
		 *maybe different types of enemies move at different speeds through the path or will change directions sometimes 
		*/





		//DECIDE WHERE TO SPAWN ENEMIES
		while (enemyNumber < (pathLength)) 
		{
			for (int x = 0; x < levelSideLength; x++) 
			{
				for (int z = 0; z < levelSideLength; z++) 
				{
					GameObject currentArea = generatedPrefabs [x, z];
					Stats = currentArea.GetComponent<prefabBehavior>();
					if(currentArea.activeSelf == true && Stats.spawnLocation == false && Stats.enemyStartLocation == false)
					{
						randDecider = Random.value;
					//	Debug.Log (1f / levelSideLength);
						if (randDecider < (1f / levelSideLength) && enemyNumber < pathLength) 
						{
							Stats.enemyStartLocation = true;
							Stats.enemyAssign = enemyNumber;
							enemyNumber += 1;
							//Debug.Log ("IMPORTANT" + enemyNumber);
						}
					}
				}
			}
		}




		//GENERATE PATHS FROM SPAWN POINTS

		for (int x = 0; x < levelSideLength; x++) 
		{
			for (int z = 0; z < levelSideLength; z++) 
			{

				GameObject currentArea = generatedPrefabs [x, z];
				Stats = currentArea.GetComponent<prefabBehavior> ();
				if (Stats.enemyStartLocation == true)
				{
					referenceX = x;
					referenceZ = z;
					GameObject setArea = currentArea;
					for (int k = 0; k < pathLength; k++)
					{
						//Debug.Log (Stats.enemyAssign);
						//Debug.Log (k);
						pathLocations [Stats.enemyAssign, k] = new Vector3(setArea.transform.position.x, 0.5f,setArea.transform.position.z);
						//Instantiate(testIndicator,setArea.transform.position,Quaternion.identity);
						//Instantiate

						//Debug.Log (randDecider);

						while (directionSetting == true) 
						{
							referenceStats = setArea.GetComponent<prefabBehavior>();
							//Debug.Log(referenceX + "," + referenceZ);

							randDecider = Random.value;
							//Debug.Log (randDecider);
							if (randDecider <= .25f && referenceStats.northPossible == true)
							{
								setArea = generatedPrefabs [referenceX, referenceZ+1];
								referenceZ += 1;
								directionSetting = false;
								//break;

							}
							if (randDecider <= .50f && randDecider > .25f && referenceStats.eastPossible == true) 
							{

								setArea = generatedPrefabs [referenceX+1, referenceZ];
								referenceX += 1;
								directionSetting = false;
								//break;
							}
							if (randDecider <= .75f && randDecider > .50f && referenceStats.westPossible == true) 
							{
								setArea = generatedPrefabs [referenceX-1, referenceZ];
								referenceX -= 1;
								directionSetting = false;
								//break;
							}
							if (randDecider <= 1f && randDecider > .75f && referenceStats.southPossible == true) 
							{
								setArea = generatedPrefabs [referenceX, referenceZ-1];
								referenceZ -= 1;
								directionSetting = false;
								//break;
							}


						}

						directionSetting = true;

					}
					Debug.Log ("one done");
				}
			}
		}


	}

				




	// Update is called once per frame
	void Update () {
	
	}
}
