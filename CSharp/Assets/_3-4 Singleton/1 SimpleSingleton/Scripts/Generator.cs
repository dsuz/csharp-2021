using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab = default;
    [SerializeField] float _interval = 5f;
    [SerializeField] Transform[] _spawnPoints = default;

    void Start()
    {
        StartCoroutine(GenerateRoutine());
    }

    IEnumerator GenerateRoutine()
    {
        while (true)
        {
            System.Array.ForEach(_spawnPoints, t => Instantiate(_enemyPrefab, t.position, Quaternion.identity));
            yield return new WaitForSeconds(_interval);
        }
    }
}
