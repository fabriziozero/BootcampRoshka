using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    public static float _playerScore = 0f;

    private Text _scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        _scoreText = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score" + _playerScore;
    }
}
