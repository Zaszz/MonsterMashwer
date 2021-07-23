using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchVFX : MonoBehaviour
{
    public GameObject vfx;

    public void PunchVFXPlay()
    {
        vfx.SetActive(true);
    }
}
