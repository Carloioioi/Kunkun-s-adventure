using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class logicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen, gameStartScreen, inGameUI, inGameScore;


    public StartScreenUI StartScreenUI;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        
    }

    public void restartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        //Debug.Log("end game");
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void startGame()
    {
        pipeSawnerScript.Speed = 5;
        StartScreenUI.Hide();
        inGameUI.SetActive(true);
        inGameScore.SetActive(true);
    }


}
