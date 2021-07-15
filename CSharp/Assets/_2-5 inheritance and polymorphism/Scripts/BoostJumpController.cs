using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostJumpController : ItemBase2D
{
    [SerializeField] float m_boostRatio = 1.5f;
    [SerializeField] float m_lifeTime = 5f;

    public override void Activate()
    {
        var p = GameObject.FindGameObjectWithTag("Player");
        var c = p.GetComponent<PlatformerPlayerController2D>();
        c.BoostJump(m_boostRatio, m_lifeTime);
    }
}
