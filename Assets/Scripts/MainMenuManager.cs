using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Text highScore;

    void Start()
    {
        highScore.text = "High Score: " + (int)PlayerPrefs.GetFloat("HighScore");
    }

    public void OnPlayeButtonClicked()
    {
        SceneManager.LoadScene("EndlessRunnerGame");
    }
}