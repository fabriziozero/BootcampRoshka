using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDefeat : MonoBehaviour
{
    private Transform _playerBase;
    
    // Start is called before the first frame update
    void Start()
    {
        //Se inicializa _playerBase
        _playerBase = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //si te quedas sin bases perdes el juego
        if (_playerBase.childCount == 0)
            GameOver._isPlayerDead = true;
    }
}
