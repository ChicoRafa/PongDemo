using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("ScoreCanvas")]
    [SerializeField] private Text playerScoreText;
    [SerializeField] private Text enemyScoreText;
    [Header("Game Objects")]
    [SerializeField] private Transform player;
    [SerializeField] private Transform enemy;
    [SerializeField] private Transform ball;
    [Header("Score")]
    private int playerScore, enemyScore;

    private static GameManager instance;
    /// <summary>
    /// Singleton para solo tener una instancia disponible de esta clase 
    /// que se pueda usar en el resto del programa
    /// </summary>
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }
    /// <summary>
    /// Método que suma al puntaje del jugador 1
    /// </summary>
    public void PlayerScored()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
    }
    /// <summary>
    /// Método que suma al puntaje del jugador 2
    /// </summary>
    public void EnemyScored()
    {
        enemyScore++;
        enemyScoreText.text = enemyScore.ToString();
    }
    /// <summary>
    /// Reinicia posiciones al marcar
    /// </summary>
    public void Restart()
    {
        player.position = new Vector2(player.position.x, 0);
        enemy.position = new Vector2(enemy.position.x, 0);
        ball.position = new Vector2(0, 0);
    }

}
