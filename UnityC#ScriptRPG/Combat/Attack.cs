using UnityEngine;
using RPG.Combat;
using GameDevTV.Utils;
using System;
using GameDevTV.Inventories;
using GameDevTV.Saving;
using RPG.Audio;
using System.Collections.Generic;
using UnityEngine.AI;
using RPG.Core;
using RPG.Stats;
using UnityEngine.EventSystems;

namespace RPG.Control
{
    public class Attack : MonoBehaviour, ISaveable    {
        [SerializeField] float timeBetweenAttacks = 0.9f;
        [SerializeField] float attackRadius = 2f;
        [SerializeField] WeaponConfig defaultWeapon = null;
        [SerializeField] ShieldConfig defaultShield = null;
        [SerializeField] Transform rightHandTransform = null;
        [SerializeField] Transform leftHandTransform = null;
        [SerializeField] float speedProjectile = 10f;
        [SerializeField] float maxLifeTime = 10f;
        [SerializeField] string sound;
  

        [SerializeField] InteractUI interactUI;

     


        private int attackCount = 0;
        private float timeSinceSecondAttack = Mathf.Infinity;


        float timeSinceLastAttack = Mathf.Infinity;
        float timeFinishAttack = Mathf.Infinity;
        bool canMove = true;
        bool canAttack = true;

        public GameObject bullet;
        public Transform firePoint;
        Rigidbody rb;

        [SerializeField] float fireForce = 10;

        //Equipment equipment;
        Equipment equipmentWeapon;
        WeaponConfig currentWeaponConfig;
        LazyValue<Weapon> currentWeapon; //link do broni

        ShieldConfig currentShield;
        LazyValue<Shield> currentEquippedShield;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();

            currentWeaponConfig = defaultWeapon;
            currentWeapon = new LazyValue<Weapon>(SetDefulyWeapon);

            currentShield = defaultShield;
            currentEquippedShield = new LazyValue<Shield>(null);

            equipmentWeapon = GetComponent<Equipment>();

            //equipmentWeapon = equipment;
             if (equipmentWeapon)
             {
                equipmentWeapon.equipmentUpdated += UpdateWeapon;
            }
        }




        private void Start()
        {
            Projectile projectile = GetComponent<Projectile>();
            currentWeapon.ForceInit();
            //TestAim aim = GetComponent<TestAim>();
            Mana manaScript = GetComponent<Mana>();
            
        }


        private void Update()
        {
            if (interactUI.GetCurrentCursorType() == RPG.Control.CursorType.None)
            {
                if (!EventSystem.current.IsPointerOverGameObject())
                {
                    AttackStyle();
                }

                // Check if the right mouse button is released
                //if (Input.GetMouseButtonUp(1))
               // {
                //    StopDefending();
               // }
            }

            
        }

        private void AttackStyle()
        {
            if (currentWeapon != null)
            {
                // poprzednia wersja Hit();
                if (canAttack)
                {
                    Hit();
                }
               
                
                    
            }
            else if (currentWeaponConfig.HasProjectile())
            {
                AttackShotBehavior();
            }
        }


        


       
        public void Init(Vector3 dir, GameObject instigator)
        {
            rb.velocity = dir * speedProjectile;
           // this.instigator = instigator;

            Destroy(gameObject, maxLifeTime);// Prjectile zostanie zniszcozny po wyznaczonym czasi
            //transform.forward = dir;

        }

        private void Hit()
        {
            timeSinceLastAttack += Time.deltaTime;
            timeSinceSecondAttack += Time.deltaTime;
            timeFinishAttack += Time.deltaTime;
            if (Input.GetMouseButtonDown(0) && canAttack && timeSinceLastAttack >= timeBetweenAttacks)
            {
                attackCount++;
                if (attackCount == 1 && timeSinceSecondAttack >= 1.5f)
                {
                    AttackBehavior("attack");
                    FindObjectOfType<AudioManager>().Play(sound);
                    timeSinceLastAttack = 0;
                    attackCount = 0;
                    timeSinceSecondAttack = 0;
                    timeFinishAttack = 0;
                }
                else if (attackCount == 1 && timeSinceSecondAttack <= 1 && timeFinishAttack < 1)
                {
                    //timeBetweenAttacks = 0;
                    AttackBehavior("attack2");
                    FindObjectOfType<AudioManager>().Play(sound);
                    timeSinceLastAttack = 0;
                    timeSinceSecondAttack = 0;
                    attackCount = 0;
                }

                else
                {
                    attackCount = 0;
                }
            }
        }

        private Weapon SetDefulyWeapon()
        {

            return AttachWeapon(defaultWeapon);
        }

        private Weapon AttachWeapon(WeaponConfig weapon)
        {
            //Animator animator = GetComponent<Animator>();
            Animator animator = GetComponentInChildren<Animator>();
            return weapon.Spawn(rightHandTransform, leftHandTransform, animator);
        }

        public void EquippWeapon(WeaponConfig weapon)
        {
            //if(weapon == null) return; -> brak broni?
            currentWeaponConfig = weapon;
            currentWeapon.value = AttachWeapon(weapon);
        }

        private void UpdateWeapon()
        {
            var weapon = equipmentWeapon.GetItemInSlot(EquipLocation.Weapon) as WeaponConfig;
            var shield = equipmentWeapon.GetItemInSlot(EquipLocation.Offhand) as ShieldConfig;

            if (weapon == null)
            {
                EquippWeapon(defaultWeapon);
            }
            else
            {
                EquippWeapon(weapon);
            }
            if (shield != null)
            {
                EquipShield(shield);

            }
            else
            {
                DestroyOffHandItem();
            }

        }

