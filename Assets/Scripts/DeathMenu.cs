using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public Text scoreText;
    
    public Image backGroundImage;
    private float transition;
    private bool isShown = false;
    
    
    void Start()
    {
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isShown)
        {
            return;
        }

        transition += Time.deltaTime;
        backGroundImage.color = Color.Lerp(backGroundImage.material.color, Color.red, transition);
    }

    public void ShowMenuWithScore(float score)
    {
        gameObject.SetActive(true);
        scoreText.text = "Final Score: " + (int)score;
        isShown = true;
    }

    public void OnPlayAgainClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnMenuButtonClicked()
    {
        Debug.Log("Not Supported Yet");
        SceneManager.LoadScene("Menu");
    }
    
    
}