using UnityEngine;

/// <summary>
/// カギアイテムのコンポーネント
/// ドアを開ける
/// </summary>
public class KeyController : ItemBase2D   // ItemBase2D を継承している
{
    /// <summary>ドアのアニメーション</summary>
    [Tooltip("ドアを開けるアニメーションを再生するための Animator コンポーネントを持つ GameObject を指定する")]
    [SerializeField] Animator m_door = default;
    /// <summary>ドアを開けるアニメーションのステート名</summary>
    [Tooltip("ドアを開けるアニメーションのステート名を指定する")]
    [SerializeField] string m_stateName = "";
    /// <summary>ドアを開ける音</summary>
    [Tooltip("ドアを開ける音を指定する")]
    [SerializeField] AudioClip m_doorOpeningSound = default;

    public override void Activate()
    {
        m_door.Play(m_stateName);
        AudioSource.PlayClipAtPoint(m_doorOpeningSound, Camera.main.transform.position);
    }
}
