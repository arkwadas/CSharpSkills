using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaeponDamage : MonoBehaviour
{
    [SerializeField] private Collider myCollide;
    private List<Collider> alredyColliderWith = new List<Collider>();

    private int damage;
    private float knockback;

    private void OnEnable()
    {
        alredyColliderWith.Clear();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == myCollide) { return; }

        if (alredyColliderWith.Contains(other)) { return; }
        alredyColliderWith.Add(other);

        /*if(other.TryGetComponent<Health>(out Health health))
        {
            health.DealDamage(damage);
            
        }*/
        if (other.TryGetComponent<Health>(out Health currentHealth))
        {
            currentHealth.DealDamage(damage);

        }

        if (other.TryGetComponent<ForceReceiver>(out ForceReceiver forceReceiver))
        {
            Vector3 direction = (other.transform.position - myCollide.transform.position).normalized;
            forceReceiver.AddForce(direction * knockback); // knotback mo¿na usun¹æ dzieki czemu nie mamy si³y wypcheniecia
        }
        
    }
    public void SetAttack(int damage, float knockback)
    {
        this.damage = damage;
        this.knockback = knockback;
    }
}
