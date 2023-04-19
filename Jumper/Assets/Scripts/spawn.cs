using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject AgentX;
    public GameObject AgentZ;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    float timer = 10f;
    bool start = false;
    public float spawnRateX = 3f;
    public float spawnRateZ = 3f;
    void Update()
    {
        while(true)
        {
            if (timer >= spawnRateX)
            {
                GameObject newAgentX = Instantiate(AgentX, transform.position + transform.forward, AgentX.transform.rotation);
                newAgentX.GetComponent<Rigidbody>().AddForce(transform.forward * 5, ForceMode.VelocityChange);
                GameObject newAgentZ = Instantiate(AgentZ, transform.position + transform.forward, AgentZ.transform.rotation);
                newAgentZ.GetComponent<Rigidbody>().AddForce(transform.forward * 5, ForceMode.VelocityChange);
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
}
