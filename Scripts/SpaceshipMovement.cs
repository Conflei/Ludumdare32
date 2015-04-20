using UnityEngine;
using System.Collections;

public class SpaceshipMovement : MonoBehaviour {

	public float rotationSpeed;

	public float velocity;

	private Rigidbody myRigidbody;

	public GameObject targetLock;

	public Gun myGun;

	// Use this for initialization
	void Start () {
		myRigidbody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void LateUpdate () {


		if(Input.GetKey(KeyCode.Mouse0)) myGun.Shoot();
	}
}
