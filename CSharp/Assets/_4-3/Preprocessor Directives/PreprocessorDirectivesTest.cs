using UnityEngine;
using UnityEngine.UI;

public class PreprocessorDirectivesTest : MonoBehaviour
{
    [SerializeField] Text uiText = default;

    void Start()
    {
        string message = "このアプリケーションは ";
#if UNITY_EDITOR
        message += "Unity Editor";
#elif UNITY_STANDALONE_WIN
        message += "Windows";
#endif
        message += " 上で動いています。";
        uiText.text = message;
    }
}
