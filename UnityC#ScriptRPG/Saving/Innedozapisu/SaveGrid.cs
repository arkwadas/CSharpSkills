using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.SceneManagement;
using RPG.Core;
using GameDevTV.Saving;

public class SaveGrid : MonoBehaviour, ISaveable
{
    public object CaptureState()
    {
        /*Dictionary<string, object> data = new Dictionary<string, object>();
        data["position"] = new SerializableVector3(transform.position);
        data["rotation"] = new SerializableVector3(transform.eulerAngles);
        return data;*/
        return new SerializableVector3(transform.position);
    }

    public void RestoreState(object state)
    {
        /*Dictionary<string, object> data = (Dictionary<string, object>)state;
        GetComponent<NavMeshAgent>().enabled = false;
        transform.position = ((SerializableVector3)data["position"]).ToVector();
        transform.eulerAngles = ((SerializableVector3)data["rotation"]).ToVector();
        GetComponent<NavMeshAgent>().enabled = true;*/
        SerializableVector3 position = (SerializableVector3)state;
        //navMeshAgent.enabled = false;
        transform.position = position.ToVector();
        //navMeshAgent.enabled = true;
        //GetComponent<ActionScheduler>().CancelCurrentAction();
    }
}
