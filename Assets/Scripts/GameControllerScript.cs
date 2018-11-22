using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {

	public float timeLeft = 5f;
	public bool timeOut = false;
	public int numCycles = 12;
	public int currentCycles = 0;
	public GameObject blinkResize;
	public float maxSizeBar = 640;
	public float currentSizeBar = 0;
	public GameObject creature;
    private bool reachZero = false;
    public GameObject GlobalTimer;
    private int doingGoodCounter = 0;
    private int randomKill;

	public KeyCode[] codes;
	private KeyCode generatedCode;

	// Private Method to do the Generation
	private void doGeneration() {
		// Get a Random value
		int randomNum = Random.Range(0, codes.Length-1);
        
		
		// Store the code
		generatedCode = codes[randomNum];
	}

    //Random chance of auto-killing the player in the last 10 seconds if they are doing poorly.
    private void generateRandomKill()
    {
        randomKill = Random.Range(1, 100);
    }

	// Use this for initialization
	void Start () {
		blinkResize = GameObject.FindGameObjectWithTag ("blink_bar");
        GlobalTimer = GameObject.FindGameObjectWithTag("UIObject");
        doGeneration();
        generateRandomKill();
	}
	
	// Update is called once per frame
	void Update () {
		//Handles size of the bar.
		timeLeft = timeLeft - Time.deltaTime;
		currentSizeBar = blinkResize.transform.localScale.y;
		blinkResize.transform.localScale -= new Vector3(0,Time.deltaTime*100,0);

		//So that bar doesn't go below 0.
		if (blinkResize.transform.localScale.y <= 0.0f) {
			currentCycles++;
			CreatureScript c = creature.GetComponent<CreatureScript>();
			blinkResize.transform.localScale = new Vector3(1,640,1);
            reachZero = true;
			c.increaseThreatEmptyBar();
			//Debug.Log ("why");
		}

		//So that bar doesn't go above 640.
		if (blinkResize.transform.localScale.y > 640.0f) {
			blinkResize.transform.localScale = new Vector3(1,640,1);
		}

        //Adds to bar if player hits the right key
        if (Input.GetKeyDown(generatedCode))
        {
            blinkResize.transform.localScale += new Vector3(0, 100, 0);
            //Debug.Log("BINGO");
        }

		//Debug.Log (timeLeft);
		if (timeLeft < 0) {
			timeLeft = 5f;
			//Change key

			doGeneration();
            if (GlobalTimer.GetComponent<CountdownTimer>().ReturnGlobalTime() < 1f){
				YouWin();
			}
			//Increase cycle count
			currentCycles++;

            if (!reachZero)
            {
                if (currentSizeBar < 320)
                {
                    CreatureScript c = creature.GetComponent<CreatureScript>();
                    c.NotDoingGood();
                    c.increaseThreat();
                    doingGoodCounter = 0;
                    if(GlobalTimer.GetComponent<CountdownTimer>().ReturnGlobalTime() <= 10f && randomKill <= 25)
                    {
                        GameOver();
                    }
                    generateRandomKill();
                }
                else
                {
                    CreatureScript d = creature.GetComponent<CreatureScript>();
                    doingGoodCounter++;
                    if (doingGoodCounter >= 3)
                    {
                        d.ReallyDoingGood();
                        doingGoodCounter = 3;
                    }
                    d.decreaseThreat();
                    
                    reachZero = false;
                }
            } else {
                CreatureScript f = creature.GetComponent<CreatureScript>();
                f.NotDoingGood();
                f.increaseThreat();
                doingGoodCounter = 0;
                reachZero = false;
                if (GlobalTimer.GetComponent<CountdownTimer>().ReturnGlobalTime() <= 10f && randomKill <= 25)
                {
                    GameOver();
                }
                generateRandomKill();
            }


		}
	}

	public void GameOver() {
		Application.LoadLevel("ScreenLose");
	}

	public void YouWin() {
		Application.LoadLevel("ScreenWin");
	}
}
