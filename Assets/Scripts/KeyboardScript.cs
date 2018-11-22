using UnityEngine;
using System.Collections;

public class KeyboardScript: MonoBehaviour {
	
	public KeyCode[] codes;
	private KeyCode generatedCode;
	
	// Private Method to do the Generation
	private void doGeneration() {
		// Get a Random value
		int randomNum = Random.Range(0, codes.Length);
		
		// Store the code
		generatedCode = codes[randomNum];
	}
	
	// Use this for initialization
	void Start () {
		doGeneration();
	}
	
	// Update is called once per frame
	void Update () {
		// Check if the Generated key is hit
		if (Input.GetKeyDown(generatedCode)) {
			// TODO(jonah) - do something here
			Debug.Log("BINGO");
			doGeneration();
		}
	}
	
}