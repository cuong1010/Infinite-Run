using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBehaviour : MonoBehaviour {
    UIBehaviour UI;
    public float dmgamount;
	// Use this for initialization
	void Start () {
        UI = GameObject.FindGameObjectWithTag("Player").GetComponent<UIBehaviour>();
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            UI.TakeDamge(dmgamount);
        }
        
    }
	
}
