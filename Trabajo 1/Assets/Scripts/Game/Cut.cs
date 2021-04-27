using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cut : MonoBehaviour
{
    //ATRIBUTOS
    private GameObject _player;
    public Button btnCut;
    [SerializeField] private GameObject shot;//referencia a GameObject Saw_Blade
    [SerializeField] private Transform shotSpawn; //Desde donde se va a generar la sierra
    [SerializeField] private float fireRate = 0.5f;// Cadencia de disparo
    [SerializeField] private float nextFire;// intervalo entre cada disparo
    
    //METODOS
    void Awake()
    {
        _player = GameObject.FindWithTag("Player");
    }
    // Start is called before the first frame update
    void Start()
    {
        Button btn = btnCut.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick(){
        //Debug.Log ("You have clicked the button!");
        if (Time.time > nextFire)
        {
            
            LeanTween.scale(_player, Vector3.one, 0.5f).setEasePunch();
            nextFire = Time.time + fireRate; //proximo disparo
            Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
            
        }
    }

}
