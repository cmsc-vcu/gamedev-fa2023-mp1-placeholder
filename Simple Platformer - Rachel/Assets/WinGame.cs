using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    //screens
    public GameObject winScreen;
    public GameObject world;
    public GameObject startMenu;
    public GameObject player;
    public GameObject fader;

    //audio
    private AudioSource inGameMusic;
    private AudioSource winMusic;
    private AudioSource bootUp;

    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
        world.SetActive(false);
        player.SetActive(false);

        inGameMusic = GetComponent<AudioSource>();
        winMusic = winScreen.GetComponent<AudioSource>();
        bootUp = startMenu.GetComponent<AudioSource>();
        
        startMenu.SetActive(true);
        StartCoroutine(StartMenu());
    }

    public void Run(int input)
    {
        Win();
    }

    public IEnumerator StartMenu()
    {
        Debug.Log("booting up sequence...");
        bootUp.Play();
        yield return new WaitForSeconds(5);
        fader.SendMessage("Run", 2);
        while(bootUp.isPlaying){
            yield return new WaitForFixedUpdate();
        }
        startMenu.SetActive(false);
        world.SetActive(true);
        player.SetActive(true);
        inGameMusic.Play();
        Debug.Log("world / player set to active");
    }

    private void Win()
    {
        Debug.Log("world set to inactive");
        Debug.Log("winscreen set to active");
        winScreen.SetActive(true);
        world.SetActive(false);
        inGameMusic.Stop();
        winMusic.Play();
    }
}
