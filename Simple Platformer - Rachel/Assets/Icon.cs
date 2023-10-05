using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    public SpriteRenderer render;
    public int numUses = 1;

    // Start is called before the first frame update
    void Start()
    {
        render.enabled = false;
    }

    public void Run(int input)
    {
        if(input == 0){
            GetObj();
        }
        else if(input == 1){
            if(numUses > 0){
                UseObj();
            }
        }
    }

    public void GetObj()
    {
        render.enabled = true;
    }

    public void UseObj()
    {
        numUses--;
        if(numUses == 0){
            render.enabled = false;
        }
    }
}
