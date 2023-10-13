using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Proximity : MonoBehaviour
{
    private InputActionAsset actions;
    public bool activated = false;

    public SpriteRenderer parent;
    public MonoBehaviour runScript;
    public int inputForScript = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        actions = GetComponent<PlayerInput>().actions;
        parent.enabled = false;
    }

    public void Run(int input)
    {
        if(input == 1)
        {
            Debug.Log("Proximity text is activated");
            activated = true;
        }
        else if(input == 2)
        {
            Debug.Log("Proximity text is deactivated");
            activated = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == ("Player")){
            if(activated)
            {
                Debug.Log("Proximity text appears; was activated");
                parent.enabled = true;
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == ("Player")){
            parent.enabled = false;
        }
    }

    //When player presses "E"
    public void OnUse()
    {
        //If the popup is currently visible
        if(parent.enabled)
        {
            Debug.Log("Proximity text prompt accepted, user pressed \"E\"");
            runScript.SendMessage("Run", inputForScript);
            parent.enabled = false;
            activated = false;
        }
    }
}
