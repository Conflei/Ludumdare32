using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	private float recalTime = .5f;

	public GameObject missile;

	private bool shooting = false;

	public GameObject dropPosition;

	private GameController Controller;
	

	public void Shoot(){
		Controller = Camera.main.GetComponent<GameController>();
		Debug.Log("Shoot!");
		StartCoroutine(ShootWorker());
	}

	public IEnumerator ShootWorker(){
		if(!shooting && Controller.Shoot()){
			shooting = true;
			GameObject thisBullet = Instantiate(missile, this.transform.position, this.transform.rotation) as GameObject;
			this.transform.parent = this.gameObject.transform;
			iTween.MoveTo(thisBullet, iTween.Hash("position", dropPosition.transform.position, "easetype", iTween.EaseType.easeOutExpo, "time", .7f)); 
			//yield return new WaitForSeconds(.7f);
			thisBullet.GetComponent<Bullet>().Init(this.transform, 20f);
				yield return new WaitForSeconds(recalTime);
				shooting = false;
		}
	}
}
