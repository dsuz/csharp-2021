using UnityEngine;

/// <summary>
/// パドルを制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PaddleController : MonoBehaviour
{
    /// <summary>パドルが動く速さ</summary>
    [SerializeField] float m_speed = 1f;
    Rigidbody2D m_rb = default;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // 入力を受け付けて、パドルを動かす
        float h =Input.GetAxisRaw("Horizontal");
        m_rb.velocity = Vector2.right * h * m_speed;
    }
}
