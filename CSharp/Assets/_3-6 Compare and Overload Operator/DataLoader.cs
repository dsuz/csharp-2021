using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System.Linq;

/// <summary>
/// アイテムデータを操作するコンポーネント
/// マスターデータの読み込み、ID を元にしたデータ（クラス）の取得、ができる
/// </summary>
public class DataLoader : MonoBehaviour
{
    /// <summary>読み込んだアイテムのデータ</summary>
    static List<Gear> _gearData = new List<Gear>();
    [SerializeField] TextAsset _gearDataCsv = default;

    /// <summary>
    /// アイテムデータ（マスターデータ）のリスト
    /// </summary>
    public static List<Gear> GearData
    {
        get
        {
            return _gearData;
        }
    }

    /// <summary>
    /// 指定した CSV ファイルからアイテムデータを読み込む
    /// </summary>
    public void LoadGearData()
    {
        Debug.Log("アイテムデータ読み込み開始");
        StringReader sr = new StringReader(_gearDataCsv.text);
        sr.ReadLine();  // 先頭行はヘッダなのでスキップする

        // 一行ずつ読み込んでインスタンスをリストに追加する
        while (sr.Peek() != -1)
        {
            string line = sr.ReadLine();
            var d = line.Split(',');
            Gear gear = new Gear(int.Parse(d[0]), d[1], int.Parse(d[2]), int.Parse(d[3]), int.Parse(d[4]));
            _gearData.Add(gear);
        }

        Debug.Log("アイテムデータ読み込み完了");
    }

    /// <summary>
    /// アイテムデータをソートし、Console にソート前後の情報を出力する
    /// ソート順は Gear 構造体に定義されている
    /// </summary>
    public void SortGearData()
    {
        StringBuilder sb = new StringBuilder(); // 長い文字列を作る時に使うクラス
        sb.AppendLine("=== ソート前 ===");

        foreach (var i in _gearData)
        {
            sb.AppendLine(i.ToString());
        }

        _gearData.Sort();
        sb.AppendLine("=== ソート後 ===");

        foreach (var i in _gearData)
        {
            sb.AppendLine(i.ToString());
        }

        Debug.Log(sb.ToString());
    }

    /// <summary>
    /// ID を指定してアイテムデータを取得する
    /// </summary>
    /// <param name="id">取得したいアイテムの ID</param>
    /// <returns>アイテムデータのインスタンス</returns>
    public static Gear GetGear(int id)
    {
        return DataLoader.GearData.Where(item => item.Id == id).FirstOrDefault();
    }
}
