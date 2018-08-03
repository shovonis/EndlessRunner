using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private float score;
    private int dificultyLevel = 1;
    private int maxDificultyLevel = 8;
    private int scoreForNextLevel = 20;

    private bool isPlayerDead;

    public Text scoreText;
    public DeathMenu deathMenu;

    void Update()
    {
        if (isPlayerDead)
            return;

        if (score >= scoreForNextLevel)
        {
            LevelUp();
        }

        score += Time.deltaTime * dificultyLevel;
        scoreText.text = "Score: " + (int) score;
    }

    private void LevelUp()
    {
        if (dificultyLevel == maxDificultyLevel)
            return;

        scoreForNextLevel = scoreForNextLevel * 2;
        dificultyLevel++;
        GetComponent<PlayerController>().SetPlayerSpeed(dificultyLevel);
    }

    public void haltScore()
    {
        isPlayerDead = true;
        if (score > PlayerPrefs.GetFloat("HighScore"))
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }

        deathMenu.ShowMenuWithScore(score);
    }
}