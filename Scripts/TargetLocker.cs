using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TargetLocker : MonoBehaviour {

	RaycastHit hitInfo;
	public GameObject targetPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.DrawLine(transform.position, targetPos.transform.position, Color.yellow);
		if(Physics.Linecast(transform.position, targetPos.transform.position, out hitInfo)){

			if(hitInfo.collider.tag == "Enemy"){
				this.GetComponent<Image>().color = new Color(1f, 0f,0f,.3f);
			}else{
				this.GetComponent<Image>().color = new Color(1f, 1f,1f,.3f);
			}
		}else{
			this.GetComponent<Image>().color = new Color(1f, 1f,1f,.3f);
		}
	}
}
