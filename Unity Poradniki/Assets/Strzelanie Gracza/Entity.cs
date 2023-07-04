using HealthTutorial;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour, IDamagable
{
    [SerializeField] private float _startingHealth = 10;

    private HealthSystem healthSystem;

    private void Awake()
    {
        healthSystem = new HealthSystem(_startingHealth);
        healthSystem.OnDeath += HandleDeath;
    }

    public void TakeDamage(float damage)
    {
        healthSystem.Health -= damage;
    }

    protected abstract void HandleDeath();
}