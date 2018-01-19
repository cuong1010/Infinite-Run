using UnityEngine;
using System.Collections;

public class AutoGenerater : MonoBehaviour {
   public int minNumber=1,maxNumber=5;
   public int minTime = 10, maxTime =20,timeStart;
   public GameObject GameObj;
	// Use this for initialization
	void Start () {
        InvokeRepeating("Spawn",timeStart,Random.Range(minTime,maxTime));
	}
   
    void Spawn()
    {
        if (maxNumber == 1) Instantiate(GameObj, new Vector3(transform.position.x, transform.position.y), Quaternion.identity);
        else
        {
            int n = Random.Range(minNumber, maxNumber+1);
            float x = transform.position.x;
            for (int i = 1; i <= n; i++)
            {
                Instantiate(GameObj, new Vector3(x, transform.position.y), Quaternion.identity);
                x += 2;
            }
        }
        
    }
	// Update is called once per frame
	void Update () {
      

	
	}
}
