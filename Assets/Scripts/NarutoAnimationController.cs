using UnityEngine;
using System.Collections;

public class NarutoAnimationController : MonoBehaviour {

    static Animator animation; bool isHurting = false,isSkill=false; float timeendhurt,timeRasengan;
    
    void Start ()
    {
        animation= gameObject.GetComponent<Animator>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (animation.GetBool("isRasengan") && Time.time >= timeRasengan)
                animation.SetBool("isRasengan", false);
            if (isHurting)
            {
                if (Time.time >= timeendhurt) isHurting = false;
            }
            else
                Move();
        }
        if (other.gameObject.tag == "Dmg")
        {
            Hurt();
        }
        
        
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            if (isSkill && Time.time >= timeRasengan)
            {
                isSkill = false;
                animation.SetBool("isRasengan", false); 
            }
            if (isHurting)
            {
                if (Time.time >= timeendhurt) isHurting = false;
            }
            else 
            Move();
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Dmg")
        {
            Hurt(); 
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Jump();
        }
    }
    public void Move()
    {
        animation.SetBool("isRunning", true);         
        animation.SetBool("isHurt", false);
        animation.SetBool("isJump", false);
    }
    public void Stand()
    {
        animation.SetBool("isRasengan", false); animation.SetBool("isRunning", false);
        animation.SetBool("isJump", false);
        
    }
    public void Rasengan()
    {
        timeRasengan = Time.time + 1f;
        isSkill = true;
        animation.SetBool("isRasengan", true);
        animation.SetBool("isHurt", false);
        animation.SetBool("isRunning", false);
        
    }
    public void Jump()
    {
        animation.SetBool("isJump", true);
        animation.SetBool("isRunning", false);
        animation.SetBool("isRasengan", false);
    }
    public void Hurt()
    {
        isHurting = true;
        timeendhurt = Time.time + .25f;
        if(!isSkill)       
        animation.SetBool("isHurt", true);
        animation.SetBool("isRunning", false);
        animation.SetBool("isJump", false);
        
    }
}
