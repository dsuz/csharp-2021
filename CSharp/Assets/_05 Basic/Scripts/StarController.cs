using UnityEngine;

public class StarController : MonoBehaviour
{
    void Update()
    {
        if (this.transform.position.y < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destructable")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
