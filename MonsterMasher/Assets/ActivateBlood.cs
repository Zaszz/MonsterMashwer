using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateBlood : MonoBehaviour
{
    public GameObject blood;
    public void ActivateThisBlood()
    {
        blood.SetActive(true);
    }
}
