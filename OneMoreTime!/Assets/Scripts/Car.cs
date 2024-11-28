using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : Block
{

    public static int signal=0;
    // Start is called before the first frame update
    void Start()
    {
        this.prop = 1;
        this.speed = (float)(0.02 + 0.01 * Map.rndCount < 0.08 ? 0.02 + 0.01 * Map.rndCount : 0.08);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x >= 24 || transform.position.z >= 9 || transform.position.x <= -15 || transform.position.z <= -9)
        {
            transform.Rotate(new Vector3(0, 180, 0));
            
        }
        transform.Translate(new Vector3(0, 0, (float)speed));
        if (signal >0)
        {
            int px = Random.Range(-5, 5);
            int pz = Random.Range(-5, 5);
            transform.localPosition = new Vector3(px, (float)0.19, pz);
            int ry = Random.Range(0, 360);
            transform.Rotate(new Vector3(0, ry, 0));
            speed = (float)(0.02 + 0.01 * Map.rndCount < 0.08 ? 0.02 + 0.01 * Map.rndCount : 0.08);
            signal--;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.Rotate(new Vector3(0, 180, 0));
    }

}
