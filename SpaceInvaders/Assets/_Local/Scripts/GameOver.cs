using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public static bool _isPlayerDead = false;

    private Text _gameOver;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _gameOver = GetComponent<Text>();
        _gameOver.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlayerDead)
        {
            Time.timeScale = 0;
            _gameOver.enabled = true;
        }
    }
}
