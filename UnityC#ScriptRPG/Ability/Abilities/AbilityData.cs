using System;
using System.Collections;
using System.Collections.Generic;
using MoreMountains.TopDownEngine;
using RPG.Core;
using UnityEngine;

public class AbilityData : IAction
{
    GameObject user;
    //amienione Vector3 na Health
    Health targetedPoint;
    Vector3 targetedPoint2;
    IEnumerable<GameObject> targets;
    bool cancelled = false;

    public AbilityData(GameObject user)
    {
        this.user = user;
    }

        public IEnumerable<GameObject> GetTargets()
    {
        return targets;
    }

    public void SetTargets(IEnumerable<GameObject> targets)
    {
        this.targets = targets; 
    }

    //amienione Vector3 na Health
    public Health GetTargetedPoint()
    {
        return targetedPoint;
    }
    public Vector3 GetTargetedPoint2()
    {
        return targetedPoint2;
    }

    //amienione Vector3 na Health
    public void SetTargetedPoint(Health targetedPoint)
    {
        this.targetedPoint = targetedPoint;
    }
    public void SetTargetedPoint2(Vector3 targetedPoint2)
    {
        this.targetedPoint2 = targetedPoint2;
    }

    public GameObject GetUser()
    {
        return user;
    }

    public void StartCoroutine(IEnumerator coroutine)
    {
        user.GetComponent<MonoBehaviour>().StartCoroutine(coroutine);
    }

    public void Cancel()
    {
        cancelled = true;
    }

    public bool IsCancelled()
    {
        return cancelled;
    }
}