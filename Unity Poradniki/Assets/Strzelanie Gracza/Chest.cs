using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Entity
{
    [SerializeField] private List<GameObject> fragemntsToSpawn;

    protected override void HandleDeath()
    {
        foreach (var fragment in fragemntsToSpawn)
        {
            Vector3 randomPosition = transform.position + (Vector3)UnityEngine.Random.insideUnitCircle * 0.3f;
            Instantiate(fragment, randomPosition, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}