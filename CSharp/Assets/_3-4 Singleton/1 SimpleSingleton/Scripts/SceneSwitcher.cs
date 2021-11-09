using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] string _sceneName = "";
    [SerializeField] string _pointName = "";

    void SwitchScene(string sceneName, string pointName, Vector2 direction)
    {
        SingletonSystem.Instance.PlayerDirection = direction;
        SingletonSystem.Instance.PointNameOnSceneLoaded = pointName;
        SceneManager.LoadScene(sceneName);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SwitchScene(_sceneName, _pointName, collision.gameObject.transform.up);
        }
    }
}
