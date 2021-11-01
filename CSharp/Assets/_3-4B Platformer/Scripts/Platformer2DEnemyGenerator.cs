using System.Collections;
using UnityEngine;

/// <summary>
/// 敵を生成するコンポーネント
/// </summary>
public class Platformer2DEnemyGenerator : MonoBehaviour
{
    /// <summary>敵が出現する位置を指定する</summary>
    [SerializeField] Transform[] _spawnPoints = default;
    /// <summary>敵のプレハブ</summary>
    [SerializeField] GameObject _enemyPrefab = default;
    /// <summary>敵が出現する間隔（秒）</summary>
    [SerializeField] float _interval = 0.5f;

    void Start()
    {
        StartCoroutine(StartGenerate());
    }

    IEnumerator StartGenerate()
    {
        while (true)
        {
            foreach (var p in _spawnPoints)
            {
                var go = Instantiate(_enemyPrefab);
                go.transform.position = p.position;
                yield return new WaitForSeconds(_interval);
            }
        }
    }
}
