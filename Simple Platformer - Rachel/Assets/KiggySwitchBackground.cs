using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiggySwitchBackground : MonoBehaviour
{
    ////the stuffs
    //public List<GameObject> display;

    //private static int listIndex;
    //private static int backgroundIndex;
    //private static int foregroundIndex;

    //private void Start()
    //{
    //    listIndex = 0;
    //    backgroundIndex = -1;
    //    foregroundIndex = -1;
    //    display[backgroundIndex].SetActive(true);
    //    for(int i=1; i<display.Count; i++){
    //        display[i].SetActive(false);
    //    }
    //}

    //public void Run(int side)
    //{
    //    switch(listIndex)
    //    {
    //        case 3:
    //            if(side == -1){
    //                //left
    //                display[listIndex].SetActive(false);
    //                foregroundIndex += side;
    //            }
    //            else{
    //                ChangeForeground();
    //            }
    //            break;
    //        case 2:
    //            if(side == 1){
    //                //right
    //                ChangeForeground();
    //            }
    //            else{
    //                ChangeBackground();
    //            }
    //            break;
    //    }
    //    Continue();
    //}

    //private void ChangeForeground(int amount)
    //{
    //    display[listIndex].SetActive(false);
    //    foregroundIndex += amount;
    //    if(foregroundIndex == display.Count){ 
    //        foregroundIndex = 0;
    //    }
    //    else if(foregroundIndex <= 0){
    //        foregroundIndex = display.Count-1;
    //    }
    //    display[foregroundIndex].SetActive(true);
    //}

    //private void ChangeBackground(int amount)
    //{
    //    display[backgroundIndex].SetActive(false);
    //    backgroundIndex += amount;
    //    if(backgroundIndex == display.Count){ 
    //        backgroundIndex = 0;
    //    }
    //    else if(backgroundIndex <= 0){
    //        backgroundIndex = display.Count-1;
    //    }
    //    display[backgroundIndex].SetActive(true);
    //}

    //private void ChangeBoth()
    //{

    //}

    //private void Continue()
    //{
    //    listIndex += side;
    //    if (listIndex == display.Count)  
    //    { listIndex = 0; }
    //    if (listIndex <= 0)  
    //    { listIndex = display.Count-1; }
    //}
}
