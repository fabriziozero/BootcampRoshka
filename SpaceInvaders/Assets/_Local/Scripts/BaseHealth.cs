using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour
{
    [SerializeField] private float _health = 2; // variable Salud
    // Update is called once per frame
    void Update()
    {
		//Si la vida de la base es menor a 0 la base se destruye
        if (_health <=0)
			Destroy(gameObject);
    }
}
