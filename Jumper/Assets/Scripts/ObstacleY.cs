using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleY : MonoBehaviour
{
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(0, 0.5f, -10);
        speed = Random.Range(0.05f, 0.2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * speed);
        if (transform.localPosition.z > 10)
        {
            Start();
        }
    }
}
