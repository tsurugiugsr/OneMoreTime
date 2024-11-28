using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
    int prop = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Car.signal>0)
        {
            int px = Random.Range(-6, 6);
            int pz = Random.Range(-6, 6);
            transform.localPosition = new Vector3(px, (float)0.2, pz);
            Car.signal--;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
            transform.Translate(new Vector3(0, -10, 2));
    }
}
