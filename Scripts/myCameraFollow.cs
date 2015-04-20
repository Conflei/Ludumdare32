using UnityEngine;
using System.Collections;

public class myCameraFollow : MonoBehaviour {

	public Transform spaceship;

	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3(spaceship.transform.position.x + startPosition.x, spaceship.transform.position.y + startPosition.y, spaceship.transform.position.z + startPosition.z);
	}
}
