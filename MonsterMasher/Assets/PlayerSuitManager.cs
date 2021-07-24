using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSuitManager : MonoBehaviour
{

    public GameObject skeleton;
    public GameObject alien;
    public GameObject ape;
    //singleton
    public static PlayerSuitManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
