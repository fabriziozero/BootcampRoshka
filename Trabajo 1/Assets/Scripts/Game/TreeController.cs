using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    private GameObject _player;
    //private Transform _playerTransform;
    private Vector3 _position;
    private GameObject _Tree;
    //private GameObject _Trunk;
    [SerializeField] private List<Transform> listTrunk = new List<Transform>();
    // Start is called before the first frame update
    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _position = _player.transform.position;
        
        _Tree = this.gameObject;
        
        //Se llena la lista con los Trunk dentro del contenedor
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform tmpTransform = gameObject.transform.GetChild(i);
            Transform trunk = tmpTransform.gameObject.GetComponent<Transform>();
            if (trunk != null)
            {
                Debug.Log("TrunkCount= "+ i);
                listTrunk.Add(trunk);
            }

        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if (PlayerIsNear(_position))
            LeanTween.moveY(_Tree, 2, 5f*Time.fixedDeltaTime).setEaseOutBack();
    }

    //Devuelve True si el player esta cerca
    private Boolean PlayerIsNear(Vector3 positionPlayer)
    {

        if (PlayerDistance(_player) <= 40)
        {
            return true;
        }
        else
            return false;
    }

    private float PlayerDistance(GameObject Player)
    {
        Vector3 positionPlayer = Player.transform.position;
        Vector3 positionObject = this.gameObject.transform.position;
        float d;
        d = Mathf.Sqrt(Mathf.Pow((positionObject[0] - positionPlayer[0]), 2) +
                       Mathf.Pow((positionObject[1] - positionPlayer[1]), 2) +
                       Mathf.Pow((positionObject[2] - positionPlayer[2]), 2));
        Debug.Log("Distance: "+ d);
        return d;
    }
}
