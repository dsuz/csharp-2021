using UnityEngine;

/// <summary>
/// アニメーションで回転するギミックを制御するコンポーネント
/// </summary>
[RequireComponent(typeof(Animator))]
public class SpinController : MonoBehaviour, IPause
{
    Animator m_anim = default;

    void Start()
    {
        m_anim = GetComponent<Animator>();
    }

    void IPause.Pause()
    {
        // アニメーションを止める
        m_anim.speed = 0;
    }

    void IPause.Resume()
    {
        // アニメーションを再開する
        m_anim.speed = 1;
    }
}
