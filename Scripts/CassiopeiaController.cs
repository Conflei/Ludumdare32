using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CassiopeiaController : MonoBehaviour {

	public Text textBox;

	public Image courtain;
	public Text textCourtain;
	public Text CPS;
	public Text humboldtname;

	public GameObject instructions;
	// Use this for initialization
	void Start () {
		StartCoroutine(MessageArrived());
	}

	public void ShowText(Text text, string pal){
		StartCoroutine(ShowTextWorker(text, pal));
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

	public IEnumerator MessageArrived(){
		yield return StartCoroutine(ShowTextWorker(textCourtain, "VSS Humboldt-1: 19 / 04 / 2945" ));
		CPS.gameObject.SetActive(true);

		while(!Input.GetKey(KeyCode.Space)) yield return null;
		yield return new WaitForSeconds (.2f);
		CPS.gameObject.SetActive(false);
		yield return StartCoroutine(ShowTextWorker(textCourtain, "VSS Humboldt-1: New Message Arrived from V-SC Cassiopeia" ));
		CPS.gameObject.SetActive(true);

		while(!Input.GetKey(KeyCode.Space)) yield return null;
		yield return new WaitForSeconds (.2f);
		CPS.gameObject.SetActive(false);
		yield return StartCoroutine(ShowTextWorker(textCourtain, "...Transmitting..." ));
		CPS.gameObject.SetActive(true);


		while(!Input.GetKey(KeyCode.Space)) yield return null;
		yield return new WaitForSeconds (.2f);
		CPS.gameObject.SetActive(false);
		humboldtname.gameObject.SetActive(false);
		textCourtain.gameObject.SetActive(false);
		yield return StartCoroutine(FadeOut());
		StartCoroutine(BeginTransmition());
	}

	public IEnumerator BeginTransmition(){
		string prefix = "V-SC Cassiopeia: ";
		textBox.text = prefix+"...Transmitting...";
		while(!Input.GetKey(KeyCode.Space)) yield return null;
		yield return new WaitForSeconds (.2f);

		textBox.text = prefix+"S.O.S ..... Here V-SC Cassiopeia S.O.S....";
		while(!Input.GetKey(KeyCode.Space)) yield return null;
		yield return new WaitForSeconds (.2f);

		
		textBox.text = prefix+"We ran out of supplies and screws, also, we are surrounded by enemy ships... S.O.S...";
		while(!Input.GetKey(KeyCode.Space)) yield return null;
		yield return new WaitForSeconds (.2f);

		
		textBox.text = prefix+"We know you are out of missiles, you must defend yourself with something else, such as shooting screws...";
		while(!Input.GetKey(KeyCode.Space)) yield return null;
		yield return new WaitForSeconds (.2f);

		
		textBox.text = prefix+"We know that enemy ships have supplies and screws, you can destroy them and steal their loads!.";
		while(!Input.GetKey(KeyCode.Space)) yield return null;
		yield return new WaitForSeconds (.2f);

		textBox.text = prefix+"Come fast...";
		while(!Input.GetKey(KeyCode.Space)) yield return null;
		yield return new WaitForSeconds (.2f);
	
		StartCoroutine(FadeIn());
		yield return new WaitForSeconds(1f);
		instructions.SetActive(true);
		yield return new WaitForEndOfFrame();
		StartCoroutine(FadeOut());

		while(!Input.GetKey(KeyCode.Space)) yield return null;
		yield return new WaitForSeconds(.2f);

		StartCoroutine(FadeIn());
		yield return new WaitForSeconds(1f);
		Application.LoadLevel("MainScene");

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
