using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cut : MonoBehaviour
{
    public Button btnCut;
    [SerializeField] private GameObject shot;//referencia a GameObject Saw_Blade
    [SerializeField] private Transform shotSpawn; //Desde donde se va a generar la sierra
    // Start is called before the first frame update
    void Start()
    {
        Button btn = btnCut.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick(){
        Debug.Log ("You have clicked the button!");
        Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
    }

    // Update is called once per frame
    
}
