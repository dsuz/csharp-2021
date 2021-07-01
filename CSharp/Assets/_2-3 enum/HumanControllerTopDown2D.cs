using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーを動かすためのコンポーネント
/// 状態は「正常、毒、麻痺、死」の 4 種類あり、それぞれ以下のような効果がある。
/// 毒: ライフが徐々に減る
/// 麻痺: 移動速度が落ちる
/// 死: 何もできなくなる（動けない）
/// 正常: 普通に移動でき、ライフも減らない
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class HumanControllerTopDown2D : MonoBehaviour
{
    /// <summary>ライフの最大値</summary>
    [SerializeField] float m_maxLife = 100;
    /// <summary>移動速度</summary>
    [SerializeField] float m_speed = 1f;
    /// <summary>毒の時にどれくらいライフが減るか</summary>
    [SerializeField] float m_lifeReduceSpeedOnPoisoned = 1f;
    /// <summary>麻痺の時にどれくらい移動速度が落ちるか</summary>
    [SerializeField] float m_speedReductionRatioOnParalyzed = 0.5f;
    [SerializeField] Slider m_lifeGauge = default;
    Rigidbody2D m_rb = default;
    Animator m_anim = default;
    SpriteRenderer m_sprite = default;
    float m_life = 0;
    PlayerState m_state = PlayerState.Normal;

    void Start()
    {
        m_life = m_maxLife;
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        m_sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // 入力検出と移動
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector2 dir = new Vector2(h, v).normalized;

        // 状態判定
        switch (m_state)
        {
            case PlayerState.Paralyzed:
                m_rb.velocity = dir * m_speed * m_speedReductionRatioOnParalyzed;
                break;

            case PlayerState.Dead:
                m_rb.velocity = Vector2.zero;
                break;

            case PlayerState.Poisoned:
            case PlayerState.Normal:
                m_rb.velocity = dir * m_speed;

                if (m_state == PlayerState.Poisoned)
                {
                    m_life -= m_lifeReduceSpeedOnPoisoned * Time.deltaTime;
                }
                break;
        }

        // 生死判定
        if (m_life < 0 && m_state != PlayerState.Dead)
        {
            m_state = PlayerState.Dead;
            m_sprite.color = Color.red;
        }

        // ゲージ処理
        if (m_lifeGauge)
        {
            m_lifeGauge.value = m_life / m_maxLife;
        }
    }

    void LateUpdate()
    {
        if (m_anim)
        {
            if (m_rb.velocity.magnitude > 0)
            {
                m_anim.Play("Walk");
            }
            else
            {
                m_anim.Play("Idle");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Poison")
        {
            m_state = PlayerState.Poisoned;
            m_sprite.color = Color.magenta;
        }
        else if (collision.gameObject.tag == "Paralyze")
        {
            m_state = PlayerState.Paralyzed;
            m_sprite.color = Color.yellow;
        }
        else
        {
            m_state = PlayerState.Normal;
            m_sprite.color = Color.white;
        }
    }
}

/// <summary>
/// プレイヤーの状態を表す
/// </summary>
enum PlayerState
{
    /// <summary>通常</summary>
    Normal,
    /// <summary>毒 ライフが減る</summary>
    Poisoned,
    /// <summary>麻痺 移動が遅くなる</summary>
    Paralyzed,
    /// <summary>死</summary>
    Dead,
}
