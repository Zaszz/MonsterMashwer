using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class registercamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerManager.virtualCamera = gameObject.GetComponent<CinemachineVirtualCamera>();
    }

 
}
