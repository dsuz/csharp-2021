using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SingletonSystem : MonoBehaviour
{
    /// <summary>インスタンスを取得するためのパブリック変数</summary>
    public static SingletonSystem Instance = default;
    [SerializeField] int _bulletsInScene = 1;
    [SerializeField] Text _scoreText = default; 
    Vector3 _playerDirection = Vector2.up;
    string _pointNameOnSceneLoaded = "";
    GameObject _player = default;
    int _score = 0;

    public int BulletsInScene
    {
        get { return _bulletsInScene; }
        set { _bulletsInScene = value; }
    }

    public Vector3 PlayerDirection
    {
        get { return _playerDirection; }
        set { _playerDirection = value; }
    }

    public string PointNameOnSceneLoaded
    {
        get { return _pointNameOnSceneLoaded; }
        set { _pointNameOnSceneLoaded = value; }
    }

    void Awake()
    {
        if (Instance)
        {
            Debug.LogWarning($"SingletonSystem のインスタンスは既に存在するので、{gameObject.name} は破棄します。");
            Destroy(this.gameObject);
        }
        else
        {
            // このクラスのインスタンスが無かった場合は、自分を DontDestroyOnload に置く
            Instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Update()
    {
        
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        var player = GameObject.FindGameObjectWithTag("Player");

        if (this.PointNameOnSceneLoaded != "")
        {
            var point = GameObject.Find(this.PointNameOnSceneLoaded);
            player.transform.position = point.transform.position;
        }

        if (player)
        {
            player.transform.up = this.PlayerDirection;
        }
    }

    public void AddScore(int score)
    {
        _score += score;
        _scoreText.text = _score.ToString("00000000");
    }
}
