using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallSoundManager : MonoBehaviour
{

    public AudioSource Fireballsound;
    public AudioSource Explosionsound;
    //singleton
    public static FireBallSoundManager Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
}
