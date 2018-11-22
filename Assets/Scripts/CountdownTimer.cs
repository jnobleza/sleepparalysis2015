using UnityEngine;
using System.Collections;

public class CountdownTimer : MonoBehaviour {
    public float globalCountdown = 60f;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        globalCountdown = globalCountdown - Time.deltaTime;
        if (globalCountdown <= 10f)
        {
            gameObject.GetComponent<GUIText>().text = "" + (int)globalCountdown + " more seconds! The monster is getting aggressive!" + "\n" + "Keep going strong!";
        }
        else { 
        gameObject.GetComponent<GUIText>().text = "" + (int)globalCountdown;
    }
    }

    public void SubtractTime()
    {
        globalCountdown = globalCountdown - 10f;
    }

    public float ReturnGlobalTime()
    {
        return globalCountdown;
    }

}
