using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class powerInv : MonoBehaviour 
{
	// Use this for initialization
	public playerFOV visionScript;
	public static int slot1;
	public static int slot2;
	public static int slot3;
	public static bool slot1Full = false;
	public static bool slot2Full = false;
	public static bool slot3Full = false;
	public int currentVal = 0;
	public bool fillingSlot = false;
	public static Image img1;
	public static Image img2;
	public static Image img3;

	public Sprite burnSprite1;
	public Sprite omniSprite2;
	public Sprite foreSprite3;
	public Sprite UIMask;
	public GameObject powerKnob;
	public Sprite handleKnob;
	public enemyVisible visScript;
	public GameObject lastLight;

	void Start () 
	{
		visScript = GameObject.FindGameObjectWithTag ("endArea").GetComponent<enemyVisible> ();
		lastLight = GameObject.FindGameObjectWithTag ("lastLight");
		lastLight.SetActive (false);
		handleKnob = powerKnob.GetComponent<Image>().sprite;

			img1 = GameObject.Find ("Image (1)").GetComponent<Image> ();
			img2 = GameObject.Find ("Image (2)").GetComponent<Image> ();
			img3 = GameObject.Find ("Image (3)").GetComponent<Image> ();

		if (slot1 == 1) 
		{

			slot1Full = true;
			img1.sprite = burnSprite1;
		}
		if (slot1 == 2) 
		{
			img1.sprite = omniSprite2;
			slot1Full = true;
		}
		if (slot1 == 3) 
		{
			img1.sprite = foreSprite3;
			slot1Full = true;
		}



		if (slot2 == 1) 
		{

			slot2Full = true;
			img2.sprite = burnSprite1;
		}
		if (slot2 == 2) 
		{
			img2.sprite = omniSprite2;
			slot2Full = true;
		}
		if (slot2 == 3) 
		{
			img2.sprite = foreSprite3;
			slot2Full = true;
		}


		if (slot3 == 1) 
		{

			slot3Full = true;
			img3.sprite = burnSprite1;
		}
		if (slot3 == 2) 
		{
			img3.sprite = omniSprite2;
			slot3Full = true;
		}
		if (slot3 == 3) 
		{
			img3.sprite = foreSprite3;
			slot3Full = true;
		}
		
	}


















	// Update is called once per frame
	void Update () 
	{
		//1 is burnVision
		//2 is omniView
		//3 is foreSight
		if (Input.GetKeyDown("1")) 
		{
			if (slot1 != 0) 
			{
				img1.sprite = UIMask;
				visionScript.floatTimer = visionScript.timerInterval;
			}
			if (slot1 == 1) 
			{
				handleKnob = burnSprite1;
				visionScript.burnVis = true;
				slot1 = 0;
				slot1Full = false;

			}
			if (slot1 == 2) 
			{
				handleKnob = omniSprite2;
				visionScript.omniVis = true;
				slot1 = 0;
				slot1Full = false;
			}
			if (slot1 == 3) 
			{
				handleKnob = foreSprite3;
				visScript.foreSightOn = true;
				slot1 = 0;
				lastLight.SetActive (true);
				slot1Full = false;
			}

		}
		if (Input.GetKeyDown("2")) 
		{
			if (slot2 != 0) 
			{
				img2.sprite = UIMask;
				visionScript.floatTimer = visionScript.timerInterval;
			}
			if (slot2 == 1) 
			{
				handleKnob = burnSprite1;
				visionScript.burnVis = true;
				slot2 = 0;
				slot2Full = false;
			}
			if (slot2 == 2) 
			{
				handleKnob = omniSprite2;
				visionScript.omniVis = true;
				slot2 = 0;
				slot2Full = false;
			}
			if (slot2 == 3) 
			{
				handleKnob = foreSprite3;
				visScript.foreSightOn = true;
				slot2 = 0;
				lastLight.SetActive (true);
				slot2Full = false;
			}

		}
		if (Input.GetKeyDown("3")) 
		{
			if (slot3 != 0) 
			{
				img3.sprite = UIMask;
				visionScript.floatTimer = visionScript.timerInterval;
			}
			if (slot3 == 1) 
			{
				handleKnob = burnSprite1;
				visionScript.burnVis = true;
				slot3 = 0;
				slot3Full = false;
			}
			if (slot3 == 2) 
			{
				handleKnob = omniSprite2;
				visionScript.omniVis = true;
				slot3 = 0;
				slot3Full = false;
			}
			if (slot3 == 3) 
			{
				handleKnob = foreSprite3;
				visScript.foreSightOn = true;
				slot3 = 0;
				slot3Full = false;
				lastLight.SetActive (true);
			}
		}
	//	handleKnob = powerKnob.GetComponent<Image>().sprite;
	}




























	public void fillSlot()
	{
		if (slot1Full == false && fillingSlot == true) 
		{
			slot1 = currentVal;
			if (currentVal == 1) 
			{
				img1.sprite = burnSprite1;
			}
			if (currentVal == 2) 
			{
				img1.sprite = omniSprite2;
			}
			if (currentVal == 3) 
			{
				img1.sprite = foreSprite3;
			}
			slot1Full = true;
			fillingSlot = false;
		} else if (slot2Full == false && fillingSlot == true) 
		{
			slot2 = currentVal;
			if (currentVal == 1) 
			{
				img2.sprite = burnSprite1;
			}
			if (currentVal == 2) 
			{
				img2.sprite = omniSprite2;
			}
			if (currentVal == 3) 
			{
				img2.sprite = foreSprite3;
			}
			slot2Full = true;
			fillingSlot = false;
		} else if (slot3Full == false && fillingSlot == true) 
		{
			slot3 = currentVal;
			if (currentVal == 1) 
			{
				img3.sprite = burnSprite1;
			}
			if (currentVal == 2) 
			{
				img3.sprite = omniSprite2;
			}
			if (currentVal == 3) 
			{
				img3.sprite = foreSprite3;
			}
			slot3Full = true;
			fillingSlot = false;
		} else 
		{
			fillingSlot = false;
		}
		}
	}
