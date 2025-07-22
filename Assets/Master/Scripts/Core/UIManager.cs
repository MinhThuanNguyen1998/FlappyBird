using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private TMPro.TextMeshProUGUI m_ScoreText;
    [SerializeField] private TMPro.TextMeshProUGUI m_YourScoreText;
    [SerializeField] private GameObject m_EndGamePanel;
    private int m_Score = 0;
    public int Score => m_Score;
    private void Start()
    {
        //Debug.Log("UIManager Start");
        m_ScoreText.text = "Score: " + m_Score;
        m_EndGamePanel.SetActive(false);
    }
    /// <summary>
    /// Increases the score and updates the score text.
    /// </summary>
    public void AddScore()
    {
        //Debug.Log("Score: " + m_Score);
        m_Score += 1;
        m_ScoreText.text = "Score: " + m_Score;

    }
    /// <summary>
    /// Resets the score to zero and updates the score text.
    /// </summary>
    public void ResetScore()
    {
        //Debug.Log("Reset score");
        m_Score = 0;
        m_ScoreText.text = "Score: " + m_Score;
    }
    /// <summary>
    /// Shows the end game panel and pauses the game.
    /// </summary>
    public void ShowEndGamePanel()
    {
        //Debug.Log("Show End Game Panel");
        m_EndGamePanel.SetActive(true);
        m_YourScoreText.text = "Your Score: " + m_Score; 
    }
    /// <summary>
    /// Hides the end game panel and resumes the game.
    /// </summary>
    public void HideEndGamePanel()
    {
        //Debug.Log("Hide End Game Panel");
        m_EndGamePanel.SetActive(false);
    }
    /// <summary>
    /// Restart game and reset the game state.
    /// </summary>
    public void OnRestartButton()
    {
        GameManager.Instance.ResetGame();
        HideEndGamePanel();
    }
    /// <summary>
    /// Quit the application
    /// </summary>
    public void OnApplicationQuit()
    {
        Debug.Log("Application Quit");
        Application.Quit(); 
    }
}

