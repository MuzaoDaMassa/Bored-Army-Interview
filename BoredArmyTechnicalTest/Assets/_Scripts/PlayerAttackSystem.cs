using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackSystem : MonoBehaviour
{
    public Transform _frontFiringPoint;
    public Transform[] _lateralFiringPoints;
    public GameObject _cannonBallPrefab;

    [SerializeField] private float _impulse = 20f;
    [SerializeField] private float _singleShotRecharge = 0.5f;
    [SerializeField] private float _tripleShotRecharge = 2.5f;

    private float _nextSingleShot = 0f;
    private float _nextTripleShot = 0f;

    private void Update()
    {
        if (!GameManager._isGameOver)
        {
            if (Input.GetButtonDown("Fire1") && Time.time > _nextSingleShot)
            {
                _nextSingleShot = Time.time + _singleShotRecharge;
                SingleFire();
            }

            if (Input.GetButtonDown("Fire2") && Time.time > _nextTripleShot)
            {
                _nextTripleShot = Time.time + _tripleShotRecharge;
                TripleFire();
            }
        }
    }

    private void SingleFire()
    {
        GameObject cannonBall = Instantiate(_cannonBallPrefab, _frontFiringPoint.position, _frontFiringPoint.rotation);
        Rigidbody2D rb = cannonBall.GetComponent<Rigidbody2D>();
        rb.AddForce(_frontFiringPoint.right * _impulse, ForceMode2D.Impulse);
    }
    private void TripleFire()
    {
        for (int i = 0; i < _lateralFiringPoints.Length; i++)
        {
            GameObject cannonBall = Instantiate(_cannonBallPrefab, _lateralFiringPoints[i].position, _lateralFiringPoints[i].rotation);
            Rigidbody2D rb = cannonBall.GetComponent<Rigidbody2D>();
            rb.AddForce(_lateralFiringPoints[i].right * _impulse, ForceMode2D.Impulse);
        }
    }
}
