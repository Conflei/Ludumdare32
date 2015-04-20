using UnityEngine;
using System.Collections;

public class HangoverBullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine(Go());
	}

	public IEnumerator Go(){
		while(true){
			yield return null;
			this.gameObject.GetComponent<Rigidbody>().velocity=transform.TransformDirection( new Vector3(0f,0f,55f));
		}
	}

}
