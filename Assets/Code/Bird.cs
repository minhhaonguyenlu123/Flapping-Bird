using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rb;
    public float jumpForce;
    private bool isGameOver;
    private bool startGame;
    public GameObject gameController;
    public GameObject message;
    public GameObject gameOver;
    private int score;
    public Text scoreText;
    
    private void Awake()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        startGame = false;
        isGameOver = false;
        rb.gravityScale = 0;
        score = 0;
        scoreText.text = score.ToString();
        message.GetComponent<SpriteRenderer>().enabled = true;
        gameOver.GetComponent<SpriteRenderer>().enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(!isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SoundController.instance.PlayThisSource("wing", 5f);

                if (!startGame)
                {
                    
                    startGame = true;
                    rb.gravityScale = 6;
                    gameController.GetComponent<PipeController>().startPipe = true;
                    message.GetComponent<SpriteRenderer>().enabled = false;
                }
                jump();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ReloadScene();
            }
        }
    }

    private void jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundController.instance.PlayThisSource("hit", 5f);
        score = 0;
        scoreText.text = score.ToString();
        GameOver();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundController.instance.PlayThisSource("point", 5f);
        score += 1;
        scoreText.text = score.ToString();
    }

    private void GameOver()
    {
        isGameOver = true; 
        gameOver.GetComponent<SpriteRenderer>().enabled = true; 
        Time.timeScale = 0;
    }

    public void ReloadScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start_Game");
    }
}
