using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour{

    [Header("Score Highlight")]
    public int scoreHighlightRange;
    public CharacterSoundController sound;
    private int lastScoreHighlight;

    [Header("Increase Movement Speed Score")]
    public int scoreIncreaseSpeedRange;
    public int speedIncrease;
    private bool inSpeedRange;
    private int lastScore;

    private int currScore;

    void Start(){
        currScore = 0;
        lastScoreHighlight = 0;
        lastScore = 0;
        isIncreaseSpeedRange = false;
    }

    void Update(){
        
    }

    public float GetCurrentScore() {
        return currScore;
    }

    public void IncreaseCurrentScore(int increment) {
        currScore += increment;

        if (currScore - lastScoreHighlight > scoreHighlightRange) {
            sound.PlayScoreHighlight();
            lastScoreHighlight += scoreHighlightRange;
        }

        if(currScore - lastScore > scoreIncreaseSpeedRange) {
            lastScore += scoreIncreaseSpeedRange;
            isIncreaseSpeedRange = true;
        }
    }

    public void FinishScoring() {
        if(currScore > ScoreData.highScore) {
            ScoreData.highScore = currScore;
        }
    }

    public bool isIncreaseSpeedRange {
        get{
            return inSpeedRange;
        }
        set{
            inSpeedRange = value;
        }
    }
}
