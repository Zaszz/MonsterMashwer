using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    private void Start()
    {
        gameObject.GetComponent<Animator>().Play("Flash");
    }

    private void Update()
    {
        
    }

    public void DisableMe()
    {
        gameObject.SetActive(false);
    }
}
