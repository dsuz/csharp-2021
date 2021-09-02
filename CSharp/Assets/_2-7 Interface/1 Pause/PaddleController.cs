using UnityEngine;

/// <summary>
/// パドルを制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PaddleController : MonoBehaviour, IPause
{
    /// <summary>パドルが動く速さ</summary>
    [SerializeField] float m_speed = 1f;
    Rigidbody2D m_rb = default;
    /// <summary>一時停止フラグ（true の時は停止している）</summary>
    bool m_isPaused = false;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (m_isPaused) return;

        // 入力を受け付けて、パドルを動かす
        float h =Input.GetAxisRaw("Horizontal");
        m_rb.velocity = Vector2.right * h * m_speed;
    }

    void IPause.Pause()
    {
        m_isPaused = true;
        m_rb.velocity = Vector2.zero;   // こうしないと「移動しながら ESC キーを押した」時に停止しない
    }

    void IPause.Resume()
    {
        m_isPaused = false;
    }
}
