using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchVFX : MonoBehaviour
{
    public GameObject vfx;
    public AudioClip hitClip;
    public AudioSource source;

    public void PunchVFXPlay()
    {
        source.clip = hitClip;
        source.Play();
        vfx.SetActive(true);
    }
}
