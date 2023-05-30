using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private GroundChecker groundChecker;
    [SerializeField] private SpriteRenderer playerGraphics;
    [SerializeField] private string isMovingParameterName = "IsMoving";
    [SerializeField] private string isGroundedParameterName = "IsGrounded";
    [SerializeField] private string isFallingParameterName = "IsFalling";

    private int _isMovingHash;
    private int _isGroundedHash;
    private int _isFallingHash;

    private void Start()
    {
        _isMovingHash = Animator.StringToHash(isMovingParameterName);
        _isGroundedHash = Animator.StringToHash(isGroundedParameterName);
        _isFallingHash = Animator.StringToHash(isFallingParameterName);
    }

    private void Update()
    {
        animator.SetBool(_isMovingHash, movement.IsMoving());
        animator.SetBool(_isGroundedHash, groundChecker.IsGrounded());

        bool isFalling = rigidbody.velocity.y < -0.01f;
        animator.SetBool(_isFallingHash, isFalling);

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