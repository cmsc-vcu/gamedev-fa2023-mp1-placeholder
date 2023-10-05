using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    public float range = 0.4f;
    public float speed = 1f;

    private Transform transformer;
    private Vector3 initialPos;
    private bool stopMoving;

    // Start is called before the first frame update
    void Start()
    {
        transformer = GetComponent<Transform>();
        initialPos = transformer.position;
        stopMoving = false;
    }

    void Update()
    {
        if(!stopMoving){
            float sinValue = (float) Mathf.Sin(Time.time * speed);
            float newPosY = initialPos.y + ((float)Mathf.Sin(Time.time) * range);
            transformer.position = new Vector3(transformer.position.x, newPosY, transformer.position.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.tag == "Player"){
            stopMoving = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other){
        if(other.collider.tag == "Player"){
            //StartCoroutine(buffer());
            stopMoving = false;
        }
    }
}
