using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock : MonoBehaviour
{
    public GameObject lock_sprite;
    public GameObject unlock_sprite;
    public MonoBehaviour popupScript;
    public MonoBehaviour keyIconScript;
    public MonoBehaviour proximityAppear;
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
        if(val == -1){
            if(!keyGot){
                Debug.Log("Cannot open folder, it is locked");
                lockedSound.Play();
            }
        }
        if(val == 0){
            if(keyGot){
                Debug.Log("CAN open folder, it is unlocked");
                StartCoroutine(Un_lock());
            }
        }
        //else if(val == 1 && keyGot){
        //    lockedSound.Play();
        //    Lock();
        //}
        else if(val == 2){
            getKey();
        }
    }

    private void getKey()
    {
        Debug.Log("key marked as gotton in folder unlock script");
        keyGot = true;
        popupScript.SendMessage("Run", 4);
        proximityAppear.SendMessage("Run", 1);
    }

    public IEnumerator Un_lock()
    {
        //set correct sprites to be active
        Debug.Log("change folder sprites, run Un_lock");
        lock_sprite.SetActive(false);
        unlock_sprite.SetActive(true);
        //then play sound after
        if(firstTime){
            Debug.Log("play unlock sound for first and only time");
            unlockedSound.Play();
            keyIconScript.SendMessage("Run", 1);
            firstTime = false;
        }
        while(unlockedSound.isPlaying){
            yield return new WaitForFixedUpdate();
        }
        popupScript.SendMessage("Run", 5);
    }

    //private void Lock()
    //{
    //    Debug.Log("Lock is locked");
    //    //set correct sprites
    //    lock_sprite.SetActive(true);
    //    unlock_sprite.SetActive(false);
    //    popupScript.SendMessage("Run", 3);
    //}
}
