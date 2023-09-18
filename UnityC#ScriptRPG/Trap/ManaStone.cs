using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaStone : MonoBehaviour
{
    public float maxMana = 100.0f;
    public float manaRegenerationRate = 5.0f;

    private float currentMana;
    private float manaRegenerationTimer;
    private bool playerInRange;

    private void Start()
    {
        currentMana = maxMana;
    }

    private void Update()
    {
        if (!playerInRange)
        {
            manaRegenerationTimer += Time.deltaTime;
            if (manaRegenerationTimer >= manaRegenerationRate)
            {
                currentMana = Mathf.Min(currentMana + 1.0f, maxMana);
                manaRegenerationTimer = 0.0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInRange = false;
        }
    }

    public float DrainMana(float amount)
    {
        float drainedMana = Mathf.Min(currentMana, amount);
        currentMana -= drainedMana;
        return drainedMana;
    }
}
