using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public AudioSource popupSound;
    public GameObject window;
    private bool activated;
    private bool firstTime;
    
    // Start is called before the first frame update
    void Start()
    {
        window.SetActive(false);
        activated = false;
        firstTime = true;
    }

    public void Run(int input)
    {
        if(input == 4){
            Debug.Log("Popup is activated");
            activated = true;
        }
        else if(input == 3){
            Debug.Log("Popup deactivated");
            activated = false;
            Go();
        }
        else if(input == 5){
            Debug.Log("Try to open popup");
            Go();
        }
        else if(input == 6){
            Debug.Log("Activate popup and open it");
            activated = true;
            Go();
        }
    }

    //POP UP! ACTIVATE
    private void Go()
    {
        if(activated)
        {
            Debug.Log("Popup opens; was activated");
            window.SetActive(true);
            if(firstTime){
                Debug.Log("Popup sound is played");
                popupSound.Play();
                firstTime = false;
            }
        }
        else{
            Debug.Log("Couldn't open popup; wasn't activated");
            window.SetActive(false);
            firstTime = true;
        }
    }
}
