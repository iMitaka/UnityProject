using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{

    private int coins;
    public Text coinsScore;
    public GameObject coinSound;
    public GameObject ouchSound;
    public GameObject heartBeatSound;
    private int nextScene;
    private int health = 3;
    public GameObject Hearts3;
    public GameObject Hearts2;
    public GameObject Hearts1;
 


    private SpriteRenderer spriteRenderer; 

    private void Start()
    {
        Hearts3.SetActive(true);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
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

        if (collision.gameObject.CompareTag("Meteor"))
        {
            ouchSound.GetComponent<AudioSource>().Play();
            this.spriteRenderer.color = Color.red;

            StartCoroutine(Wait(0.3f));

            health--;
            UpdateHealthBar(health);
            if (health == 0)
            {
                SceneManager.LoadScene(nextScene - 1);
            }
        }

        if (collision.gameObject.CompareTag("Lazer"))
        {
            SceneManager.LoadScene(nextScene - 1);
        }

        if (collision.CompareTag("Heart+"))
        {
            
            if (health < 3)
            {
                heartBeatSound.GetComponent<AudioSource>().Play();
                health++;
                UpdateHealthBar(health);
                Destroy(collision.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spikes"))
        {
            ouchSound.GetComponent<AudioSource>().Play();
            this.spriteRenderer.color = Color.red; 

            StartCoroutine(Wait(0.3f)); 

            health--;
            UpdateHealthBar(health);
           
            if (health == 0)
            {
                SceneManager.LoadScene(nextScene - 1);
            }
        }
    } 

    IEnumerator RestartLevel(float seconds)
    {
        if (health <= 0)
        {
            yield return new WaitForSeconds(seconds);
            SceneManager.LoadScene("Scene");
        }
    }

    IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        this.spriteRenderer.color = Color.white;
        StartCoroutine(RestartLevel(0.2f));
    }

    private void UpdateHealthBar(int health)
    {
        if (health == 2)
        {
            Hearts2.SetActive(true);
            Hearts1.SetActive(false);
            Hearts3.SetActive(false);
        }
        else if (health == 1)
        {
            Hearts1.SetActive(true);
            Hearts2.SetActive(false);
            Hearts3.SetActive(false);
        }
        else if (health == 3)
        {
            Hearts3.SetActive(true);
            Hearts1.SetActive(false);
            Hearts2.SetActive(false);
        }
    }
}


