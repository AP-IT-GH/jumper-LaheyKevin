using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class BobAgent : Agent
{
    Rigidbody my_Rigidbody;

    public float jumpMultiplier = 10;
    private bool hit = false;
    private bool collide = false;

    private void Start()
    {
        my_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        RaycastHit ObstacleHit;
        Ray ObstacleRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ObstacleRay, out ObstacleHit, 5f))
        {
            if (ObstacleHit.collider.tag == "Target" && !hit)
            {
                AddReward(3f);
                hit = true;
            }
        }
    }

    public override void OnEpisodeBegin()
    {
        my_Rigidbody.angularVelocity = Vector3.zero;
        my_Rigidbody.velocity = Vector3.zero;
        transform.localPosition = new Vector3(0, 0.5f, 0);
        transform.localRotation = new Quaternion(0, -0.92388f, 0, 0.38268f);
        collide = false;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        //Agent positie
        sensor.AddObservation(transform.localPosition);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Target")
        {
            collide = true;
        }
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Acties, size = 1
        Vector3 controlSignal = Vector3.zero;
        controlSignal.y = actionBuffers.ContinuousActions[0];
        
        //Als de agent moet springen en op de grond staat
        if (controlSignal.y == 1 && transform.localPosition.y <= 0.5f)
        {
            my_Rigidbody.AddForce(Vector3.up * jumpMultiplier, ForceMode.Impulse);
            AddReward(-1f);
        }
        // Als agent onder de grond is of een blok aanraakt
        if (transform.localPosition.y < 0 || collide) 
        {
            SetReward(-2f);
            EndEpisode();
        }
        //Als agent op de grond staat
        else if (transform.localPosition.y < 0.5f)
        {
            hit = false;  
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        //Gebruik spatie om te springen
        var continuousActionsOut = actionsOut.ContinuousActions;

        if (Input.GetKey(KeyCode.Space))
        {
            continuousActionsOut[0] = 1;
        }
    }
}
