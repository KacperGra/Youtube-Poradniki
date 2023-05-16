using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private SpriteRenderer playerGraphics;
    [SerializeField] private string isMovingParameterName = "IsMoving";

    private int _isMovingHash;

    private void Start()
    {
        _isMovingHash = Animator.StringToHash(isMovingParameterName);
    }

    private void Update()
    {
        animator.SetBool(_isMovingHash, movement.IsMoving());

        if (movement.GetInput().x > 0)
        {
            playerGraphics.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (movement.GetInput().x < 0)
        {
            playerGraphics.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}