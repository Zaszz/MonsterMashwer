using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    public AudioClip step1;
    public AudioSource source1;
    public AudioClip step2;
    public AudioSource source2;

    public void Step1()
    {
        source1.clip = step1;
        source1.Play();
    }

    public void Step2()
    {
        source2.clip = step2;
        source2.Play();
    }
}
