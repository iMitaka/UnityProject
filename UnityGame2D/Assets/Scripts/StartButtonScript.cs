using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartButtonScript : MonoBehaviour {

   
    public void LoadLevel()
    {
        SceneManager.LoadScene("Level 0");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
