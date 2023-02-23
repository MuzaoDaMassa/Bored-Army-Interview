using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera _camera;
    public Rigidbody2D _rb;

    [SerializeField] private float _moveSpeed = 5f;

    private Vector2 _movement;
    private Vector2 _mousePosition;
    private void Update()
    {
        _movement.y = Input.GetAxisRaw("Vertical");
        _mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        if (!GameManager._isGameOver)
        {
            Vector2 lookDirection = _mousePosition - _rb.position;

            if (_movement.y > 0)
            {
                _rb.MovePosition(_rb.position + lookDirection.normalized * _moveSpeed * Time.fixedDeltaTime);
            }

            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - 90f;
            _rb.rotation = angle;
        }
    }
}
