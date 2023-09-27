using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D ball;
    //serialized permite acceder a la variable desde el editor sin hacerla pública
    [SerializeField] private float initialVelocity = 4f;
    [SerializeField] private float velocityMultiplier = 1.1f;
    // Start is called before the first frame update
    void Start()
    {
        ball = GetComponent<Rigidbody2D>();
        FirstLaunch();
    }

    // Update is called once per frame
    void Update()
    {

    }
    /// <summary>
    /// se crea un lanzamiento inicial con valores aleatorios en X e Y, 
    /// por lo que la pelota sale siempre en una de las cuatro diagonales
    /// </summary>
    private void FirstLaunch()
    {
        float xVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        float yVelocity = Random.Range(0, 2) == 0 ? 1 : -1;
        ball.velocity = new Vector2(xVelocity, yVelocity) * initialVelocity;

    }

    /// <summary>
    /// Si choca con una paleta aumentamos velocidad
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ball.velocity *= velocityMultiplier;
    }
    
    /// <summary>
    /// Método usado cuando la bola entre en una portería
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerGoal"))
        {
            GameManager.Instance.EnemyScored();
            GameManager.Instance.Restart();
            FirstLaunch();
        }
        else
        {
            GameManager.Instance.PlayerScored();
            GameManager.Instance.Restart();
            FirstLaunch();
        }
    }
}
