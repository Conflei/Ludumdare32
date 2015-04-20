using UnityEngine;
using System.Collections;

public class HangoverGun : MonoBehaviour {

	private GameObject target;
	
	public GameObject bullet;

	public float fireTime = 1f;

	private bool lockedTarget = false;

	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag("Player");
	}
	
	public void OnTriggerEnter(Collider player){
		if(player.tag == "Enemy") return;
		Debug.Log("Enter");
		if(player.tag == "Player"){
			lockedTarget = true;
			StartCoroutine(BeginFire());
		}
	}

	public void OnTriggerExit(Collider player){
		if(player.tag == "Enemy") return;
		Debug.Log("Exit");
		if(player.tag == "Player"){
			lockedTarget = false;
		}
	}

	public void Update(){
		this.transform.LookAt(target.transform.position);
	}

	public IEnumerator BeginFire(){

		while(lockedTarget){

			GameObject thisBullet = Instantiate(bullet, this.transform.position, this.transform.rotation) as GameObject;
			Destroy(thisBullet, 5f);
			yield return new WaitForSeconds(fireTime);

		}

	}
}
