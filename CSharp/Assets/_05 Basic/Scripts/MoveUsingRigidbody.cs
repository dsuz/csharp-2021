using UnityEngine;

public class MoveUsingRigidbody : MonoBehaviour
{
    /// <summary>動く速さ（力の大きさ）</summary>
    public float m_speed = 1f;
    /// <summary>モードを切り替える</summary>
    [SerializeField] int m_mode = 0;
    /// <summary>Rigidbody2D を取得した時に入れておく変数</summary>
    Rigidbody2D m_rb = default;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (m_mode == 0)
        {
            MoveUsingRigidbodyVelocity();
        }
        else if (m_mode == 1)
        {
            MoveUsingRigidbodyAddForce();
        }
    }

    /// <summary>
    /// Rigidbody2D.velocity プロパティを使って GameObject を動かす
    /// </summary>
    void MoveUsingRigidbodyVelocity()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 velo = new Vector2(h, v).normalized * m_speed;
        m_rb.velocity = velo;

        if (velo != Vector2.zero)
        {
            this.transform.up = velo;
        }
    }

    /// <summary>
    /// Rigidbody2D.AddForce 関数を使って GameObject を動かす
    /// ※Update() を使ってこの処理を行うのは本当はよくない。
    /// フレームレートによって力を加える頻度が変わり、結果として加速の挙動が変わってしまうため。
    /// </summary>
    void MoveUsingRigidbodyAddForce()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 f = new Vector2(h, v).normalized * m_speed;
        m_rb.AddForce(f);
        this.transform.up = m_rb.velocity;
    }
}
