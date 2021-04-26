using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    private Transform _sawBlade;
    private GameObject _player;
    //private Transform _playerTransform;
    private Vector3 _position;
    [SerializeField] private float speedSaw = 15f;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        //_playerTransform = gameObject.transform.GetComponent<Transform>();
        _position = _player.transform.position;

    }
    // Start is called before the first frame update
    void Start()
    {
        _sawBlade = GetComponent<Transform>();
        
    }
    void FixedUpdate()
    {
        float recorrido = _position[2];
        _sawBlade.position += Vector3.forward * speedSaw * Time.fixedDeltaTime;
        if (_sawBlade.position.z >= recorrido+20)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trunk")
        {   
            GameObject trunk = other.gameObject;
            TrunkHealth trunkHealth = trunk.GetComponent<TrunkHealth>();
            trunkHealth.set_Health(-1f);
            Destroy(this.gameObject);
            //Se suma 10 puntos al Score
            //PlayerScore._playerScore += 10;
        }
    }
}
