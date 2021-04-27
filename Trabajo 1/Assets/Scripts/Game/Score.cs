using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    //ATRIBUTOS
    private TextMeshProUGUI _scoreCounterText; //Referencia a TMPro
    public static int scoreValue; //Puntaje

    //METODOS
    void Awake()
    {
        _scoreCounterText = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreValue = 0; //Comenzamos en 0
    }

    // Update is called once per frame
    void Update()
    {
        _scoreCounterText.text = scoreValue.ToString(); //Se actualiza en pantalla
    }
}
