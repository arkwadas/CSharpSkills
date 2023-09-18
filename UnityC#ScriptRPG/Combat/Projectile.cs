using MoreMountains.TopDownEngine;
using UnityEngine;

using UnityEngine.Events;

namespace RPG.Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] float speed = 1;
        [SerializeField] bool isHoming = true;
        [SerializeField] GameObject hitEffectUnknow = null;
        [SerializeField] GameObject hitEffectEnemy = null;

        [SerializeField] float maxLifeTime = 10;
        [SerializeField] GameObject[] destroyOnHit = null;
        [SerializeField] float lifeAfterImpact = 10;
        [SerializeField] UnityEvent onHit;
        Health target = null; 
        Vector3 targetPoint;
        GameObject instigator = null;
        float damage = 5;



        [SerializeField] private Rigidbody rb;



        private void Update()
        {
            //is dead trzeba ogarnąć
            if (target != null && isHoming /*&& !target.IsDead()*/)
            {
                transform.LookAt(GetAimLocation());
            }
            transform.Translate(Vector3.forward * speed * Time.deltaTime);


        }



        public void Init(Vector3 dir, GameObject instigator)
        {
            rb.velocity = dir * speed;
            this.instigator = instigator;

            Destroy(gameObject, maxLifeTime);// Prjectile zostanie zniszcozny po wyznaczonym czasi
            //transform.forward = dir;

        }
        //nowe
        public void SetTarget(Health target, GameObject instigator, float damage)
        {
            SetTarget(instigator, damage, target);
        }
        //nowe
        public void SetTarget(Vector3 targetPoint, GameObject instigator, float damage)
        {
            SetTarget(instigator, damage, null, targetPoint);
        }

        /*public void SetTarget(Health target, GameObject instigator, float damage)
        {
            this.target = target;
            this.damage = damage;
            this.instigator = instigator;*/
        public void SetTarget(GameObject instigator, float damage, Health target = null, Vector3 targetPoint = default)
        {
            this.target = target;
            this.targetPoint = targetPoint;
            this.damage = damage;
            this.instigator = instigator;

            Destroy(gameObject, maxLifeTime);// Prjectile zostanie zniszcozny po wyznaczonym czasi
        }

        private Vector3 GetAimLocation()
        {
            if (target == null)
            {
                return targetPoint;
            }
            CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
            if (targetCapsule == null)
            {
                return target.transform.position;
            }
            return target.transform.position + Vector3.up * targetCapsule.height / 2;
        }
        private void OnTriggerEnter(Collider other)
        {
            UpdateHealth health = other.GetComponent<UpdateHealth>();
            if (target != null && health != target) return;
            if (health == null || health.IsDead()) return;
            if (other.gameObject == instigator) return;
            //health.TakeDamage(instigator, damage);

            if (other.CompareTag("Enemy"))
            {
                Instantiate(hitEffectEnemy, transform.position, transform.rotation);
                //speed = 0;
                Invoke("DestroyHitEffectEnemy", 5.0f);
                Destroy(gameObject, 0.01f);
            }

            onHit.Invoke();

            Destroy(gameObject, 0.01f) ;


                if (hitEffectUnknow != null)
                {
                    Instantiate(hitEffectUnknow, transform.position, transform.rotation);
                    Invoke("DestroyHitEffectUnknow", 5.0f);
                    Destroy(gameObject, 0.1f);

            }


            foreach (GameObject toDestroy in destroyOnHit) // przypadki kiedy niszczymy projectile
                {
                    Destroy(toDestroy);
                }

                Destroy(gameObject, lifeAfterImpact);

            }
        private void DestroyHitEffectEnemy()
        {
            Destroy(hitEffectEnemy);
        }

        private void DestroyHitEffectUnknow()
        {
            Destroy(hitEffectUnknow);
        }
    }

    }
