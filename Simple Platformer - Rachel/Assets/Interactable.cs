using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool hasNextScript = true;
    public int input = 0;
    public MonoBehaviour nextScript;
    
    public bool hasAudio = true;
    private AudioSource sound;

    bool busy;

    private void Start()
    {
        busy = false;
        sound = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.tag == ("Player")){
            if(hasAudio){
                StartCoroutine(playSound());
            }
            if(hasNextScript){
                nextScript.SendMessage("Run", input);
            }
        }
    }

    public IEnumerator playSound()
    {
        // prevent multiple concurrent routines
        if(busy) yield break;
        busy = true;
        sound.Play();
        yield return new WaitForSeconds(2);
        busy = false;
    }
}
