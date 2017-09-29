using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class perAreaCharacteristics : MonoBehaviour {
	public areaLayout areaScript;
	public int Type;
	public int[,,] areaLocale;
	public string Title;
	//One = front
	//Two = right
	//Three = back
	//Four = left
	//Five = top
	//Six = bottom	
	//Necessary types for each Area side
	public List<int> oneNeed = new List<int> ();
	public List<int> twoNeed = new List<int> ();
	public List<int> threeNeed = new List<int> ();
	public List<int> fourNeed = new List<int> ();
	public List<int> fiveNeed = new List<int> ();
	public List<int> sixNeed = new List<int> ();

	/*public int[] oneNeed;
	public int[] twoNeed;
	public int[] threeNeed;
	public int[] fourNeed;
	public int[] fiveNeed;
	public int[] sixNeed;
*/
	// Use this for initialization
	void Start () {

/*		oneNeed = new int[areaScript.Areas.Count];
		twoNeed = new int[areaScript.Areas.Count];
		threeNeed = new int[areaScript.Areas.Count];
		fourNeed = new int[areaScript.Areas.Count];
		fiveNeed = new int[areaScript.Areas.Count];
		sixNeed = new int[areaScript.Areas.Count];
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
