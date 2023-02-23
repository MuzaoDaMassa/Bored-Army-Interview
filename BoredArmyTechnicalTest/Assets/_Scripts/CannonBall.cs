using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public GameObject _explosionPrefab;
    private void Start()
    {
        StartCoroutine(DestroyRoutine());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Explode();
    }

    private IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(5f);
        Destroy(Instantiate(_explosionPrefab, transform.position, Quaternion.identity), 1f);
        Destroy(this.gameObject);
    }

    private void Explode()
    {
        Destroy(Instantiate(_explosionPrefab, transform.position, Quaternion.identity), 1f);
        Destroy(this.gameObject);
    }
}
