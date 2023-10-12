using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public MonoBehaviour icon;
    public MonoBehaviour nextScript;

    public GameObject parent;
    public AudioSource sound;
    public bool hasIcon = true;
    public bool hasScript = true;

    private SpriteRenderer p;

    private void Start()
    {
        parent.SetActive(true);
        p = parent.GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == ("Player") && p.enabled){
            StartCoroutine(Run());
        }
    }
    
    public IEnumerator Run()
    {
        Debug.Log("Object collected");
        sound.Play();
        if(hasIcon){
            icon.SendMessage("Run", 2);
        }
        if(hasScript){
            nextScript.SendMessage("Run", 2);
        }
        p.enabled = false;
        while(sound.isPlaying){
            yield return new WaitForFixedUpdate();
        }
        parent.SetActive(false);
    }
}
