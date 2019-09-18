using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.U2D.Animation;

public class DamageSwapper : MonoBehaviour
{
    public SpriteResolver[] spriteResolvers;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteResolvers = transform.Find("robot").GetComponentsInChildren<SpriteResolver>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            SwapToDamaged();
        }
        else if(Input.GetKeyDown(KeyCode.N))
        {
            SwapToNormal();
        }
    }

    void SwapToDamaged()
    {
        foreach(SpriteResolver resolver in spriteResolvers)
        {
            resolver.SetCategoryAndLabel(resolver.name, "Damaged");
        }
    }

    void SwapToNormal()
    {
        foreach (SpriteResolver resolver in spriteResolvers)
        {
            resolver.SetCategoryAndLabel(resolver.name, "Normal");
        }
    }
}
