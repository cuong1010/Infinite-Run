using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteorite : MonoBehaviour {

    Animator ani;
    bool ishit = false;
    BoxCollider2D rigid;
    AudioManager audio;
    UIBehaviour ui;
    public float Dmg=15;
	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();
        rigid = GetComponent<BoxCollider2D>();
        audio = GameObject.Find("SoundBehavior").GetComponent<AudioManager>();
        ui = GameObject.FindGameObjectWithTag("Player").GetComponent<UIBehaviour>();
       
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        ishit = true;
        ani.enabled = true;
        rigid.enabled = false;
        if (other.gameObject.tag =="Player") ui.TakeDamge(Dmg);       
        Destroy(gameObject, .75f);


    }
	// Update is called once per frame
	void Update () {
        if(!ishit)
		transform.Translate(new Vector3(-.15f,-.15f,0));
	}
}
