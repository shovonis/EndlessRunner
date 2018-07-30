using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private float score;
    private int dificultyLevel = 1;
    private int maxDificultyLevel = 10;
    private int scoreForNextLevel = 25;

    public Text scoreText;

    void Update()
    {
        if (score >= scoreForNextLevel)
        {
            LevelUp();
        }

        score += Time.deltaTime * dificultyLevel;
        scoreText.text = "Score: " + (int) score;
    }

    private void LevelUp()
    {
        if(dificultyLevel == maxDificultyLevel)
            return;
        
        scoreForNextLevel = scoreForNextLevel * 2;
        dificultyLevel++;
        GetComponent<PlayerController>().SetPlayerSpeed(dificultyLevel);
    }
}