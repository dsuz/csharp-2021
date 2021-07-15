using UnityEngine;

/// <summary>
/// 得点のためのコインアイテムのコンポーネント
/// </summary>
public class CoinController : ItemBase2D   // ItemBase2D を継承している
{
    /// <summary>取った時に加点する値</summary>
    [SerializeField] int m_score = 100;

    public override void Activate()
    {
        FindObjectOfType<GameManagerSecondTermFifthWeek>().AddScore(m_score);
    }
}
