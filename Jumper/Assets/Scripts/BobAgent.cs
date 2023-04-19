using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class BobAgent : Agent
{
    public Transform Target;
    public override void OnEpisodeBegin()
    {
        // reset de positie en orientatie als de agent gevallen is
        if (transform.localPosition.z != 0)
        {
            transform.localPosition = new Vector3(0, 0.25f, 0);
            transform.localRotation = Quaternion.identity;
        }

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Target enAgent posities
        //sensor.AddObservation(Target.localPosition);
        sensor.AddObservation(transform.localPosition);
    }

    public float speedMultiplier = 0.1f;
    public float rotationMultiplier = 5;
    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        // Acties, size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actionBuffers.ContinuousActions[0]; ;
        transform.Translate(controlSignal * speedMultiplier);
        transform.Rotate(0.0f, rotationMultiplier * actionBuffers.ContinuousActions[1], 0.0f);

        // Beloningen
        float distanceToTarget = Vector3.Distance(transform.localPosition, Target.localPosition);

        // target bereikt
        if (distanceToTarget < 1.42f)
        {
            SetReward(1.0f);
            EndEpisode();
        }
        // Van hetplatform gevallen?
        else if (transform.localPosition.y < 0)
        {
            EndEpisode();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        if (Input.GetKey(KeyCode.Space))
        {
            continuousActionsOut[0] = 1;
        }
    }
}
