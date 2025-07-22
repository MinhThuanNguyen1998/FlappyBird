using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private bool m_IsEndGame = false;
    public bool IsEndGame => m_IsEndGame;

    private void Start()
    {
        StartGame(); 
    }
    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ResetGame()
    {
        Time.timeScale = 1f; 
        m_IsEndGame = false; 
        StartGame(); 
        UIManager.Instance.ResetScore(); 
    }
    /// <summary>
    ///  Stop the game and show the end game panel.
    ///</summary>>
    public void EndGame()
    {
        Debug.Log("EndGame");
        Time.timeScale = 0f; 
        m_IsEndGame = true;
        UIManager.Instance.ShowEndGamePanel(); 
    }
}
