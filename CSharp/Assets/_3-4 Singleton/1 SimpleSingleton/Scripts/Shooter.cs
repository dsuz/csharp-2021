using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Shooter : MonoBehaviour
{
    [SerializeField] float _movePower = 5f;
    [SerializeField] Transform _muzzle = default;
    [SerializeField] GameObject _bulletPrefab = default;
    Rigidbody2D _rb = default;
    Vector2 _dir = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void FixedUpdate()
    {
        _rb.AddForce(_dir.normalized * _movePower);
    }

    void LateUpdate()
    {
        if (_rb.velocity != Vector2.zero)
        {
            this.transform.up = _rb.velocity;
        }
    }

    void Fire()
    {
        var bullets = GameObject.FindGameObjectsWithTag("Bullet");

        if (bullets.Length < SingletonSystem.Instance.BulletsInScene)
        {
            Instantiate(_bulletPrefab, _muzzle.position, _muzzle.rotation);
        }
    }
}
