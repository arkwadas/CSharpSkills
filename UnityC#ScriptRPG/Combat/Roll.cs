using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public float flipSpeed = 1.0f;
    public AnimationCurve rotationCurve;

    private enum FlipDirection { Forward, Backward, Left, Right }
    private Coroutine flipCoroutine;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartFlip(FlipDirection.Forward);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            StartFlip(FlipDirection.Backward);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            StartFlip(FlipDirection.Left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            StartFlip(FlipDirection.Right);
        }
    }

    void StartFlip(FlipDirection direction)
    {
        if (flipCoroutine != null)
        {
            StopCoroutine(flipCoroutine);
        }
        flipCoroutine = StartCoroutine(Flip(direction));
    }

    IEnumerator Flip(FlipDirection direction)
    {
        float time = 0.0f;
        Quaternion startRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, 0, 0);

        switch (direction)
        {
            case FlipDirection.Forward:
                targetRotation = Quaternion.Euler(-360, 0, 0);
                break;
            case FlipDirection.Backward:
                targetRotation = Quaternion.Euler(360, 0, 0);
                break;
            case FlipDirection.Left:
                targetRotation = Quaternion.Euler(0, 0, 360);
                break;
            case FlipDirection.Right:
                targetRotation = Quaternion.Euler(0, 0, -360);
                break;
        }

        while (time < 1.0f)
        {
            time += Time.deltaTime * flipSpeed;
            float curveValue = rotationCurve.Evaluate(time);
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, curveValue);
            yield return null;
        }

        transform.rotation = startRotation;
    }
}