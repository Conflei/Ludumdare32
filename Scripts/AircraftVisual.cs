using UnityEngine;
using System.Collections;

public class AircraftVisual : MonoBehaviour {

	public GameObject directionEngine;
	public float rotationSpeed;
	private AudioSource source;

	public float velocity;
	private float startVel;

	public Light accelerate;

	private GameController Controller;

	private bool accelerating;

	// Use this for initialization
	void Start () {
		startVel = velocity;
		accelerating = false;
		Controller = Camera.main.GetComponent<GameController>();
		source = this.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		//transform.position = directionEngine.transform.position;
		//transform.position+=transform.forward*-1*Time.deltaTime*velocity;
		this.GetComponent<Rigidbody>().AddForce(transform.forward*-1*Time.deltaTime*velocity);
		transform.eulerAngles = new Vector3(directionEngine.transform.eulerAngles.x*-1,directionEngine.transform.eulerAngles.y,this.transform.eulerAngles.z);
		transform.Rotate(0f,0f, Input.GetAxis("Horizontal")*Time.deltaTime*rotationSpeed);

		if(Input.GetKeyDown(KeyCode.S)){
			accelerating = true;
			accelerate.enabled = true;
			velocity = velocity * 4;
		}

		if(accelerating && !Controller.ConsumeNitrous()){
			accelerate.enabled = false;
			velocity = startVel;
			accelerating = false;
		}

		if(Input.GetKeyUp(KeyCode.S)){
			accelerate.enabled = false;
			velocity = startVel;
		}
	}

	public void OnTriggerEnter(Collider obj){
		if(obj.tag == "EnemyBullet"){
			Controller.Hit();
			source.Play();
			obj.tag = "Untagged";
			Destroy(obj.gameObject);
		}

		if(obj.tag == "Enemy"){
			//Controller.Die();
			Debug.Log("Enemy Chok");
		}

		if(obj.tag == "Load"){
			Controller.LoadTaken();
			Destroy(obj.gameObject);
		}

		if(obj.tag == "Goal"){
			Controller.Goal();
		}

	}
	

	public void OnCollisionEnter(Collision obj){
		if(obj.transform.tag == "Asteroid"){
			Controller.Die();
		}
	}
}
