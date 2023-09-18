using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    
    [SerializeField] private int maxHealth = 100;
    private int health; // za³amanie
    public int currentHealth;

    // [SerializeField] float speedRecoveryMana = 0.01f;


    //public float myLife;
    public float myMana;

    public bool IsDead => currentHealth == 0;
 
    private bool isInvunerable;

    public HealthBar healthBar;

    public event Action OnTakeDamage;
    public event Action OnDie;

    private void Start()
    {
        health = SethealthFromMaxHealth();
        currentHealth = health;
        healthBar.SetMaxHealth(health);
        

    }
    private int SethealthFromMaxHealth()
    {
        health = maxHealth * 1; // w przysz³oœci 1 mo¿em y zastapic funkcj¹ np kondycji która jest gdzieœ w 
        // kodzie jako statystyka postaci ktora wzrasta z poziomem
        return health;
    }

    public void SetInvunerable(bool isInvunerable)
    {
        this.isInvunerable = isInvunerable;
    }

    public void DealDamage(int damage)
    {
        if (health == 0) { return; }

        if (isInvunerable) { return; } 

        currentHealth = Mathf.Max(currentHealth - damage, 0);

        OnTakeDamage?.Invoke();

        // if (health == 0)
        if (currentHealth == 0)
        {
            OnDie?.Invoke();
            Destroy(healthBar.fill);
        }

        Debug.Log(currentHealth);
        healthBar.SetCurrentHealth(currentHealth);
    }





}
