using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidobdy;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float damage = 1;

    public void Setup(Vector2 direction)
    {
        rigidobdy.velocity = direction * moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IDamagable>(out var damagable))
        {
            damagable.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}