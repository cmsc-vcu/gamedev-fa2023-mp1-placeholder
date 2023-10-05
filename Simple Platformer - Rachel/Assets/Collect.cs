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

    public void Run(int input)
    {
        sound.Play();
        parent.SetActive(false);
        icon.SendMessage("GetObj", 0f);
        nextScript.SendMessage("Run", input);
    }
}
