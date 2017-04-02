using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerAnimator : MonoBehaviour {


    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine(ActivateLazer());
    }

    

   IEnumerator ActivateLazer()
    {
        boxCollider.enabled = false;
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(1);
        boxCollider.enabled = true;
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(1);
        StartCoroutine(ActivateLazer()); 
    }
}
