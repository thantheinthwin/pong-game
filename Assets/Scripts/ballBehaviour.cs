using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballBehaviour : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float maxInitialAngle = 0.67f;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float startX = 0f;
    [SerializeField] float maxStartY = 4f;

    // Start is called before the first frame update
    void Start()
    {
        InitialPush();
    }

    private void resetBall()
    {
        float posY = Random.Range(-maxStartY, maxStartY);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;
    }

    private void InitialPush()
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
            resetBall();
            InitialPush();
        }
    }
}
