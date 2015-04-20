using UnityEngine;
using System.Collections;

public class FollowMouse : MonoBehaviour {

	public GameObject engine;

	private float startZ;

	// Use this for initialization
	void Start () {
		startZ = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 upAxis = new Vector3(0,0,-1);
		Vector3 mouseScreenPosition = Input.mousePosition;
		//set mouses z to your targets
		mouseScreenPosition.z = transform.position.z;
		Vector3 mouseWorldSpace = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
		Debug.Log("Screen "+mouseScreenPosition+" World "+mouseWorldSpace);
		transform.position = new Vector3(mouseWorldSpace.x*-1, mouseWorldSpace.y*-1, startZ+engine.transform.position.z);

	}
}
