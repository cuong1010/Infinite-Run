using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        Destroy(other.gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            Debug.Break();
        if (gameObject.tag == "Skill")
            Destroy(other.gameObject);
    }
}
