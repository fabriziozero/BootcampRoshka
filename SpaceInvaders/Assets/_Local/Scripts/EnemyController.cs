using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{

	private Transform _contenedorEnemy;
	private float _speed;
	
	public GameObject _shot;
	[SerializeField] private Text _win;
	public float _fireRate = 1f;

    // Start is called before the first frame update
    void Start()
    {
		//_win = GetComponent<Text>();
        _win.enabled = false;
		InvokeRepeating("MoveEnemy", 0.1f,0.3f);
		_contenedorEnemy = GetComponent<Transform>();
    }
	
	void MoveEnemy()
	{
		//_contenedorEnemy.position += Vector3.right * _speed * Time.deltaTime;
		_contenedorEnemy.position += Vector3.right * _speed;
		foreach(Transform enemy in _contenedorEnemy)
		{
			if (enemy.position.x < -13.5f || enemy.position.x > 13.5f)
			{
				_speed = -_speed;
				_contenedorEnemy.position += Vector3.down * 0.5f;
				//break;
			}

			if (enemy.position.y <= 0.5f)
			{
				GameOver._isPlayerDead = true;
				Time.timeScale = 0;
			}

			if (_contenedorEnemy.childCount == 1)
			{
				CancelInvoke();
				InvokeRepeating("MoveEnemy",0.1f,0.25f);
			}

			if(_contenedorEnemy.childCount ==0)
			{
				_win.enabled = true;
			}
		}
	}

}
