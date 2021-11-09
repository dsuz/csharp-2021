using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SingletonSystem.Instance.BulletsInScene++;
            Destroy(this.gameObject);
        }
    }
}
