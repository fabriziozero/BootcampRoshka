using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float enemyHealth; // variable Salud

    void Awake()
    {
        if (this.tag == "RedEnemy")
        {
            enemyHealth = 3f;
        }
        else if (this.tag == "PurpleEnemy")
        {
            enemyHealth = 1f;
        }
    }
    public void set_Health (float health)
    {
        enemyHealth += health; 
    }
	
    // Update is called once per frame
    void Update()
    {
        //Si la vida de la base es menor a 0 la base se destruye
        if (enemyHealth <= 0)
        {
            PlayerScore._playerScore += 10;
            Destroy(gameObject);
        }
    }
}
