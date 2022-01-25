using UnityEngine;
using UnityEditor;  // エディタースクリプトを書くときに必要

/// <summary>
/// このスクリプトが普通のフォルダにあるとビルドエラーになる。
/// 解決方法は２通り。
/// 1. スクリプト全体をエディタ上でしか動かないようにディレクティブで囲む
/// 2. Editor フォルダを作り、このスクリプトをこのフォルダに入れる
/// </summary>
public class MyEditorScript : EditorWindow
{
    string _str = default;

    [MenuItem("Tools/Test")]    // このメソッドをメニューに登録する。メニューから選んだらこのメソッドを実行する。
    static void Test()
    {
        GetWindow<MyEditorScript>("T e s t");   // Window を表示する
    }

    /// <summary>
    /// Window が表示された時に実行される処理
    /// </summary>
    void OnGUI()
    {
        _str = EditorGUILayout.TextField("String", _str);   // 入力ボックスを表示し、_str を入れて、入力された値を _str に入れる

        // ボタンを表示する
        if (GUILayout.Button("B u t t o n"))
        {
            // ボタンが押された時の処理
            Debug.Log($"{_str} が入力されました");
        }
    }
}
