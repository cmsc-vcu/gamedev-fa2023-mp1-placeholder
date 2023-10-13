using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    public SpriteRenderer render;
    public int numUses = 1;
    public bool hasNextScript = false;
    public MonoBehaviour popUpScript;
    
    public bool hasSound = false;
    private AudioSource useSound;

    // Start is called before the first frame update
    void Start()
    {
        render.enabled = false;
        if(hasSound){
            useSound = GetComponent<AudioSource>();
        }
    }

    public void Run(int input)
    {
        if(input == 0 || input == 2){
            if(!render.enabled){
                GetObj();
            }
        }
        else if(input == 1){
            if(numUses > 0){
                UseObj();
            }
        }
    }

    public void GetObj()
    {
        Debug.Log("Object collected, icon visibility enabled");
        render.enabled = true;
        if(hasNextScript){
            Debug.Log("Icon runs attached popup script");
            popUpScript.SendMessage("Run", 4);
        }
    }

    public void UseObj()
    {
        Debug.Log("Object used once, number of uses goes down");
        numUses--;
        if(numUses == 0){
            Debug.Log("No more uses, icon disappears");
            render.enabled = false;
        }
        if(hasSound){  useSound.Play();  }
        if(hasNextScript){
            Debug.Log("Icon runs attached popup script");
            popUpScript.SendMessage("Run", 5);
        }
    }


    //maybe use for later?
    public bool isEnabled()
    {
        return render.enabled;
    }

    public void setUses(int newNumUses)
    {
        Debug.Log("Change number of uses for object");
        numUses = newNumUses;
    }
}
