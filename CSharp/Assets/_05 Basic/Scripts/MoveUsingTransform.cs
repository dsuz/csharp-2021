using UnityEngine;

public class MoveUsingTransform : MonoBehaviour
{
    /// <summary>動く速さ</summary>
    public float m_speed = 1f;
    /// <summary>モードを切り替える</summary>
    [SerializeField] int m_mode = 0;

    void Start()
    {
    }

    void Update()
    {
        if (m_mode == 0)
        {
            MoveUsingTransformTranslate();
        }
        else if (m_mode == 1)
        {
            MoveUsingTransformPosition();
        }
    }

    /// <summary>
    /// Transform.Translate() 関数を使って GameObject を動かす
    /// ※Update() を使ってこの処理を行うのは本当はよくない。フレームレートによって動く速さが変わってしまうため。
    /// </summary>
    void MoveUsingTransformTranslate()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        this.transform.Translate(h * m_speed, v * m_speed, 0f);
    }

    /// <summary>
    /// Transform.position プロパティを使って GameObject を動かす。
    /// ※Update() を使ってこの処理を行うのは本当はよくない。フレームレートによって動く速さが変わってしまうため。
    /// </summary>
    void MoveUsingTransformPosition()
    {
        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");
        Vector3 deltaPosition = new Vector3(h, v, 0).normalized * m_speed;
        this.transform.position += deltaPosition;

        if (deltaPosition != Vector3.zero)
        {
            this.transform.up = deltaPosition;
        }
    }
}
