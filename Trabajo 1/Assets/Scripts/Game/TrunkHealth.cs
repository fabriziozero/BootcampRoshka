using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkHealth : MonoBehaviour
{
    
    public TreeController treeController;
    [SerializeField] private float health; // variable Salud

    void Awake()
    {
        health = 3;
    }
    // Update is called once per frame
    void Update()
    {
        //Si la vida es menor a 0, trunk se destruye
        if (health <= 0)
        {
            
            Score.scoreValue += 10;
            Destroy(this.gameObject);
            treeController.BajarTree();
            //gameObject.SendMessage("BajarTree");

        }
    }
    //Se le suma una cantidad de vida x
    public void setHealth (float x)
    {
        Score.scoreValue += 1;
        this.health += x; 
    }
}
