using MoreMountains.TopDownEngine;
using RPG.Audio;
using RPG.Combat;
using RPG.Stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barier : MonoBehaviour
{
    public GameObject targetObject;
    public ParticleSystem particleSystem;
    public float manaCostPerSecond = 20.0f;
    public float manaCost;

    public Mana manaScript;
    private bool isActive = false;
    [SerializeField] string sound;

    private void Start()
    {
       // manaScript = GetComponent<ManaScript>();
        if (manaScript == null)
        {
            Debug.LogWarning("Skrypt Mana nie zosta³ znaleziony na obiekcie " + gameObject.name + ".");
        }
    }

    private void Update()
    {
       
    }

    public bool ExecuteSpecialAttack()
    {
        if (manaScript.UseMana(manaCost))
        {
            // wykonaj atak specjalny
            return true;
        }
        else
        {
            // postaæ nie ma wystarczaj¹cej iloœci many
            return false;
        }
    }

    public void BarrierSkill()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isActive = true;
            targetObject.SetActive(true);
            FindObjectOfType<AudioManager>().Play(sound);
            particleSystem.Play();
            //ExecuteSpecialAttack();
        }
        if (Input.GetMouseButtonUp(1))
        {
            isActive = false;
            targetObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play(sound);
            particleSystem.Stop();
        }

        if (isActive && manaScript != null && manaScript.GetMana() > 0.8f)
        {
            manaScript.UseMana(manaCostPerSecond * Time.deltaTime);
        }
        else if (isActive && manaScript.GetMana() < 0.8f)
        {
            isActive = false;
            targetObject.SetActive(false);
            particleSystem.Stop();
        }
    }



    public GameObject particleEffect;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ParticleEffect")
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 reflection = Vector3.Reflect(collision.relativeVelocity, collision.contacts[0].normal);
                rb.velocity = reflection;

                // Instantiate the particle effect in the opposite direction
                GameObject reflectedParticleEffect = Instantiate(particleEffect, collision.contacts[0].point, Quaternion.identity);
                reflectedParticleEffect.GetComponent<ParticleSystem>().Play();
                Destroy(reflectedParticleEffect, 2f);
            }
        }
    }
}
