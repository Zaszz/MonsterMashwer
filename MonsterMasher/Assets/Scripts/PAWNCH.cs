using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAWNCH : MonoBehaviour
{
    public GameObject Fisto;
    public Vector3 FistoSpoto;
    private Vector3 returnSpoto;
    private bool punching = false;
    public float punchspeed;

    private void Update()
    {
        CompletePauncho();
    }

    private void CompletePauncho()
    {
        if (punching == true)
        {
            // Move our position a step closer to the target.
            float step = punchspeed * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, returnSpoto, step);
            if (transform.position == returnSpoto)
            {
                punching = false;
            }
        }

        if (punching == false && Input.GetKey(KeyCode.Space))
        {
            punching = true;
            returnSpoto = transform.position;
            Fisto.transform.position = FistoSpoto;
        }


    }
}
