using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extend : MonoBehaviour {

    // Use this for initialization
    public GameObject platform;
    public GameObject enemy;
    public GameObject guide;
    public GameObject parent;
    private int count = 0,r=2;
    private void OnTriggerEnter(Collider other)
    {
        platform.transform.position += new Vector3(0, 0, 25);
        
        float z = guide.transform.position.z;

        for (int i = 0; i <= r; i++)
        {
            float offset = Random.Range((float)10, (float)30) ;
            z += offset;
            enemy.transform.position=new Vector3(Random.Range((float)-1.8,(float)1.8),2,z);
            enemy.transform.rotation = new Quaternion(0, 0, 0, 0);
            enemy = Instantiate(enemy);
            enemy.name = "enemy";
            enemy.transform.localScale = new Vector3(1, 1, 1);
        }
        count += 1;
        if (count == 10)
            r = 3;
        else if (count > 16)
            r = 6;
    }
}
