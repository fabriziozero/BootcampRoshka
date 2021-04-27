using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    ///ATRIBUTOS

    public GameObject camaras;
    //public SwitchCameras switchCameras;
    private int banSube;//variable bandera que indica que el arbol no subio 0=NO y 1=SI
    private GameObject _player; //referencia a player
    private Vector3 _position; //posicion de player
    private Vector3 _positionTree; //posicion de player
    private GameObject _Tree; //referencia a Tree
    public List<Transform> listTrunk = new List<Transform>(); //Lista de componente transform de trunk
    //public List<GameObject> listTrunkGO = new List<GameObject>();



    /// METODOS
    // Start is called before the first frame update
    private void Awake()
    {
        _player = GameObject.FindWithTag("Player"); //busca un GO con el tag Player
        _position = _player.transform.position; //iguala a la posicion del objeto
        _Tree = this.gameObject; // Este objeto es un Tree
        _positionTree = this.gameObject.transform.position;

        
        
        //Se llena la lista con los Trunk dentro del contenedor
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Transform tmpTransform = gameObject.transform.GetChild(i);
            Transform trunk = tmpTransform.gameObject.GetComponent<Transform>();
            if (trunk != null)
            {
                //Debug.Log("TrunkCount= "+ i);
                listTrunk.Add(trunk);
            }

        }
    }
    void Start()
    {
        banSube = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        for (int i = 0; i < listTrunk.Count; i++)
        {
            if (listTrunk[i]==null)
            {
                listTrunk.Remove(listTrunk[i]);
            }
        }
            
        //Si en el Tree no se encuentra Trunks entonces el player avanza a la siguiente posicion
        if (listTrunk.Count <= 0)
        {
            Destroy(_Tree);
            _position = _player.transform.position; //iguala a la posicion del player en ese momento
            LeanTween.moveZ(_player, (_position[2]+50), 5f).setEaseLinear();
            camaras.SendMessage("ChangeCamera");
            //switchCameras.ChangeCamera();
            //CambiarCamara();
        }
        
    }

    private void Update()
    {
        //Si el player esta cerca y el Tree todavia no subio entonces
        if ((PlayerIsNear(_position)) && (banSube == 0))
        {
            LeanTween.moveY(_Tree, 0f, 1f).setEaseLinear(); //Se le hace subir
            LeanTween.rotateY(_Tree, 90f, 1f).setEaseInSine();//y rotar
            banSube = 1; //se marca que subio
            //Debug.Log("Sube");
        }
    }

    //Devuelve True si el player esta cerca y False si no
    private Boolean PlayerIsNear(Vector3 positionPlayer)
    {

        if (PlayerDistance(_player) <= 40)
        {
            return true;
        }
        else
            return false;
    }
    //Calcula la distancia con el player
    private float PlayerDistance(GameObject Player)
    {
        Vector3 positionPlayer = Player.transform.position;
        Vector3 positionObject = this.gameObject.transform.position;
        float d;
        d = Mathf.Sqrt(Mathf.Pow((positionObject[0] - positionPlayer[0]), 2) +
                       Mathf.Pow((positionObject[1] - positionPlayer[1]), 2) +
                       Mathf.Pow((positionObject[2] - positionPlayer[2]), 2));
        //Debug.Log("Distance: "+ d);
        return d;
    }

    public void BajarTree()
    {
        _positionTree = this.gameObject.transform.position;
        LeanTween.moveY(_Tree, (_positionTree[1]-6f), 1f).setEaseLinear();
    }

    /*public void CambiarCamara()
    {
        switchCameras.ChangeCamera();
    }*/
    
}
