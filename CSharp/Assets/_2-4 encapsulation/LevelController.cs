using UnityEngine;

/// <summary>
/// プレイヤーのパラメーターを管理するコンポーネント
/// </summary>
public class LevelController : MonoBehaviour
{
    /// <summary>レベルアップテーブルを読み込むため</summary>
    [SerializeField] LevelManager m_levelManager = default;
    /// <summary>プレイヤーのパラメーター</summary>
    PlayerStats m_playerStats = default;

    public int Level
    {
        get
        {
            return m_playerStats.Level;
        }

        private set
        {
            PlayerStats stats = m_levelManager.GetData(value);

            if (stats.Level != 0)
            {
                m_playerStats = m_levelManager.GetData(value);
            }
        }
    }

    public PlayerStats Stats
    {
        get
        {
            return m_playerStats;
        }
    }

    void Start()
    {
        LevelUp();
    }

    /// <summary>
    /// レベルアップする
    /// </summary>
    /// <param name="level">レベルアップさせたいレベル数</param>
    public void LevelUp(int level = 1)
    {
        this.Level += level;
    }
}
