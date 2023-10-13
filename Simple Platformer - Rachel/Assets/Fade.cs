using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public SpriteRenderer fader1;
    public SpriteRenderer fader2;
    private Color colour1;
    private Color colour2;

    public bool hasSecondFader = false;
    public float duration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        //Get current color
        colour1 = fader1.color;
        if(hasSecondFader){
            colour2 = fader2.color;
        }
    }

    public void Run(int input){
        //fade in
        if(input==1){
            StartCoroutine(FadeToBlack(fader1, colour1, duration));
            if(hasSecondFader){
                StartCoroutine(FadeToBlack(fader2, colour2, duration));
            }
        }
        //fade out
        else{
            StartCoroutine(FadeFromBlack(fader1, colour1, duration));
            if(hasSecondFader){
                StartCoroutine(FadeFromBlack(fader2, colour2, duration));
            }
        }
    }

    //black slowly appears / the black screen fades in
    public IEnumerator FadeToBlack(SpriteRenderer fader, Color colour, float duration)
    {
        float counter = 0;
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
    public IEnumerator FadeFromBlack(SpriteRenderer fader, Color colour, float duration)
    {
        float counter = 0;
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
}