        public void EquipShield(ShieldConfig shield)
        {
            currentShield = shield;
            currentEquippedShield.value = AttachShield(shield);
        }
        private void UnequipShield()
        {
            
                // Check if the player has a shield equipped
                if (currentShield != null)
                {
                    // Remove the shield from the hands
                    Destroy(currentEquippedShield.value.gameObject);

                    // Set currentShield to null since there is no shield equipped now
                    currentShield = null;
                }
            
        }
        private Shield AttachShield(ShieldConfig shield)
        {
            return shield.SpawnEquipableItem(rightHandTransform, leftHandTransform);
        }

        // use to destroy Shield/offhand prefab when the item is removed
        private void DestroyOffHandItem()
        {
            Shield offHandWeapon = leftHandTransform.GetComponentInChildren<Shield>();
            if (offHandWeapon == null)
            {
                return;
            }
            DestroyImmediate(offHandWeapon.gameObject);

        }



        private void AttackBehavior(string animation)
        {
            canMove = false;

            transform.LookAt(GetMouseHitPoint());
            //Animator animator = GetComponent<Animator>();
            Animator animator = GetComponentInChildren<Animator>();
            if (animator != null)
            {
                animator.SetTrigger(animation);
            }
        }

        private void AttackShotBehavior()
        {

            if (currentWeaponConfig.HasProjectile())
            {

                //currentWeaponConfig.LaunchProjectile(Helt ,rightHandTransform, leftHandTransform, target2, instigator, damage);
            }
           

        }

        private void Shot()
        {
            //TestAim aim = GetComponent<TestAim>();
           // aim.Aim();
            Fire();
        }

        public void ShotProjectile()
        {
            GameObject newProjectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
            newProjectile.SetActive(true);
        }

        public void ShotMultiProjectile()
        {
            InvokeRepeating("ShotProjectile", 0f, 0.5f);
            Invoke("StopMultiProjectile", 5f * 0.5f);
        }

        private void StopMultiProjectile()
        {
            CancelInvoke("ShotProjectile");
        }

        public void ShotRifle()
        {
            if (Input.GetMouseButton(0))
            {
                //ShotProjectile();
                Invoke("ShotRifle", currentWeaponConfig.GetTimeBetweenShots());
            }
            else
            {
                CancelInvoke("ShotRifle");
            }
        }


        private Vector3 GetMouseHitPoint()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, attackRadius))
            {
                return hit.point;
            }

            return ray.origin + ray.direction * attackRadius;
        }
        public CursorType GetCursorType()
        {
            return CursorType.None;
        }

        private void EnableMovement()
        {
            canMove = true;
        }

        public bool CanMove()
        {
            return canMove;
        }

        public void SetCanAttack(bool attack)
        {
            canAttack = attack;
        }

        public void Fire()
        {
            
            GameObject projectile = Instantiate(bullet, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(firePoint.up  * fireForce, ForceMode.Impulse);
        }



        // ability
        public static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }

        public Transform GetHandTransform(bool isRightHand)
        {
            if (isRightHand)
            {
                return rightHandTransform;
            }
            else
            {
                return leftHandTransform;
            }
        }

        /*public object CaptureState()
        {
            return currentWeaponConfig.name;
            //miejsce
            return new SerializableVector3(transform.position);
        }*/
       
        // Klasa PlayerState przechowuj¹ca nazwê broni i pozycjê gracza
        [System.Serializable]
        public class PlayerState
        {
            public string weaponName;
            public string shieldName;
            public SerializableVector3 playerPosition;

            public PlayerState(string weaponName, string shieldName, SerializableVector3 playerPosition)
            {
                this.weaponName = weaponName;
                this.shieldName = shieldName;
                this.playerPosition = playerPosition;
            }
        }

        public object CaptureState()
        {
            // Check if currentWeaponConfig and currentShield are not null before using them
            string weaponName = (currentWeaponConfig != null) ? currentWeaponConfig.name : null;
            string shieldName = (currentShield != null) ? currentShield.name : null;

            // Zapisuje pozycjê gracza
            SerializableVector3 playerPosition = new SerializableVector3(transform.position);

            // Tworzy obiekt przechowuj¹cy nazwê broni i pozycjê gracza
            PlayerState state = new PlayerState(weaponName, shieldName, playerPosition);

            // Zwraca ten obiekt
            return state;
        }

        public void RestoreState(object state)
        {
            // Pobiera obiekt PlayerState zapisany wczeœniej
            PlayerState playerState = (PlayerState)state;

            // Wczytuje nazwê broni i wyposa¿a gracza w odpowiedni¹ broñ
            string weaponName = playerState.weaponName;
            string shieldName = playerState.shieldName;

            WeaponConfig weapon = UnityEngine.Resources.Load<WeaponConfig>(weaponName);
            EquippWeapon(weapon);

            // Check if shieldName is not null before trying to load the ShieldConfig
            if (!string.IsNullOrEmpty(shieldName))
            {
                ShieldConfig shield = UnityEngine.Resources.Load<ShieldConfig>(shieldName);
                EquipShield(shield);
            }
            else
            {
                // If shieldName is null or empty, then unequip the shield (assuming you have a method to unequip shields)
                UnequipShield();
            }

            // Przywraca pozycjê gracza
            SerializableVector3 playerPosition = playerState.playerPosition;
            transform.position = playerPosition.ToVector();
        }

        

        /*public void RestoreState(object state)
        {
            string weaponName = (string)state; 
            WeaponConfig weapon = UnityEngine.Resources.Load<WeaponConfig>(weaponName);
            EquippWeapon(weapon);
            //miejsce
            SerializableVector3 position = (SerializableVector3)state;
            navMeshAgent.enabled = false;
            transform.position = position.ToVector();
            navMeshAgent.enabled = true;
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }*/

    }
   
}

