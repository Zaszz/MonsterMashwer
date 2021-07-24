using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartRegister : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PickUpManager.Instance.hearts.Add(this.gameObject);
    }

}
