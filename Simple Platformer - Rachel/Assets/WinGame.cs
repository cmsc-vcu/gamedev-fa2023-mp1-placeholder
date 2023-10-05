using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject world;

    public AudioSource startMusic;
    public AudioSource winMusic;

    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
        world.SetActive(true);
    }

    public void Run(int input)
    {
        Win();
    }

    private void Win()
    {
        winScreen.SetActive(true);
        world.SetActive(false);
        startMusic.Stop();
        winMusic.Play();
    }
}
