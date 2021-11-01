using UnityEngine;

/// <summary>
/// 敵を制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Platformer2DEnemyController : MonoBehaviour
{
    /// <summary>移動速度と方向を定める（負の値を指定すると左に動く）</summary>
    [SerializeField] float _moveSpeedX = -1f;
    /// <summary>倒した時のエフェクト</summary>
    [SerializeField] GameObject _killedEffect = default;
    /// <summary>プレイヤーが踏んだ時に押し返す力</summary>
    [SerializeField] float _pushbackPower = 30f;
    // コンポーネント
    Rigidbody2D _rb = default;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = _moveSpeedX * Vector2.right;
    }

    /// <summary>
    /// 攻撃された時に呼び出す。やられたエフェクトを表示してオブジェクトを破棄する。
    /// </summary>
    /// <param name="player">プレイヤーの Rigidbody を渡す。踏んで倒した時に指定する。遠距離攻撃で倒した時は null を指定する。</param>
    public void Hit(Rigidbody2D player)
    {
        // やられたエフェクトを出す
        var go = Instantiate(_killedEffect);
        go.transform.position = this.transform.position;

        // 自分自身を破棄する
        Destroy(this.gameObject);
    }
}
