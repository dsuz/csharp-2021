using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーを制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlatformerPlayerController2D : MonoBehaviour
{
    /// <summary>移動速度</summary>
    [SerializeField] float m_moveSpeed = 3f;
    /// <summary>ジャンプ速度</summary>
    [SerializeField] float m_jumpSpeed = 5f;
    /// <summary>ジャンプ中にジャンプボタンを離した時の上昇速度減衰率</summary>
    [SerializeField] float m_gravityDrag = .8f;
    Rigidbody2D m_rb = default;
    /// <summary>接地フラグ</summary>
    bool m_isGrounded = false;
    Vector3 m_initialPosition = default;
    Animator m_anim = default;
    /// <summary>持っているアイテムのリスト</summary>
    List<ItemBase2D> m_itemList = new List<ItemBase2D>();
    /// <summary>現在のジャンプ速度</summary>
    float m_currentJumpSpeed = 0;

    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_anim = GetComponent<Animator>();
        m_initialPosition = this.transform.position;
        m_currentJumpSpeed = m_jumpSpeed;
    }
    
    void Update()
    {
        Movement();

        // アイテムを使う
        if (Input.GetButtonDown("Fire1"))
        {
            if (m_itemList.Count > 0)
            {
                // リストの先頭にあるアイテムを使って、破棄する
                ItemBase2D item = m_itemList[0];
                item.Activate();
                m_itemList.RemoveAt(0);
                Destroy(item.gameObject);
            }
        }

        // 画面外に落ちたら初期位置に戻す
        if (this.transform.position.y < -15)
        {
            this.transform.position = m_initialPosition;
        }
    }

    /// <summary>
    /// 一時的にジャンプ力を上げる
    /// </summary>
    /// <param name="boostRate">ジャンプ力を何倍にするか</param>
    /// <param name="boostTime">効果の有効期間（秒）</param>
    public void BoostJump(float boostRate, float boostTime)
    {
        Debug.Log("Boost jump speed");
        m_currentJumpSpeed *= boostRate;
        StartCoroutine(BackToOriginalJumpSpeedRoutine(boostTime));
    }

    /// <summary>
    /// ジャンプ力を元に戻す
    /// </summary>
    /// <param name="delayTime">遅延時間（秒）</param>
    /// <returns></returns>
    IEnumerator BackToOriginalJumpSpeedRoutine(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Debug.Log("Boost jump speed ended");
        m_currentJumpSpeed = m_jumpSpeed;
    }

    /// <summary>
    /// アイテムをアイテムリストに追加する
    /// </summary>
    /// <param name="item"></param>
    public void GetItem(ItemBase2D item)
    {
        m_itemList.Add(item);
    }

    /// <summary>
    /// キャラクターの移動を制御する
    /// </summary>
    void Movement()
    {
        float h = Input.GetAxis("Horizontal");
        Vector2 velocity = m_rb.velocity;   // この変数 velocity に速度を計算して、最後に Rigidbody2D.velocity に戻す

        if (h != 0)
        {
            velocity.x = h * m_moveSpeed;
        }

        if (Input.GetButtonDown("Jump") && m_isGrounded)
        {
            m_isGrounded = false;
            velocity.y = m_currentJumpSpeed;
        }
        else if (!Input.GetButton("Jump") && velocity.y > 0)
        {
            // 上昇中にジャンプボタンを離したら上昇を減速する
            velocity.y *= m_gravityDrag;
        }

        m_rb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_isGrounded = false;
    }

    private void LateUpdate()
    {
        // アニメーションを制御する
        m_anim.SetFloat("Speed", Mathf.Abs(m_rb.velocity.x));
        m_anim.SetBool("IsGrounded", m_isGrounded);
    }
}
