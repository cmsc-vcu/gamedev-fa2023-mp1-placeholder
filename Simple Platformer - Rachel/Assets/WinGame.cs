using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject world;
    public GameObject startMenu;
    public GameObject player;

    public AudioSource startMusic;
    public AudioSource winMusic;
    public AudioSource bootUp;

    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
        world.SetActive(false);
        startMenu.SetActive(true);
        player.SetActive(false);
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
        while(bootUp.isPlaying){
            yield return new WaitForFixedUpdate();
        }
        yield return new WaitForSeconds(2);
        startMenu.SetActive(false);
        world.SetActive(true);
        player.SetActive(true);
        startMusic.Play();
        Debug.Log("world / player set to active");
    }

    private void Win()
    {
        Debug.Log("world set to inactive");
        Debug.Log("winscreen set to active");
        winScreen.SetActive(true);
        world.SetActive(false);
        startMusic.Stop();
        winMusic.Play();
    }
}
