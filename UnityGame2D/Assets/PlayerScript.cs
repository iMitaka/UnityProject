﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private int coins;
    public Text coinsScore;
    public GameObject coinSound;
    private int nextScene;

    private void Start()
    {
        nextScene = PlayerPrefs.GetInt("nextScene", 0);
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        coins = PlayerPrefs.GetInt("coins", 0);
        coinsScore.text = coins.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            coinSound.GetComponent<AudioSource>().Play();
            coins++;
            Destroy(collision.gameObject);
            coinsScore.text = coins.ToString();
           
        }

        if (collision.CompareTag("Portal"))
        {
            PlayerPrefs.SetInt("nextScene", nextScene);
            PlayerPrefs.SetInt("coins", coins);
            Debug.Log("Level complete!");
            SceneManager.LoadScene(nextScene);
        }

    }

    

    

}
