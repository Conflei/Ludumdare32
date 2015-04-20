using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float velocity = 1f;

	private Rigidbody nailRigidbody;

	public void Start(){
		nailRigidbody = this.GetComponent<Rigidbody>();
	}

	public void Init(Transform gun,float vel = 1f){
		StartCoroutine(Go(vel, gun));
		Destroy(this.gameObject, 4.5f);
	}

	public IEnumerator Go(float vel, Transform parent){
		while(true){
			yield return null;
			nailRigidbody.velocity=transform.TransformDirection( new Vector3(vel*-1,0f,0f));
		}
		yield return new WaitForSeconds(1f);

	}
}
