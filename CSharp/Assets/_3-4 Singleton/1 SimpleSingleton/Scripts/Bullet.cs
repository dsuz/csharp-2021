using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField] float _speed = 3f;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = this.transform.up * _speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
    }
}
