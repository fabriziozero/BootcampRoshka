using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] private float baseHealth = 2; // variable Salud
    public void set_Health (float health)
	{
		baseHealth += health; 
	}
	
	// Update is called once per frame
    void Update()
    {
		//Si la vida de la base es menor a 0 la base se destruye
		if (baseHealth <= 0)
		{
			PlayerScore._playerScore -= 10;
			Destroy(gameObject);
		}
    }
}
