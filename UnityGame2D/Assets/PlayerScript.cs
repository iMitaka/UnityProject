using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private int coins = 0;
    public Text coinsScore;
    public GameObject coinSound;

    private void Start()
    {
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
            PlayerPrefs.SetInt("coins", coins);
            Debug.Log("Level complete!");
            Application.LoadLevel(1);
        }

    }

    

    

}
