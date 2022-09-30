using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public AudioSource pingpong;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Play pingpong sound when ball touch the walls
        if (collision.transform.CompareTag("ball"))
        {
            pingpong.Play();
        }
    }
}
