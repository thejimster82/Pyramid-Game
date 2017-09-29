using UnityEngine;
using System.Collections;

public class enemyPathing : MonoBehaviour {
	public areaLayout Layout;
	public GameObject enemy;
	public GameObject player;
	public enemyMovement moveStats;
	public bool spawned = false;

	// Use this for initialization
	void Start () {
		for(int i=0;i<Layout.enemyNumber;i++)
		{
			//Debug.Log (Layout.pathLocations[i,0].x + "," + Layout.pathLocations[i,0].z);
			GameObject instance = Instantiate(enemy,new Vector3(Layout.pathLocations[i,0].x,0.5f,Layout.pathLocations[i,0].z),Quaternion.identity) as GameObject;
			moveStats = instance.GetComponent<enemyMovement>();
			moveStats.enemyNum = i;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//if (spawned == false) {

		//	spawned = true;
		//}
	}
}
