using System.Threading.Tasks;
using System.IO;
using UnityEngine;

/// <summary>
/// 同期と非同期でのファイル保存処理を比較するためのスクリプト
/// 非同期処理は async, await で書いている
/// </summary>
public class AsyncAwait : MonoBehaviour
{
    /// <summary>保存する文字列（大きいデータを入れる）</summary>
    string _bigString = "";
    /// <summary>ファイルのパス</summary>
    string _filePath = "";

    void Start()
    {
        // 大きい文字列を作る
        _bigString = new string('0', int.MaxValue / 10);    // 200 MB
        // 保存先は Unity 用のデータパス
        _filePath = Application.persistentDataPath + "/test.txt";
    }

    /// <summary>
    /// 非同期処理を行う
    /// </summary>
    public void TestAsync()
    {
        Task t = SaveAsync();   // 戻り値は受け取る必要はない
        Debug.Log("SaveAsync を呼び出しました");
    }

    /// <summary>
    /// 非同期処理の実体
    /// </summary>
    /// <returns></returns>
    async Task SaveAsync()
    {
        await Task.Run(() =>
        {
            SaveFile();
        });
        Debug.Log("書き込みが完了しました");
    }

    /// <summary>
    /// 同期処理を開始する
    /// </summary>
    public void TestSync()
    {
        SaveFile();
        Debug.Log("書き込みが完了しました");
    }

    /// <summary>
    /// 文字列データをファイルに保存する（そしてファイルを削除する）
    /// </summary>
    void SaveFile()
    {
        using (FileStream fs = File.Open(_filePath, FileMode.OpenOrCreate, FileAccess.Write))
        {
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.Write(_bigString);
            }
        }

        // テスト用の大きいデータなので、すぐ削除する
        File.Delete(_filePath);
    }
}
