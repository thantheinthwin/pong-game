using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehaviour : MonoBehaviour
{
    public GameManager gameManager;
    public Rigidbody2D rb2d;
    public float maxInitialAngle = 0.67f;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float startX = 0f;
    [SerializeField] float maxStartY = 4f;
    public int gamePoint = 3;
    public TMPro.TextMeshProUGUI winner;

    private void Start()
    {
        InitialPush();
    }

    private void resetBall()
    {
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;
    }

    public void InitialPush()
    {
        Vector2 dir = Random.value < 0.5f ? Vector2.left : Vector2.right;
      
        // Randomizating the initial launch angle
        dir.y = Random.Range(-maxInitialAngle, maxInitialAngle);

        rb2d.velocity = dir * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreZone scoreZone = collision.GetComponent<scoreZone>();

        if (scoreZone)
        {
            gameManager.onScoreZoneReached(scoreZone.id);
            resetBall();
            InitialPush();

            Debug.Log("Game Point : " +  gamePoint);

            // Statement for dues points
            if(gameManager.scorePlayer1 == gameManager.scorePlayer2 && gameManager.scorePlayer1 == gamePoint-1)
            {
                gamePoint++;
            }


            if(gameManager.scorePlayer1 == gamePoint)
            {
                winner.text = "Player 1 won";
                gameManager.gameOver();
            }
            else if (gameManager.scorePlayer2 == gamePoint)
            {
                winner.text = "Player 2 won";
                gameManager.gameOver();
            }
        }
    }
}
