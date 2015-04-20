using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HangoverBehaviour : MonoBehaviour {

	public float velocity = 20f;
	public Slider healthBar;
	private int HP;
	public GameObject load;

	private GameObject Player;

	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
		HP = 2;
		healthBar.gameObject.SetActive(false);
		//StartCoroutine(BeginMovement());
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.transform.position.z<this.transform.position.z){
			Destroy(this.transform.parent.gameObject);
		}
	}

	public void OnTriggerEnter(Collider obj){
		if(obj.tag == "Weapon") return;

		if(obj.tag == "Bullet"){
			if(HP>0){
				healthBar.gameObject.SetActive(true);
				healthBar.value = healthBar.value - 0.33f;
				HP = HP - 1;
			}else{
				Instantiate(load, this.transform.position, Quaternion.identity);

				Destroy(this.transform.parent.gameObject);
				Debug.Log("Soltar Carga y destruir");
			}
		}
	}

	public IEnumerator BeginMovement(){

		while(true){
			this.GetComponent<Rigidbody>().AddForce(Vector3.forward*velocity*Time.deltaTime);
			yield return new WaitForEndOfFrame();
		}
		yield return null;

	}
}
