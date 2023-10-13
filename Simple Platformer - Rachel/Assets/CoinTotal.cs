using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTotal : MonoBehaviour
{
    public GameObject fader;
    public GameObject trophy;
    public GameObject bigCoin;
    public List<GameObject> icons;
    
    private MonoBehaviour faderScript;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        bigCoin.SetActive(false);
        trophy.SetActive(true);
        fader.SetActive(false);
        faderScript = fader.GetComponent<MonoBehaviour>();
        
        for(int i=0; i<icons.Count; i++){
            icons[i].SetActive(false);
            icons[i].GetComponent<Animator>().enabled = false;
        }
    }

    // Update is called once per frame
    void Run(int input)
    {
        if(input >= 1){
            (icons[count]).SetActive(true);
            count++;
            if(count == icons.Count){
                trophy.SetActive(false);
                bigCoin.SetActive(true);

                fader.SetActive(true);
                faderScript.SendMessage("Run", 1);
                StartCoroutine(rotateOn());
            }
        }
    }

    public IEnumerator rotateOn()
    {
        for(int i=0; i<icons.Count; i++){
            icons[i].GetComponent<Animator>().enabled = true;
            yield return new WaitForSeconds(0.16f);
        }
    }
}
