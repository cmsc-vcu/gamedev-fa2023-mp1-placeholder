using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTotal : MonoBehaviour
{
    public MonoBehaviour fader;
    public GameObject trophy;
    public GameObject bigCoin;
    public List<GameObject> icons;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        bigCoin.SetActive(false);
        trophy.SetActive(true);
        
        for(int i=0; i<icons.Count; i++){
            icons[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Run(int input)
    {
        if(input >= 1){
            count++;
            icons[count-1].SetActive(false);
            if(count == icons.Count){
                trophy.SetActive(false);
                bigCoin.SetActive(true);
                fader.SendMessage("FadeToBlack", 2.0f);
            }
        }
    }
}
