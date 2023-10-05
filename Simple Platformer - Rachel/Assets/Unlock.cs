using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    public GameObject lock_sprite;
    public GameObject unlock_sprite;
    public MonoBehaviour popupScript;
    public MonoBehaviour keyScript;
    private bool keyGot;
    private bool firstTime;

    public AudioSource lockedSound;
    public AudioSource unlockedSound;

    // Start is called before the first frame update
    void Start()
    {
        lock_sprite.SetActive(true);
        unlock_sprite.SetActive(false);
        keyGot = false;
        firstTime = true;
    }

    public void Run(int val)
    {
        if(val == 0){
            if(keyGot){
                StartCoroutine(Un_lock());
            }
            else{
                lockedSound.Play();
            }
        }
        else if(val == 1 && keyGot){
            lockedSound.Play();
            Lock();
        }
        else if(val == 2){
            getKey();
        }
    }

    private void getKey(){
        keyGot = true;
        popupScript.SendMessage("Run", 4);
    }

    public IEnumerator Un_lock()
    {
        //set correct sprites to be active
        lock_sprite.SetActive(false);
        unlock_sprite.SetActive(true);
        //then play sound after
        if(firstTime){
            unlockedSound.Play();
            keyScript.SendMessage("Run", 1);
            firstTime = false;
        }
        yield return new WaitForSeconds(1);
        popupScript.SendMessage("Run", 5);
    }

    private void Lock()
    {
        //set correct sprites
        lock_sprite.SetActive(true);
        unlock_sprite.SetActive(false);
        popupScript.SendMessage("Run", 3);
    }
}
