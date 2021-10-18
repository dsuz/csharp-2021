using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// キャラクターを制御するコンポーネント
/// キャラクターにアタッチして使う。Rigidbody2D を必要とする。
/// ボタンでジャンプする。
/// 何かにぶつかったらゲームオーバーにする。
/// </summary>
public class JumpController : MonoBehaviour
{
    /// <summary>スペースキーを押した時に上昇する力</summary>
    [SerializeField] float m_jumpPower = 1f;
    Rigidbody2D m_rb;
    /// <summary>Game Over を表示するオブジェクト</summary>
    GameObject m_gameoverText = null;
    /// <summary>経過時間を表示するオブジェクト</summary>
    GameObject m_timeText = null;
    /// <summary>ゲームオーバーかどうかを判断するフラグ</summary>
    bool m_isGameover = false;

    void Start()
    {
        // シーンから、適切なオブジェクトを検索・取得する
        m_gameoverText = GameObject.Find("GameOverText");
        m_timeText = GameObject.Find("TimeText");
    }

    void Update()
    {
        // ジャンプボタンが押されたら上昇する
        if (Input.GetButtonDown("Jump"))
        {
            m_rb.AddForce(Vector2.up * m_jumpPower, ForceMode2D.Impulse);
        }

        // TimeText にプレイ時間を表示する
        m_timeText.GetComponent<Text>().text = Time.time.ToString("F2");    // F2 で「小数点以下２桁まで」を指定して、実数を文字列に変換する
    }

    void OnCollisionEnter(Collision collision)
    {
        // 何かにぶつかったらゲームオーバーとする
        m_isGameover = true;
        // 画面に Game Over と表示する
        Text gameoverText = m_gameoverText.GetComponent<Text>();
        gameoverText.text = "Game Over";
    }
}
