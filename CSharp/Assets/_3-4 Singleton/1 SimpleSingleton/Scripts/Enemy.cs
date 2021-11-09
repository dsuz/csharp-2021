using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField] float _speed = 2f;
    [SerializeField] int _score = 100;
    GameObject _player = default;
    Rigidbody2D _rb = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (_player)
        {
            Vector2 dir = _player.transform.position - this.transform.position;
            _rb.velocity = dir.normalized * Mathf.PerlinNoise(this.transform.position.x, this.transform.position.y) * _speed;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            SingletonSystem.Instance.AddScore(_score);
            Destroy(this.gameObject);
        }
    }
}
