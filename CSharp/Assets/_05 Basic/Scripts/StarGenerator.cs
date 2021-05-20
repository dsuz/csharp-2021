using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    [SerializeField] GameObject m_prefab = default;
    [SerializeField] Vector3 m_offset = default;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject go = Instantiate(m_prefab, this.transform.position, this.transform.rotation);
            go.transform.position += m_offset;
        }
    }
}
