using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    private GameObject _Tree;
    //private GameObject _Trunk;
    [SerializeField] private List<Transform> listTrunk = new List<Transform>();
    // Start is called before the first frame update
    private void Awake()
    {
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
        _Tree = this.gameObject;
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        
        LeanTween.moveY(_Tree, 2, 5f*Time.fixedDeltaTime).setEaseOutBack();
    }
}
