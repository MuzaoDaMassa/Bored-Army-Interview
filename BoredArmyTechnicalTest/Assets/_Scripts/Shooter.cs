using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _shooterVisual;
    [SerializeField] private Sprite[] _deteriorationIndicators;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _maxHealth = 120;
    [SerializeField] private float _impulse = 20f;
    [SerializeField] private float _distanceToShoot = 1.5f;
    [SerializeField] private float _rechargeTime = 0.5f;

    public GameObject _explosionPrefab;
    public GameObject _cannonBallPrefab;
    public Transform _firingPoint;

    private int _health = 0;
    private float _distanceToPlayer;
    private float _nextShot = 0f;
    private Rigidbody2D _rb;
    private Rigidbody2D _playerRB;

    private void Start()
    {
        _healthBar.SetMaxHealth(_maxHealth);
        _health = _maxHealth;
        _healthBar.SetHealth(_health);

        _rb = GetComponent<Rigidbody2D>();
        _playerRB = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        _shooterVisual.sprite = _deteriorationIndicators[0];
    }

    private void Update()
    {
       if (!GameManager._isGameOver)
        {
            if (_health <= 0)
            {
                Explode();
            }

            _distanceToPlayer = (_playerRB.position - _rb.position).magnitude;

            if (ShouldShoot(_distanceToPlayer) && Time.time > _nextShot)
            {
                _nextShot = Time.time + _rechargeTime;
                Shoot();
            }

            ShipDeterioration();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "CannonBall")
        {
            TakeDamage(20);
        }
    }

    private bool ShouldShoot(float distance)
    {
        if (distance <= _distanceToShoot)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void Explode()
    {
        GameObject explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        explosion.transform.localScale = new Vector3(2f, 2f, 2f);
        Destroy(explosion, 2f);
        Destroy(this.gameObject);
    }

    private void Shoot()
    {
        GameObject cannonBall = Instantiate(_cannonBallPrefab, _firingPoint.position, _firingPoint.rotation);
        Rigidbody2D rb = cannonBall.GetComponent<Rigidbody2D>();
        rb.AddForce(_firingPoint.right * _impulse, ForceMode2D.Impulse);
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;
        _healthBar.SetHealth(_health);

        if (_health <= 0)
        {
            GameManager._score += 50;
        }
    }

    private void ShipDeterioration()
    {
        if (_health <= 0.66 * _maxHealth && _health > 0.33 * _maxHealth)
        {
            _shooterVisual.sprite = _deteriorationIndicators[1];
        }
        else if (_health <= 0.33 * _maxHealth)
        {
            _shooterVisual.sprite = _deteriorationIndicators[2];
        }
    }
}
