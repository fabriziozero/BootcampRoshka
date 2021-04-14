using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SwitchCameras : MonoBehaviour
{
    
    [SerializeField] private List<CinemachineVirtualCamera> listCameras = new List<CinemachineVirtualCamera>();

    private int _currentCamera = 0;

    private void Awake()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            /*Transform tmpTransform = gameObject.transform.GetChild(i);
            listCameras.Add(tmpTransform.gameObject.GetComponent<CinemachineVirtualCamera>());*/
            
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
        listCameras[0].Priority = 1;
        StartCoroutine(ChangeCamera());
    }

    IEnumerator ChangeCamera()
    {
        yield return new WaitForSeconds(3f);
        ResetPriority();
        listCameras[_currentCamera].Priority = 1;
        _currentCamera++;
        if (_currentCamera == listCameras.Count)
        {
            _currentCamera = 0;
        }

        StartCoroutine(ChangeCamera());
    }

    private void ResetPriority()
    {
        for (int i = 0; i < listCameras.Count; i++)
        {
            listCameras[i].Priority = 0;
        }
    }
    /*
     [SerializeField] private CinemachineVirtualCamera[] _listCameras;
     
    
    
    private int _currentCamera = 0;
    
        // Start is called before the first frame update
    void Start()
    {
        ResetPriority();
        _listCameras[0].Priority = 1;
        StartCoroutine(ChangeCamera());
    }
    
    IEnumerator ChangeCamera()
    {
        yield return new WaitForSeconds(3f);
        ResetPriority();
        _listCameras[_currentCamera].Priority = 1;
        _currentCamera++;
        if (_currentCamera == _listCameras.Length)
        {
            _currentCamera = 0;
        }
    
        StartCoroutine(ChangeCamera());
    }
    
    private void ResetPriority()
    {
        for (int i = 0; i < _listCameras.Length; i++)
        {
                _listCameras[i].Priority = 0;
        }
    }*/
    
}
