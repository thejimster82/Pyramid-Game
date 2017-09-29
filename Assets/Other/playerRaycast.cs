using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class playerRaycast : MonoBehaviour 
{
	public Camera buttonCamera;
	public int hitPointCount;
	private Vector3[] pathOrder;
	public GameObject player;
	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
		void Update () 
		{
			//	Mathf.Clamp (player.transform.position.z, 0, 0.1);
			//	bool useMouseInput = false;
			
			//#if UNITY_EDITOR
			//		useMouseInput = true;
			/*#endif

		for (int i = 0; i < Input.touchCount; i++)
		{
			Touch currentTouch = Input.touches[i];

			if ( currentTouch.phase == TouchPhase.Began || currentTouch.phase == TouchPhase.Moved || currentTouch.phase == TouchPhase.Stationary )
			{
				Ray ray = buttonCamera.ScreenPointToRay( currentTouch.position );
				RaycastHit hit;

				if ( Physics.Raycast( ray, out hit, Mathf.Infinity ) )
				{
					hit.transform.SendMessage( "MarkPath", SendMessageOptions.DontRequireReceiver );
				}

			}
		}
		*/	
			if (Input.GetMouseButton( 0 ) )
			{
				Ray ray = buttonCamera.ScreenPointToRay( Input.mousePosition );
				RaycastHit hit;
				
				if ( Physics.Raycast( ray, out hit, Mathf.Infinity ) )
				{
					//Debug.Log ("Hit");
					if (hit.collider.tag == "playField" || hit.collider.tag == "DangerZone")
					{
						hit.transform.SendMessage( "MarkPath", SendMessageOptions.DontRequireReceiver );
						
						//Instantiate(PathObject,hit.point,Quaternion.identity);
						
						//pathOrder[hitPointCount] = hit.point;
						//Debug.Log(pathOrder[hitPointCount]);
						//hitPointCount += 1;
						
						//record each hit.point in order then make the dog move towards the transform in orders
					}
				}
			}
		}
}
