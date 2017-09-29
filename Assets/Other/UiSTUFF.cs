using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UiSTUFF : MonoBehaviour {
	public Text levelText;
	public areaLayout layoutInfo;
	// Use this for initialization
	void Start () {
		levelText.text = ("Level" + (areaLayout.levelSideLength - 3));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
