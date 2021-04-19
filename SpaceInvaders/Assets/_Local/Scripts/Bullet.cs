using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private Transform _bullet;
    [SerializeField] private float speedBullet = 15f;

    // Start is called before the first frame update
    void Start()
    {
        _bullet = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        _bullet.position += Vector3.up * speedBullet * Time.fixedDeltaTime;
        if (_bullet.position.y >= 22.5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.tag == "RedEnemy") || (other.tag == "PurpleEnemy"))
        {   
            GameObject enemy1 = other.gameObject;
            EnemyHealth enemyHealth = enemy1.GetComponent<EnemyHealth>();
            enemyHealth.set_Health(-1f);
            Destroy(this.gameObject);
            //Se suma 10 puntos al Score
            PlayerScore._playerScore += 10;
        }
        else if (other.tag == "Base")
        {
			Destroy(gameObject);
        }
    }

}