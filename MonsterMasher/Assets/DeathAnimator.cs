using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimator : MonoBehaviour
{
    //applies a ghostly affect to a unit.
    public List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
    private List<Material> materials = new List<Material>();
    public float GhostFadeSpeed;
    public float GhostFadeDuration;
    private float timer = 0f;
    private float currentBlend = 0f;
    private float currentTransparency = 0f;

    private void Start()
    {
        foreach (SpriteRenderer item in spriteRenderers)
        {
            materials.Add(item.material);
        }
    }

    public void GoGhost()
    {
        timer = GhostFadeDuration;

    }

    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            Ghost();
            if (timer <= 0)
            {
                timer = 0f;
            }
        }
    }


    private void Ghost()
    {
        if (currentBlend < 1)
        {
            currentBlend += GhostFadeSpeed * Time.deltaTime;
            if (currentBlend > 1)
            {
                currentBlend = 1;
            }
        }
        else
        {
            if (currentTransparency < 1)
            {
                currentTransparency += GhostFadeSpeed * Time.deltaTime;
                if (currentTransparency > 1)
                {
                    currentTransparency = 1;
                }
            }
        }

        foreach (Material item in materials)
        {
            item.SetFloat("_GhostBlend", currentBlend);
            item.SetFloat("_GhostTransparency", currentTransparency);
        }

    }
}
