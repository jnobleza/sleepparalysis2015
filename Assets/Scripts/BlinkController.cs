using UnityEngine;
using System.Collections;

public class BlinkController : MonoBehaviour {

	public SpriteRenderer blink_graphic;
	float alphaLevel;
	float countdown;
	float current;

	// Use this for initialization
	void Start () {
		alphaLevel = 0.0f;
		blink_graphic.color = new Color (1f, 1f, 1f, alphaLevel);
		countdown = 3f;
		current = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	//	if(Input.GetButtonDown ("KeyCode.Space")) {
	//		Flicker ();
	//	}
	}

	public void Flicker () {
		while (current <= countdown) {
			alphaLevel = 1.0f;
			blink_graphic.color = new Color (1f, 1f, 1f, alphaLevel);
			current += Time.deltaTime;
		}
		alphaLevel = 0.0f;
		blink_graphic.color = new Color (1f, 1f, 1f, alphaLevel);
		current = 0f;
		//alphaLevel = 1.0f;
		//blink_graphic.color = new Color (1f, 1f, 1f, alphaLevel);
		//alphaLevel = 0.0f;
		//blink_graphic.color = new Color (1f, 1f, 1f, alphaLevel);
	}
}
