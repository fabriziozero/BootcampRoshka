using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCameras : MonoBehaviour
{
    //Se crea una lista de tipo CinemachineVirtualCamera
    [SerializeField] private List<CinemachineVirtualCamera> listCameras = new List<CinemachineVirtualCamera>();
    //Variable para la camara actual
    public int currentCamera;

    private void Awake()
    {
        currentCamera = 0;
        //Se llena la lista con las camaras virtuales dentro del contenedor
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            
            Transform tmpTransform = gameObject.transform.GetChild(i);
            CinemachineVirtualCamera cinemachineVirtualCamera = tmpTransform.gameObject.GetComponent<CinemachineVirtualCamera>();
            if (cinemachineVirtualCamera != null)
            {
                listCameras.Add(cinemachineVirtualCamera);
            }

        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        ResetPriority();
        listCameras[currentCamera].Priority = 1;
    }
    

    private void ResetPriority()
    {
        for (int i = 0; i < listCameras.Count; i++)
        {
            listCameras[i].Priority = 0;
        }
    }
    
    public void ChangeCamera()
    {
        
        ResetPriority();
        if (currentCamera < (listCameras.Count-1))
        {
            currentCamera++;
        }
        listCameras[currentCamera].Priority = 1;
    }
   
}
