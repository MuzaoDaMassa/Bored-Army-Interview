using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _chaserVisual;
    [SerializeField] private Sprite[] _deteriorationIndicators;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _maxHealth = 60;

    public GameObject _explosionPrefab;

    private int _health = 0;

    private void Start()
    {
        _healthBar.SetMaxHealth(_maxHealth);
        _health = _maxHealth;
        _healthBar.SetHealth(_health);

        _chaserVisual.sprite = _deteriorationIndicators[0];
    }

    private void Update()
    {
        if (_health <= 0)
        {
            Explode();
        }

        ShipDeterioration();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "CannonBall")
        {
            TakeDamage(20);
        }

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealthSystem>().TakeDamage(_health);
            Explode();
        }
    }

    private void Explode()
    {
        GameObject explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        explosion.transform.localScale = new Vector3(2f, 2f, 2f);
        Destroy(explosion, 2f);
        Destroy(this.gameObject);
    }

    private void TakeDamage(int damage)
    {
        _health -= damage;
        _healthBar.SetHealth(_health);

        if (_health <= 0)
        {
            GameManager._score += 100;
        }
    }

    private void ShipDeterioration()
    {
        if (_health <= 0.66 * _maxHealth && _health > 0.33 * _maxHealth)
        {
            _chaserVisual.sprite = _deteriorationIndicators[1];
        }
        else if (_health <= 0.33 * _maxHealth)
        {
            _chaserVisual.sprite = _deteriorationIndicators[2];
        }
    }
}
