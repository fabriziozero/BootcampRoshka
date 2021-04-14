using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform _player;
    [SerializeField] private float _maxBound = 13.5f, _minBound = -13.5f;
    [SerializeField] private GameObject _shot;
    [SerializeField] private Transform _shotSpawn;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _nextFire;
    [SerializeField] private float _speed = 9f;
    
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if (_player.position.x < _minBound && h < 0)
            h = 0;
        else if (_player.position.x > _maxBound && h > 0)
            h = 0;

        _player.position += Vector3.right * h * _speed * Time.deltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        //If the Fire1 button is pressed, a projectile
        //will be Instantiated every 0.5 seconds.
        if (Input.GetButton ("Fire1") && Time.time > _nextFire) {
            _nextFire = Time.time + _fireRate;
            Instantiate (_shot, _shotSpawn.position, _shotSpawn.rotation);
        }
    }
}
