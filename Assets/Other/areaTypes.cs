using UnityEngine;
using System.Collections;

public class areaTypes : MonoBehaviour {
	public areaLayout areaScript;
	public perAreaCharacteristics Stats;
//	public GameObject[] areas;
	public GameObject None;
	public GameObject SpawnArea;
	public GameObject Doorway1;
	public GameObject Doorway2;
	public GameObject Doorway3;
	public GameObject Doorway4;
	public GameObject OpenHall13;
	public GameObject OpenHall24;
	public GameObject BackEndWall1;
	public GameObject BackEndWall2;
	public GameObject BackEndWall3;
	public GameObject BackEndWall4;
	public GameObject StairsDown1;
	public GameObject StairsDown2;
	public GameObject StairsDown3;
	public GameObject StairsDown4;
	public GameObject StairsUp1;
	public GameObject StairsUp2;
	public GameObject StairsUp3;
	public GameObject StairsUp4;
	public GameObject TConnector1;
	public GameObject TConnector2;
	public GameObject TConnector3;
	public GameObject TConnector4;
	public GameObject ClosedSimpleRoom1;
	public GameObject ClosedSimpleRoom2;
	public GameObject ClosedSimpleRoom3;
	public GameObject ClosedSimpleRoom4;
	public GameObject OpenSimpleRoom13;
	public GameObject OpenSimpleRoom24;
	public GameObject FourWayRoom;
		/*areas:
	 *
	 *0 None
	 *1 Spawn Area
	 *2 Doorway 1
	 *3 Doorway 2
	 *4 Doorway 3
	 *5 Doorway 4
	 *6 Open Hall 1/3
	 *7 Open Hall 2/4
	 *8 Back End/Wall 1
	 *9 Back End/Wall 2
	 *10 Back End/Wall 3
	 *11 Back End/Wall 4
	 *12 Stairs Down 1
	 *13 Stairs Down 2
	 *14 Stairs Down 3
	 *15 Stairs Down 4
	 *16 Stairs Up 1
	 *17 Stairs Up 2
	 *18 Stairs Up 3
	 *19 Stairs Up 4
	 *20 T Connector 1
	 *21 T Connector 2
	 *22 T Connector 3
	 *23 T Connector 4
	 *24 Closed Simple Room 1
	 *25 Closed Simple Room 2
	 *26 Closed Simple Room 3
	 *27 Closed Simple Room 4
	 *28 Open Simple Room 1/3
	 *29 Open Simple Room 2/4
	 *30 Four Way Room
	 * */

	// Use this for initialization
	void Start () {
		//must generate dummy objects in the entire area that let it spawn anything or somehow tell it to do so
		/*
		foreach (GameObject area in areaScript.Areas)
		{
			if (Stats.Type == 0)
			{
	
			}
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
