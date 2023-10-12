using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private SpriteRenderer fader;
    private Color colour;

    // Start is called before the first frame update
    void Start()
    {
        fader = GetComponent<SpriteRenderer>();
        //Get current color
        colour = fader.color;    
    }

    //black slowly appears / the black screen fades in
    public IEnumerator FadeToBlack(float duration)
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
    public IEnumerator FadeFromBlack(float duration)
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
