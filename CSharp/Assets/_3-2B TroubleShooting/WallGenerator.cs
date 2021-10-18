using UnityEngine;

/// <summary>
/// 一定間隔で壁を生成するコンポーネント
/// 適当なオブジェクトにアタッチして使う。
/// 一定間隔で、設定した Wall Prefabs からランダムにプレハブを選び、生成する
/// </summary>
public class WallGenerator : MonoBehaviour
{
    /// <summary>壁として生成するプレハブ</summary>
    [SerializeField] GameObject[] m_wallPrefabs = null;
    /// <summary>壁を生成する間隔（秒）</summary>
    [SerializeField] float m_wallGenerateInterval = 2f;

    void Start()
    {
        GenerateWall();
    }

    void Update()
    {
    }

    /// <summary>
    /// プレハブにセットした「壁」プレハブのうち、ランダムに一つを生成する
    /// </summary>
    void GenerateWall()
    {
        GameObject go = Instantiate(m_wallPrefabs[0]);  // プレハブからオブジェクトを生成して、変数 go に入れる
    }
}
