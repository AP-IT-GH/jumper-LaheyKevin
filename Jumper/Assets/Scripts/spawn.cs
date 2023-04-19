using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject TargetX;
    public GameObject TargetZ;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    float timer = 10f;
    bool start = false; 
    public float spawnRate = 3f;
    void Update()
    {
            if (timer >= spawnRate)
            {
               Vector3 positionTargetX = new Vector3(10, (float)0.5, 0);
               Vector3 positionTargetZ = new Vector3(0, (float)0.5, 20);
               GameObject newTargetX = Instantiate(TargetX, positionTargetX + transform.forward, TargetX.transform.rotation);
               newTargetX.GetComponent<Rigidbody>().AddForce(transform.forward * 5, ForceMode.VelocityChange);
               GameObject newTargetZ = Instantiate(TargetZ, positionTargetZ + transform.forward, TargetZ.transform.rotation);
               newTargetZ.GetComponent<Rigidbody>().AddForce(transform.forward * 5, ForceMode.VelocityChange);
               start = true;
               timer = 0f;
            }

            if (start)
            {
               timer += Time.deltaTime;
               start = false;
            }
    }
}
