using UnityEngine;
using System.Collections;

public class Naruto : MonoBehaviour {
    Rigidbody2D rigid;
    bool locked = false;
    bool onGround,isStart = false;
    public int speed = 8;
    AudioManager audio;
    UIBehaviour UI;
    float distance;
    NarutoAnimationController animate;
	// Use this for initialization
	void Start () {
        
        rigid = gameObject.GetComponent<Rigidbody2D>();
        audio=GameObject.Find("SoundBehavior").GetComponent<AudioManager>();
        UI = GetComponent<UIBehaviour>();
        distance = Camera.main.transform.position.x - transform.position.x;
        animate = GetComponent<NarutoAnimationController>();
	}
	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {          
            onGround = true;
            if (isStart == false) isStart = true;
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            
            onGround = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin") 
        {
            audio.PlayMusic(1);
            Destroy(other.gameObject);
            UI.IncreaseMana(10);
            UI.UpdatePoint(20);
        }
        if (other.gameObject.name == "Heal")
        {
            Destroy(other.gameObject);
            UI.Heal(20);
        }
    }   
	// Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            //locked = animation.GetCurrentAnimatorStateInfo(0).IsName("NarutoRasengan");
            UI.UpdatePoint(1);
            gameObject.transform.Translate(Vector2.right * speed * Time.deltaTime);
            
            Camera.main.transform.position = new Vector3(transform.position.x + distance, Camera.main.transform.position.y, Camera.main.transform.position.z);
            if (Input.GetKey(KeyCode.J) && onGround && UI.currentmana==UI.maxmana)
            {
                
                audio.PlayMusic(2);
                animate.Rasengan();
                UI.UseSkill();
                rigid.velocity = Vector2.right *5f;
            }

            if (Input.GetKey(KeyCode.K) && onGround)
            {
                
                //rigid.velocity = new Vector2(rigid.velocity.x,8);    
                rigid.AddForce(Vector3.up*400);
                onGround = false;

            }
            
        }
    }

    public UIBehaviour UIbehaviour { get; set; }
}
