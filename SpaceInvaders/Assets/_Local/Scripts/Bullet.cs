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

}