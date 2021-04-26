using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkHealth : MonoBehaviour
{
    [SerializeField] private float trunkHealth = 3; // variable Salud
    public void set_Health (float health)
    {
        trunkHealth += health; 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si la vida es menor a 0, trunk se destruye
        if (trunkHealth <= 0)
        {
            //PlayerScore._playerScore += 10;
            Destroy(gameObject);
        }
    }
}
