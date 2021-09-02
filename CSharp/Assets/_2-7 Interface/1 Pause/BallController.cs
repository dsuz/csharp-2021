using UnityEngine;

/// <summary>
/// ボールを制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class BallController : MonoBehaviour, IPause
{
    Rigidbody2D m_rb = default;
    float m_angularVelocity;
    Vector2 m_velocity;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    public void Pause()
    {
        // 速度・回転を保存し、Rigidbody を停止する
        m_angularVelocity = m_rb.angularVelocity;
        m_velocity = m_rb.velocity;
        m_rb.Sleep();
        m_rb.simulated = false;
    }

    public void Resume()
    {
        // Rigidbody の活動を再開し、保存しておいた速度・回転を戻す
        m_rb.simulated = true;
        m_rb.WakeUp();
        m_rb.angularVelocity = m_angularVelocity;
        m_rb.velocity = m_velocity;
    }
}
