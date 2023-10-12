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

    //audio
    private AudioSource inGameMusic;
    private AudioSource winMusic;
    private AudioSource bootUp;

    //fade in
    public SpriteRenderer fader;

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
        yield return new WaitForSeconds(2);
        StartCoroutine(fadeFromBlack(2f));
        while(bootUp.isPlaying){
            yield return new WaitForFixedUpdate();
        }
        startMenu.SetActive(false);
        world.SetActive(true);
        player.SetActive(true);
        inGameMusic.Play();
        Debug.Log("world / player set to active");
    }

    //black slowly appears / the black screen fades in
    public IEnumerator fadeToBlack(float duration)
    {
        float counter = 0;
        //Get current color
        Color colour = fader.color;
        //Set to fully transparent
        fader.color = new Color(colour.r, colour.g, colour.b, 0);

        while(counter < duration)
        {
            counter += Time.deltaTime;
            //Fade in from 0 to 1
            float alpha = Mathf.Lerp(0, 1, counter / duration);
            //Change alpha only
            fader.color = new Color(colour.r, colour.g, colour.b, alpha);
            //Wait for a frame
            yield return null;
        }
    }

    //black slowly disappears / the black screen fades out
    public IEnumerator fadeFromBlack(float duration)
    {
        float counter = 0;
        //Get current color
        Color colour = fader.color;
        //Set to fully opaque
        fader.color = new Color(colour.r, colour.g, colour.b, 1);

        while(counter < duration)
        {
            counter += Time.deltaTime;
            //Fade out from 1 to 0
            float alpha = Mathf.Lerp(1, 0, counter / duration);
            //Change alpha only
            fader.color = new Color(colour.r, colour.g, colour.b, alpha);
            //Wait for a frame
            yield return null;
        }
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
