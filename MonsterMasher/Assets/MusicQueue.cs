using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicQueue : MonoBehaviour
{
    public List<AudioClip> tracks = new List<AudioClip>();
    public AudioSource audiosource;
    public int i;

    #region Singleton
    public static MusicQueue instance;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of MusicManager found!");
            return;
        }
        instance = this;

    }
    #endregion

    private void Start()
    {
        audiosource.clip = tracks[0];
        audiosource.Play();
        i = 0;
    }

    private void Update()
    {
        if (!audiosource.isPlaying)
        {
            i += 1;
            if (i > tracks.Count - 1)
            {
                i = 0;
            }

            audiosource.clip = tracks[i];
            audiosource.Play();
        }
    }

}
