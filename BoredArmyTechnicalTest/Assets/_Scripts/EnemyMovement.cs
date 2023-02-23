using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;

    private Vector2 _moveDir;

    private Rigidbody2D _rb;
    private Rigidbody2D _playerRb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!GameManager._isGameOver)
        {
            _moveDir = _playerRb.position - _rb.position;

            _rb.MovePosition(_rb.position + _moveDir.normalized * _moveSpeed * Time.fixedDeltaTime);

            float angle = Mathf.Atan2(_moveDir.y, _moveDir.x) * Mathf.Rad2Deg - 90f;
            _rb.rotation = angle;
        }
    }
}
