using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShootingType
{
    Direction,
    MouseDirection,
    Raycast
}

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private LayerMask raycastLayerMask;
    [SerializeField] private int damage = 2;
    [SerializeField] private ShootingType shootingType;

    private Vector2 _lastDirection;

    private void Update()
    {
        if (shootingType == ShootingType.Direction)
        {
            HandleDirectionShooting();
        }
        else if (shootingType == ShootingType.MouseDirection || shootingType == ShootingType.Raycast)
        {
            HandleMouseDirectionShooting();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void HandleMouseDirectionShooting()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        direction.Normalize();

        _lastDirection = direction;
    }

    private void HandleDirectionShooting()
    {
        if (playerMovement.GetInput().x != 0)
        {
            _lastDirection = playerMovement.GetInput().normalized;
        }
    }

    private void Shoot()
    {
        if (shootingType == ShootingType.Direction || shootingType == ShootingType.MouseDirection)
        {
            Bullet newBullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            newBullet.Setup(_lastDirection);
        }
        else if (shootingType == ShootingType.Raycast)
        {
            var raycast = Physics2D.Raycast(transform.position, _lastDirection, 999f, raycastLayerMask);
            Debug.DrawRay(transform.position, _lastDirection * 5, Color.red, 1f);

            if (raycast.collider)
            {
                if (raycast.collider.TryGetComponent<IDamagable>(out var damagable))
                {
                    damagable.TakeDamage(damage);
                }
            }
        }
    }
}