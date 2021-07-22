using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShineMaker : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
    private List<Material> materials = new List<Material>();
    public float ShineSpeed;
    public float ShineDuration;
    public float ShineBrightness;
    private float timer = 0f;
    private float shinelocation=0f;
    private bool shinelocationup = true;

    private void Start()
    {
        foreach (SpriteRenderer item in spriteRenderers)
        {
            materials.Add(item.material);
        }
    }

    public void StartShine()
    {

        shinelocation = 0f;
        shinelocationup = true;
        timer = ShineDuration;

        foreach (Material item in materials)
        {
            item.SetFloat("_ShineLocation", shinelocation);
            item.SetFloat("_ShineGlow", ShineBrightness);
        }

    }

    private void StopShine()
    {
        timer = 0f;
        foreach (Material item in materials)
        {
            item.SetFloat("_ShineLocation", 0f);
            item.SetFloat("_ShineGlow", 0f);
        }

    }

    private void Shine()
    {

        if (shinelocationup)
        {
            shinelocation += ShineSpeed * Time.deltaTime;
        }
        else
        {
            shinelocation -= ShineSpeed * Time.deltaTime;
        }

        if (shinelocation <= 0) {
            shinelocationup = true;
            shinelocation = 0;
        }

        if (shinelocation >= 1) {
            shinelocationup = false;
            shinelocation = 1f;
        }



        foreach (Material item in materials)
        {
            item.SetFloat("_ShineLocation", shinelocation);
        }
    }


    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
            Shine();
            if (timer <= 0f)
            {
                StopShine();
            }
        }
    }
}
