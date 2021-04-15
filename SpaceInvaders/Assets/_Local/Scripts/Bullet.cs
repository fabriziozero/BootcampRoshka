using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform _bullet;
    [SerializeField] private float _speedBullet = 15f;

    // Start is called before the first frame update
    void Start()
    {
        _bullet = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        _bullet.position += Vector3.up * _speedBullet * Time.deltaTime;
        if (_bullet.position.y >= 22.5)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            //Se suma 10 puntos al Score
            PlayerScore._playerScore += 10;
        }
        else if (other.tag == "Base")
        {
			//GameObject playerBase = other.gameObject;
            //BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
            //baseHealth.set_Health(-1f);
            Destroy(gameObject);
            
        }
    }

}