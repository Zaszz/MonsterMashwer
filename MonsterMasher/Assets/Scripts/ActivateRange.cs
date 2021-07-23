using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateRange : MonoBehaviour
{
    public float pingtime;
    public float timer;
    public float activationrange;
    public AlienAI myAi;

    private void Start()
    {
        timer = pingtime;
    }

    private void Update()
    {
        if (timer > 0 && myAi.enabled == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (Vector3.Distance(PlayerManager.playerObject.transform.position, gameObject.transform.position) <= activationrange)
                {
                    //activate
                    myAi.enabled = true;
                }
                else
                {
                    timer = pingtime;
                }
            }
            
        }
    }
}
