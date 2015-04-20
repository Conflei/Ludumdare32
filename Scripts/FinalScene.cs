using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalScene : MonoBehaviour {

	public Text textBox;
	
	public Image courtain;
	public Text textCourtain;
	public Text CPS;
	public GameObject humboldtPhoto;

	// Use this for initialization
	void Start () {
		StartCoroutine(BeginStory());
	}

	public IEnumerator BeginStory(){
		yield return StartCoroutine(FadeOut());

		yield return StartCoroutine(ShowTextWorker(textCourtain, "Spaceman: Alexis! Thank you so much! You saved us!" ));
		CPS.gameObject.SetActive(true);
		
		while(!Input.GetKey(KeyCode.Space)) yield return null;
		yield return new WaitForSeconds (.2f);
		CPS.gameObject.SetActive(false);
		yield return StartCoroutine(ShowTextWorker(textCourtain, "Alexis: No problem " ));
		CPS.gameObject.SetActive(true);

		int nails = PlayerPrefs.GetInt("Points"); 
		if(nails<31){

		while(!Input.GetKey(KeyCode.Space)) yield return null;
		yield return new WaitForSeconds (.2f);
		CPS.gameObject.SetActive(false);
		yield return StartCoroutine(ShowTextWorker(textCourtain, "Spaceman: What?!! Did you only bring "+nails+" screws?!" ));
		CPS.gameObject.SetActive(true);

			while(!Input.GetKey(KeyCode.Space)) yield return null;
			yield return new WaitForSeconds (.2f);
			CPS.gameObject.SetActive(false);
			yield return StartCoroutine(ShowTextWorker(textCourtain, "Alexis: We are totally lost... " ));
			CPS.gameObject.SetActive(true);

			yield return StartCoroutine(FadeIn());

		}else{

			while(!Input.GetKey(KeyCode.Space)) yield return null;
			yield return new WaitForSeconds (.2f);
			CPS.gameObject.SetActive(false);
			yield return StartCoroutine(ShowTextWorker(textCourtain, "Spaceman: Wow you brought "+nails+" screws and lots of supplies!, you are our savior!" ));
			CPS.gameObject.SetActive(true);

			while(!Input.GetKey(KeyCode.Space)) yield return null;
			yield return new WaitForSeconds (.2f);
			CPS.gameObject.SetActive(false);
			yield return StartCoroutine(ShowTextWorker(textCourtain, "Spaceman: Alexis, Congratulations, you are now a -Navigator Of The Celestial Vault-, that was your last test...." ));
			CPS.gameObject.SetActive(true);

			yield return StartCoroutine(FadeIn());

		}

		humboldtPhoto.SetActive(true);
		StartCoroutine(FadeOut());
	}
	
	public IEnumerator ShowTextWorker(Text text, string words){
		text.text = "";
		yield return new WaitForEndOfFrame();
		for(int i = 0; i<words.Length; i++){
			text.text += words[i];
			yield return new WaitForSeconds(0.06f);
		}
		yield return null;
	}

	public IEnumerator FadeIn(){
		float time = 1f;
		yield return new WaitForEndOfFrame ();
		courtain.color = new Color (0f, 0f, 0f, 0f);
		Color startColor = courtain.color;	
		Color endColor = new Color (startColor.r, startColor.g, startColor.b, 1f);
		yield return null;
		
		for (float t = 0f; t <= time; t += Time.deltaTime) {
			Color temp = Color.Lerp (startColor, endColor, t/time);
			courtain.color = temp;
			yield return new WaitForEndOfFrame();
		}
		courtain.color = endColor;
		yield return null;
	}
	
	public IEnumerator FadeOut(){
		float time = 1f;
		yield return new WaitForEndOfFrame();
		courtain.color = new Color(0f, 0f, 0f, 1f);
		Color startColor = courtain.color;	
		Color endColor = new Color (startColor.r, startColor.g, startColor.b, 0f);
		yield return null;
		
		for (float t = 0f; t <= time; t += Time.deltaTime) {
			Color temp = Color.Lerp (startColor, endColor, t/time);
			courtain.color = temp;
			yield return new WaitForEndOfFrame();
		}
		courtain.color = endColor;
		yield return null;
	}
}
