using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;
using System.Collections;

public class GameController : MonoBehaviour {

	public Text NailText;
	public Slider nitrousSlider;

	public GameObject leftLoad;
	public GameObject rightLoad;
	public GameObject centerLoad;

	public GameObject diePanel;

	private int nailCounter;
	private float nitrousCounter;

	private SepiaTone Sepia;
	private MotionBlur MotionBlur;

	private bool destroyed;

	private AircraftVisual Player;
	public Image Fade;

	// Use this for initialization
	void Start () {
		StartCoroutine(FadeOut());
		destroyed = false;
		nailCounter = 30;
		NailText.text = " Screws: "+nailCounter;
		Cursor.visible = false;
		nitrousCounter = 100f;
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<AircraftVisual>();
		Sepia = this.GetComponent<SepiaTone>();
		MotionBlur = this.GetComponent<MotionBlur>();
	}
	
	// Update is called once per frame
	public bool Shoot(){

		if(nailCounter>0){

			nailCounter--;
			NailText.text = " Screws: "+nailCounter;

			if(nailCounter<25){
				leftLoad.SetActive(false);
				if(nailCounter<15){
					rightLoad.SetActive(false);
					if(nailCounter<10) Sepia.enabled = true;
					if(nailCounter<5){
						centerLoad.SetActive(false);
						if(nailCounter<0){
							Debug.Log("Fin del juego");
						}
					}
				}
			}

			return true;
		}else{
			return false;
		}
		return true;
	}

	public void Hit(){
		if(destroyed) return;
		nailCounter -= 5;
		if(nailCounter<0) nailCounter = 0;
		NailText.text = " Screws: "+nailCounter;
		if(nailCounter<25){
			leftLoad.SetActive(false);
			if(nailCounter<15){
				rightLoad.SetActive(false);
				if(nailCounter<10) Sepia.enabled = true;
				if(nailCounter<5){
					centerLoad.SetActive(false);
					if(nailCounter<=0){
						Die();
					}
				}
			}
		}
	}
	public void Goal(){
		StartCoroutine(GoalWorker());
	}

	public IEnumerator GoalWorker(){
		PlayerPrefs.SetInt("Points", nailCounter);
		StartCoroutine(FadeIn());
		yield return new WaitForSeconds(1f);
		Application.LoadLevel("Final");
	}

	public void Die(){
		StartCoroutine(DieWorker());
	}

	public IEnumerator DieWorker(){
		Sepia.enabled = false;
		destroyed = true;
		diePanel.SetActive(true);
		Player.enabled = false;

		while (!Input.GetKey(KeyCode.Space)) yield return null;
		StartCoroutine(FadeIn());
		yield return new WaitForSeconds(1f);
		Application.LoadLevel("MainScene");
	}

	public IEnumerator FadeIn(){
		float time = 1f;
		yield return new WaitForEndOfFrame ();
		Fade.color = new Color (0f, 0f, 0f, 0f);
		Color startColor = Fade.color;	
		Color endColor = new Color (startColor.r, startColor.g, startColor.b, 1f);
		yield return null;
		
		for (float t = 0f; t <= time; t += Time.deltaTime) {
			Color temp = Color.Lerp (startColor, endColor, t/time);
			Fade.color = temp;
			yield return new WaitForEndOfFrame();
		}
		Fade.color = endColor;
		yield return null;
	}

	public IEnumerator FadeOut(){
		float time = 1f;
		yield return new WaitForEndOfFrame();
		Fade.color = new Color(0f, 0f, 0f, 1f);
		Color startColor = Fade.color;	
		Color endColor = new Color (startColor.r, startColor.g, startColor.b, 0f);
		yield return null;
		
		for (float t = 0f; t <= time; t += Time.deltaTime) {
			Color temp = Color.Lerp (startColor, endColor, t/time);
			Fade.color = temp;
			yield return new WaitForEndOfFrame();
		}
		Fade.color = endColor;
		yield return null;
	}

	public void LoadTaken(){

		nitrousSlider.value = 1f;
		nailCounter += 20;
		NailText.text = " Screws: "+nailCounter;
		if(nailCounter>5){
			centerLoad.SetActive(true);
			if(nailCounter>9) Sepia.enabled = false;
			if(nailCounter>15){
				rightLoad.SetActive(true);
				if(nailCounter>25){
					leftLoad.SetActive(true);
				}
			}
		}

	}

	public void Update(){


		if(Input.GetKey(KeyCode.S)){
			nitrousSlider.value -= 0.1f*Time.deltaTime;
			MotionBlur.enabled = true;
		}else{
			MotionBlur.enabled = false;
			if(nitrousSlider.value<1f){
				nitrousSlider.value +=0.2f*Time.deltaTime;
			}
		}

	}

	public void AddPiece(){

	}

	public bool ConsumeNitrous(){
		if(nitrousSlider.value>0.01f){
			return true;
		}else{
			return false;
		}
		return false;
	}

}
