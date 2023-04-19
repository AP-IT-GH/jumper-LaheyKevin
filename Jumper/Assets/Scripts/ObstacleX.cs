using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleX : MonoBehaviour
{
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(-10, 0.5f, 0);
        transform.localScale = new Vector3(1, 1, 1);
        speed = Random.Range(0.05f, 0.2f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed);
        if (transform.localPosition.x > 10)
        {
            Start();
        }
    }
}
