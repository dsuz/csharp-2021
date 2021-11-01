using UnityEngine;

/// <summary>
/// 2D プラットフォーマーゲームのプレイヤー機能を提供する。
/// ゲーム管理機能もこのコンポーネントに書かれている。
/// </summary>
[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class Platformer2DPlayerController : MonoBehaviour
{
    /// <summary>走るスピード</summary>
    [SerializeField] float _runSpeed = 5f;
    /// <summary>ジャンプのスピード</summary>
    [SerializeField] float _jumpSpeed = 5f;
    /// <summary>上昇中にジャンプボタンを離した時に上昇を減衰させる係数</summary>
    [SerializeField] float _jumpDumping = 0.9f;
    /// <summary>ゲームオーバー時に表示する UI</summary>
    [SerializeField] GameObject _gameoverUi = default;
    /// <summary>ゲームオーバー時に鳴らす音</summary>
    [SerializeField] AudioClip _gameoverSound = default;
    /// <summary>接地フラグ</summary>
    bool _isGrounded = true;
    /// <summary>初期位置</summary>
    Vector3 _initialPosition = default;
    /// <summary>ゲームオーバーフラグ</summary>
    bool _isGameover = false;
    // コンポーネント
    Rigidbody2D _rb = default;
    Animator _anim = default;
    SpriteRenderer _sprite = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        _initialPosition = this.transform.position;
        _gameoverUi?.SetActive(false);
    }

    void Update()
    {
        // ゲームオーバー時の処理。ESC キーを押されたら再スタートするが、それ以外の時は何もせずに関数を抜ける。
        if (_isGameover)
        {
            if (Input.GetButtonUp("Cancel"))
            {
                Gameover(false);
            }
            else
            {
                return;
            }
        }

        // 入力を受け付けてキャラクターを動かす
        float h = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = _rb.velocity;

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = _jumpSpeed;
        }

        // ある条件下ではジャンプの上昇速度を減衰させる
        //if ()
        //{
        //    velocity.y *= _jumpDumping;
        //}

        velocity.x = h * _runSpeed;
        _rb.velocity = velocity;
    }

    void LateUpdate()
    {
        // アニメーションを切り替える
        if (_anim)
        {
            if (!_isGrounded)
            {
                _anim.Play("Jump");
            }
            else if (_rb.velocity.x == 0)
            {
                _anim.Play("Idle");
            }
            else
            {
                _anim.Play("Run");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                break;
            case "Ground":
                break;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Gameover(true);
        }
    }

    /// <summary>
    /// ゲームオーバー状態を変更する
    /// </summary>
    /// <param name="flg">true を指定するとゲームオーバーになり、false を指定すると再スタートする</param>
    void Gameover(bool flg)
    {
        if (flg == _isGameover) return; // ゲームオーバー状態の時にまたゲームオーバーにされたりしても、何もしない

        _isGameover = flg;
        _gameoverUi?.SetActive(flg);

        if (flg)
        {
            _rb.bodyType = RigidbodyType2D.Static;  // プレイヤーの動きを止める
            AudioSource.PlayClipAtPoint(_gameoverSound, Camera.main.transform.position);
        }
        else
        {
            this.transform.position = _initialPosition; // 初期位置に移動する
            _rb.bodyType = RigidbodyType2D.Dynamic;  // プレイヤーを動かせるようにする
        }
    }
}
