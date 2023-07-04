using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthTutorial
{
    public class Character : MonoBehaviour
    {
        [SerializeField] private float _startingHealth = 10;

        private HealthSystem healthSystem;

        private void Awake()
        {
            healthSystem = new HealthSystem(_startingHealth);
            healthSystem.PrintHealth();

            healthSystem.OnHealthChanged += OnHealthChanged;
            healthSystem.OnDeath += HandleDeath;
        }

        private void HandleDeath()
        {
            Destroy(gameObject);
        }

        private void OnHealthChanged()
        {
            healthSystem.PrintHealth();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                healthSystem.Health -= 1;
            }
            else if (Input.GetKeyDown(KeyCode.H))
            {
                healthSystem.Health += 1;
            }
        }
    }
}