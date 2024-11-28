using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    double speed = 0.02;
    public static int lifeLeft = 3;
    public static int rprop = 0;
    int fcount = 0;
    public static int flag = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") > 0)
            speedUp();
        if (Input.GetAxis("Horizontal") > 0)
            transform.Translate(new Vector3((float)0.02, 0, 0));
        if (Input.GetAxis("Horizontal") < 0)
            transform.Translate(new Vector3((float)-0.02, 0, 0));
        if (transform.position.z > 9)
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, 9);
        if (transform.position.z < -9)
            transform.localPosition = new Vector3(transform.position.x, transform.position.y, -9);

        if (transform.position.x <= -15)
        {
            transform.Translate(new Vector3(0, 0, -39));
            Car.signal = 6;
            Map.rndCount++;
            speed = 0.02 + 0.01 * Map.rndCount < 0.08 ? 0.02 + 0.01 * Map.rndCount : 0.08;
            rprop = 0;
            lifeLeft++;
        }
        else
        {
            transform.Translate(new Vector3(0, 0, (float)speed));
            if (rprop>0)
                transform.Translate(new Vector3(0, 0, (float)speed));
            this.fcount++;
            if (this.fcount > 60)
            {
                this.fcount = 0;
                rprop--;
                flag--;
            }
        }
    }

    void speedUp()
    {
        rprop = 6;
    }

    void events()
    {
        this.speed = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Cheese")
        {
            flag = 6;
        }

        else if(other.tag=="Banana")
        {
            transform.Translate(new Vector3(0, 0, 2));
        }

        else if(other.tag=="Burger")
        {
            rprop = 6;
        }

        else if(flag<=0)
        {
            transform.localPosition = new Vector3(24, (float)0.2, (float)0.13);
            flag = 0;
            rprop = 0;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cheese")
        {
            flag = 6;
        }

        else if (other.gameObject.tag == "Banana")
        {
            transform.Translate(new Vector3(0, 0, 4));
        }

        else if (other.gameObject.tag == "Burger")
        {
            rprop = 6;
        }

        else if (flag <= 0)
        {
            transform.localPosition = new Vector3(24, (float)0.2, (float)0.13);
            flag = 0;
            rprop = 0;
            lifeLeft--;
            if (lifeLeft<0)
            {
                events();
            }
        }
    }
}
