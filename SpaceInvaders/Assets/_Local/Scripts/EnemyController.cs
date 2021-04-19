using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

	private Transform _contenedorEnemy;
	[SerializeField] private float _speed;
	
	public GameObject _shot;
	public Text _win;
	public float _fireRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
		//_win = GetComponent<Text>();
        _win.enabled = false;
		InvokeRepeating("MoveEnemy", 0.1f * Time.deltaTime,0.3f * Time.deltaTime);
		_contenedorEnemy = GetComponent<Transform>();
    }
	
	void MoveEnemy()
	{
		//_contenedorEnemy.position += Vector3.right * _speed * Time.deltaTime;
		_contenedorEnemy.position += Vector3.right * _speed;
		foreach(Transform enemy in _contenedorEnemy)
		{
			//Debug.Log(_contenedorEnemy.childCount);
			if (enemy.position.x < -13.5f || enemy.position.x > 13.5f)
			{
				_speed = -_speed;
				_contenedorEnemy.position += Vector3.down * 0.5f;
				break;
			}

			if(Random.value > _fireRate)
			{
				Instantiate(_shot,enemy.position,enemy.rotation);
			}

			if (enemy.position.y <= 0.5f)
			{
				GameOver._isPlayerDead = true;
				Time.timeScale = 0;
			}

			if (_contenedorEnemy.childCount == 1)
			{
				CancelInvoke();
				InvokeRepeating("MoveEnemy",0.1f * Time.deltaTime,0.25f * Time.deltaTime);
				//Debug.Log(_contenedorEnemy.childCount);
			}

			if (_contenedorEnemy.childCount == 0)
			{
				//Debug.Log("Win");
				_win.enabled = true;
			}

		}

		
	}
	void Update()
	{
		if (_contenedorEnemy.childCount == 0)
		{
			//Debug.Log("Win");
			_win.enabled = true;
		}
	}

}
