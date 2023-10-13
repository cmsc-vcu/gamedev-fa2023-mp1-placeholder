using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBackground : MonoBehaviour
{
    //the stuffs
    public List<GameObject> display;
    private int backgroundIndex;

    private void Start()
    {
        backgroundIndex = 0;
        display[backgroundIndex].SetActive(true);
        for(int i=1; i<display.Count; i++){
            display[i].SetActive(false);
        }
    }

    public void Run(int side)
    {
        Debug.Log("Current bkgrnd is " + backgroundIndex);
        if(side == 0 || side == -1){
            Previous();
        }
        if(side == 1){
            Next();
        }
    }

    public void Next()
    {
        display[backgroundIndex].SetActive(false);
        if (backgroundIndex == display.Count - 1)  
        { backgroundIndex = 0; }
        else  
        { backgroundIndex++; }
        display[backgroundIndex].SetActive(true);
        Debug.Log("Switched to " + backgroundIndex);
    }

    public void Previous()
    {
        display[backgroundIndex].SetActive(false);
        if (backgroundIndex == 0)  
        { backgroundIndex = display.Count-1; }
        else  
        { backgroundIndex--; }
        display[backgroundIndex].SetActive(true);
        Debug.Log("Switched to " + backgroundIndex);
    }
}
