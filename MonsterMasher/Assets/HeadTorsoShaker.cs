using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTorsoShaker : MonoBehaviour
{

    private Material headmat;
    private Material torsomat;
    public SpriteRenderer headspriteRenderer;
    public SpriteRenderer torsospriteRenderer;
    public float ShakeAmount;
    public float ShakeDuration;
    private float timer = 0f;


    // Start is called before the first frame update
    void Start()
    {
        headmat = headspriteRenderer.material;
        torsomat = torsospriteRenderer.material;
    }

    public void StartHeadBodyShake()
    {

            headmat.SetFloat("_ShakeUvSpeed", ShakeAmount);
            torsomat.SetFloat("_ShakeUvSpeed", ShakeAmount);
            timer = ShakeDuration;
    }

    public void StopHeadBodyShake()
    {
        headmat.SetFloat("_ShakeUvSpeed", 0);
        torsomat.SetFloat("_ShakeUvSpeed", 0);
    }

    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                StopHeadBodyShake();
            }
        }
    }

}
