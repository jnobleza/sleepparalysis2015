using UnityEngine;
using System.Collections;

public class CreatureScript : MonoBehaviour
{

    public Sprite[] sprites;
    public Sprite blackScreen;
    public Sprite redScreen;
    public Sprite whiteScreen;
    public float blinkTime;
    public int CurrentThreat { get; private set; }
    private GameObject toController;
    private bool doingGood;

    // Use this for initialization
    void Start()
    {
        CurrentThreat = 0;
        changeSprite();
        toController = GameObject.FindGameObjectWithTag("GameController");
        doingGood = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReallyDoingGood()
    {
        doingGood = true;
    }

    public void NotDoingGood()
    {
        doingGood = false;
    }


    private void FadeToBlack()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = blackScreen;
        Invoke("changeSprite", blinkTime);
    }

    private void FadeToRed()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = redScreen;
        Invoke("changeSprite", blinkTime);
    }

    private void FadeToWhiteEmpty()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = whiteScreen;
        Invoke("changeToEmpty", blinkTime);
    }

    private void FadeToWhite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = whiteScreen;
        Invoke("changeSprite", blinkTime);
    }

    private void changeSprite()
    {
        if (CurrentThreat < 8 && CurrentThreat >= 0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[CurrentThreat];
        }
    }

    private void changeToEmpty()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
    }

    public void increaseThreat()
    {
        if (CurrentThreat == 7)
        {
            GameControllerScript g = toController.GetComponent<GameControllerScript>();
            g.GameOver();
        }
        CurrentThreat++;
        FadeToBlack();
    }

    public void increaseThreatEmptyBar()
    {
        if (CurrentThreat == 7)
        {
            GameControllerScript g = toController.GetComponent<GameControllerScript>();
            g.GameOver();
        }
        CurrentThreat++;
        FadeToRed();
    }

    public void decreaseThreat()
    {

        if (!doingGood)
        {
            FadeToWhiteEmpty();
        }
        else
        {
            CurrentThreat--;
            FadeToWhiteEmpty();
        }
        if (CurrentThreat < 0)
        {
            CurrentThreat = 0;
        }
    }
}
