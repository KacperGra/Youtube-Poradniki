using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HealthTutorial
{
    public class HealthSystem
    {
        public event Action OnHealthChanged;

        public event Action OnDeath;

        private float health;
        private float maxHealth;

        public float Health
        {
            get => health;
            set
            {
                health = value;
                if (health > maxHealth)
                {
                    health = maxHealth;
                }

                if (health <= 0)
                {
                    OnDeath?.Invoke();
                }

                OnHealthChanged?.Invoke();
            }
        }

        public float MaxHealth
        {
            get => maxHealth;
            set
            {
                maxHealth = value;

                OnHealthChanged?.Invoke();
            }
        }

        public HealthSystem(float defaultHealth)
        {
            health = defaultHealth;
            maxHealth = defaultHealth;
        }

        public void PrintHealth()
        {
            Debug.Log($"Health: {health}/{maxHealth}");
        }
    }
}