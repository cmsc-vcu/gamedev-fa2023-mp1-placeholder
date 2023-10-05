using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour
{
    public AudioSource popupSound;
    public GameObject window;
    private bool activated;
    private bool alreadyActivated;
    
    // Start is called before the first frame update
    void Start()
    {
        window.SetActive(false);
        activated = false;
        alreadyActivated = false;
    }

    public void Run(int input)
    {
        if(input == 4){  activated = true;  }
        else if(input == 3){
            activated = false;
            Go();
        }
        else if(input == 5){
            Go();
        }
    }

    //POP UP! ACTIVATE
    private void Go()
    {
        if(activated)
        {
            window.SetActive(true);
            if(!alreadyActivated){
                popupSound.Play();
                alreadyActivated = true;
            }
        }
        else{
            window.SetActive(false);
            alreadyActivated = false;
        }
    }
}
