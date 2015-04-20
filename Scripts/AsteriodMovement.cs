using UnityEngine;
using System.Collections;

public class AsteriodMovement : MonoBehaviour {

	private Vector3 movementAssigned;

	private float rotationSpeed;

	// Use this for initialization
	void Start () {
	
		movementAssigned = new Vector3(Random.Range(-2f,2f), Random.Range(-2f,2f),Random.Range(-2f,2f));
		rotationSpeed = Random.Range(1f,2f);
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate(movementAssigned*rotationSpeed*Time.deltaTime);
			
	}
}
