using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _playerVisual;
    // 0 - Undamaged, 1 - Slightly Damaged, 2 - Very Damaged 
    [SerializeField] private Sprite[] _deteriorationIndicators;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private int _maxHealth = 200;

    public GameObject _explosionPrefab;

    private int _health = 0;

    private void Start()
    {
        _healthBar.SetMaxHealth(_maxHealth);
        _health = _maxHealth;
        _healthBar.SetHealth(_health);

        _playerVisual.sprite = _deteriorationIndicators[0];
    }

    private void Update()
    {
        if (_health <= 0)
        {
            Explode();
            GameManager._isGameOver = true;
        }

        ShipDeterioration();

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "CannonBall")
        {
            TakeDamage(Random.Range(20, 41));
        }
    }

    private void ShipDeterioration()
    {
        if (_health <= 0.66 * _maxHealth && _health > 0.33 * _maxHealth)
        {
            _playerVisual.sprite = _deteriorationIndicators[1];
        }
        else if (_health <= 0.33 * _maxHealth)
        {
            _playerVisual.sprite = _deteriorationIndicators[2];
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _healthBar.SetHealth(_health);
    }

    private void Explode()
    {
        GameObject explosion = Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
        explosion.transform.localScale = new Vector3(2f, 2f, 2f);
        Destroy(explosion, 2f);
        Destroy(this.gameObject);
    }
}
