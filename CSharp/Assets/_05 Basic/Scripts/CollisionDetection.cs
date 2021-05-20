using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public Color m_changedColor = default;
    Color m_initialColor = default;
    SpriteRenderer m_sprite = default;

    void Start()
    {
        m_sprite = GetComponent<SpriteRenderer>();
        m_initialColor = m_sprite.color;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_sprite.color = m_changedColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        m_sprite.color = m_changedColor;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_sprite.color = m_initialColor;
    }
}
