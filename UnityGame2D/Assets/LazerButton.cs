using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerButton : MonoBehaviour {


    public GameObject gameObject;
	
	

	

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
