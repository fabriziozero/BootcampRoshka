using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{
    private Transform _sawBlade;
    [SerializeField] private float speedSaw = 15f;
    // Start is called before the first frame update
    void Start()
    {
        _sawBlade = GetComponent<Transform>();
        
    }
    void FixedUpdate()
    {
        _sawBlade.position += Vector3.forward * speedSaw * Time.fixedDeltaTime;
        if (_sawBlade.position.z >= 1)
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
