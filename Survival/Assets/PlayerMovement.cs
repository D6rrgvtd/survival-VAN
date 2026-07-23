using UnityEngine;
using UnityEngine.InputSystem; // 新しいシステムを使うために必要

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // 新しいインプットシステムから移動入力を受け取る関数
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        // プレイヤーを移動させる
        rb.linearVelocity = moveInput.normalized * moveSpeed;
    }
}
