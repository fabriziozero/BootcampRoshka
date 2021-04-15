using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    private Transform _bulletEnemy;
    
    public float _speed;
    // Start is called before the first frame update
    void Start()
    {
        //Se inicializa _bulletEnemy
        _bulletEnemy = GetComponent<Transform>();
    }
    
    private void FixedUpdate()
    {
        _bulletEnemy.position += Vector3.down * _speed;
        //Si sale de la pantalla hacia abajo la bala enemiga se destruye
        if (_bulletEnemy.position.y <= 0)
        {
            Destroy(_bulletEnemy.gameObject);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        //Si entra en contacto con un player
        if (other.tag == "Player")
        {
            Destroy(other.gameObject); //se destruye el player
            Destroy(gameObject); //se destruye la bala
            GameOver._isPlayerDead = true;
        }
        //Si entra en contacto con la base
        else if (other.tag == "Base")
        {
            GameObject playerBase = other.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
            baseHealth.set_Health(-1f);
            Destroy(gameObject);

        }
    }    
    

}
