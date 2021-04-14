using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerScore._playerScore = 0;
            GameOver._isPlayerDead = false;
            Time.timeScale = 1;

            SceneManager.LoadScene("Game");
        } 
    }
}
