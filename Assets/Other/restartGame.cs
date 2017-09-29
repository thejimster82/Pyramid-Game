using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class restartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartNow()
	{
		areaLayout.levelSideLength = 4;
		SceneManager.LoadScene (1);
		Time.timeScale = 1;
	}
}
