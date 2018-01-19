using UnityEngine;
using System.Collections;

public class GroundGenerator: MonoBehaviour {
    public GameObject[] ground;
	// Use this for initialization
    float size;   
    public float minDistance=1,maxDistance=3.5f;
	void Start () {
      
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spawn") SpawnGround();
        float distance = Random.Range(minDistance,maxDistance+1);
        gameObject.transform.position = new Vector3(transform.position.x+.3f + distance + size,
            transform.position.y, transform.position.z);
       
    }
    void SpawnGround()
    {
        int r=Random.Range(0, ground.Length);
        Instantiate(ground[r], new Vector3(transform.position.x,transform.position.y), Quaternion.identity);
        //get Size depend on Sprite of that Ground
        size = ground[r].GetComponent<Renderer>().bounds.size.x;
        
    }
	// Update is called once per frame
	void Update () {
       
	}
}
