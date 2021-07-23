using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartController : MonoBehaviour
{

    [SerializeField]
    public List<SpriteRenderer> sprites = new List<SpriteRenderer>();


    //singleton
    public static HeartController Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void UpdateHealthUI(int hp)
    {
        foreach (SpriteRenderer item in sprites)
        {
            item.enabled = false;
        }

        for (int i = 0; i < hp; i++)
        {
            sprites[i].enabled = true;
        }
    }
}
