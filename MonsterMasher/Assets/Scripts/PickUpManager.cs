using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    //singleton
    public static PickUpManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public List<GameObject> hearts = new List<GameObject>();
    public List<GameObject> aliens = new List<GameObject>();
    public List<GameObject> apes = new List<GameObject>();

}
