using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 一時停止を表示する UI を制御するコンポーネント
/// </summary>
public class UIManager : MonoBehaviour, IPause
{
    /// <summary>一時停止の時にメッセージを表示するテキスト</summary>
    [SerializeField] Text m_text = default;
    [SerializeField] string m_pauseMessage = "PAUSE";
    [SerializeField] Animator m_anim = default;

    void IPause.Pause()
    {
        // アニメーションを再生してメッセージを表示する
        m_text.text = m_pauseMessage;
        m_anim?.Play("Blink");
    }

    void IPause.Resume()
    {
        // 表示を消す
        m_text.text = "";
        m_anim?.Play("Default");
    }
}
