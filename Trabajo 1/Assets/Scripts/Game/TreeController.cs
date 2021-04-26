using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    private GameObject _Tree;
    // Start is called before the first frame update
    void Start()
    {
        _Tree = this.gameObject;
        LeanTween.moveY(_Tree, 3, 1.5f).setEaseOutBack();
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
