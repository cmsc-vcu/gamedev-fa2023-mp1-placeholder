using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementCycle : MonoBehaviour
{
    public Sprite[] sprites;
    private SpriteRenderer body;
    public float maxVelocity = 3.5f;
    public float speed = 8f;
    public float thrust = 7f;
    private bool touchingGround;

    private InputActionAsset actions;
    private Transform pos;
    private Rigidbody2D player;
    private AudioSource sound;
    //private bool busy;

    // Start is called before the first frame update
    void Start()
    {
        actions = GetComponent<PlayerInput>().actions;
        pos = GetComponent<Transform>();
        player = GetComponent<Rigidbody2D>();
        body = GetComponent<SpriteRenderer>();
        sound = GetComponent<AudioSource>();

        //initial values
        body.sprite = sprites[0];
        touchingGround = false;
        pos.position = new Vector3(0.0f, -4.0f, 0.0f);
        //busy = false;
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.collider.tag == "Ground"){
            touchingGround = true;
        }
    }
    
    private void OnCollisionExit2D(Collision2D other){
        if(other.collider.tag == "Ground"){
            //StartCoroutine(buffer());
            touchingGround = false;
        }
    }

    //public IEnumerator buffer()
    //{
    //    // prevent multiple concurrent routines
    //    if(busy) yield break;
    //    busy = true;
    //    yield return new WaitForSeconds(0.1f);
    //    busy = false;
    //    touchingGround = false;
    //}

    private void FixedUpdate()
    {
        Vector2 value = actions.FindAction("Move").ReadValue<Vector2>();
        //do this
        //Vector3 nextPos = new Vector3(value.x * speed * Time.deltaTime, 0, 0);
        //pos.position = pos.position + nextPos;
        //or do this
        if(player.velocity.x < maxVelocity && player.velocity.x > (-1*maxVelocity))
        {
            player.AddForce(value*speed);
        }
        else if( (player.velocity.x <= maxVelocity && value.x > 0) || (player.velocity.x >= (-1*maxVelocity) && value.x < 0) )
        {
            player.AddForce(value*speed*1.3f);
        }
    }

    public void OnJump()
    {
        if(touchingGround){
            sound.Play();
            player.AddForce(pos.up * thrust, ForceMode2D.Impulse);
        }
    }

    public void SetSpriteHand()
    {
        Debug.Log("Switch player sprite to hand");
        body.sprite = sprites[0];
    }
    public void SetSpriteCursor()
    {
        Debug.Log("Switch player sprite to cursor");
        body.sprite = sprites[1];
    }
}
