using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public MonoBehaviour icon;

    public GameObject parent;
    public MonoBehaviour nextScript;
    public AudioSource sound;

    private void Start()
    {
        parent.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == ("Player")){
            Debug.Log("Object collected");
            sound.Play();
            parent.SetActive(false);
            icon.SendMessage("Run", 2);
            nextScript.SendMessage("Run", 2);
        }
    }
}
