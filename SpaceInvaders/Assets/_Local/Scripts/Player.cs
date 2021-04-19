using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	
    private Transform _player; //referencia al transform del GameObject
    [SerializeField] private float maxBound = 13.5f, minBound = -13.5f; //Limites de camara
    [SerializeField] private GameObject shot;//referencia a GameObject Bullet
    [SerializeField] private Transform shotSpawn; //Desde donde se va a generar la bala
    [SerializeField] private float fireRate;// Cadencia de disparo
    [SerializeField] private float nextFire;// intervalo entre cada disparo
    [SerializeField] private float speed = 9f; //Velocidad con la que se mueve el player
    
    // This function is always called before any Start functions and also just after a prefab is instantiated.
    void Awake()
    {
        //Inicializamos nuestra variable con la Componente Transform (Posicion,Rotacion y Escala)
        _player = GetComponent<Transform>();
    }

    //FixedUpdate is often called more frequently than Update. It can be called multiple times per frame
    void FixedUpdate()
    {
        //Creamos una variable y le damos los valores para moverse horizontalmente
        //Izquierda -1 y Derecha 1
        float h = Input.GetAxis("Horizontal");
		//Aqui evitamos que el player salga del rango de camara asignado
        if (_player.position.x < minBound && h < 0)
            h = 0;
        else if (_player.position.x > maxBound && h > 0)
            h = 0;

        //Cambiamos los valores de la posicion del player
		_player.position += Vector3.right * h * speed * Time.fixedDeltaTime;
    }
    // Update is called once per frame
    void Update()
    {
        //If the Fire1 button is pressed, a projectile
        //will be Instantiated every 0.5 seconds.
        if (Input.GetButton ("Fire1") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
        }
    }
}
