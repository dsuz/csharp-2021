using System;
using UnityEngine;

/// <summary>
/// 「タプル」と「アップキャスト」「ダウンキャスト」を説明するサンプルスクリプト
/// </summary>
public class TupleTest : MonoBehaviour
{
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 関数などから「複数の結果」が欲しい時の解決方法例１ - 戻り値で１つめの、out で２つめの結果をもらう
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                // アップキャストして Collider として GetComponent する
                Collider col = hit.collider.gameObject.GetComponent<Collider>();
                Debug.Log($"{col.gameObject.name} には {col.GetType().ToString()} がアタッチされています");

                // 「型を判定」して「ダウンキャスト」する例
                if (col is CapsuleCollider) // 型の判定
                {
                    int d = ((CapsuleCollider)col).direction;   // ダウンキャスト (Collider -> CapsuleCollider)
                    Debug.Log($"Direction は {d} です。");
                }
                else if (col is BoxCollider)
                {
                    Vector3 s = ((BoxCollider)col).size;
                    Debug.Log($"Size は {s} です。");
                }
                else if (col is SphereCollider)
                {
                    float r = ((SphereCollider)col).radius;
                    Debug.Log($"Radius は {r} です。");
                }
            }
        }
    }

    public void DoClass()
    {
        // 関数などから「複数の結果」が欲しい時の解決方法例２ - クラス or 構造体として結果をもらう
        var now = new ClassForMultipleResult();
        Debug.Log($"今日は {now.Date}、{now.Day} 曜日です。時刻は {now.Time} です。");
    }

    public void DoTuple()
    {
        // 関数などから「複数の結果」が欲しい時の解決方法例３ - タプルとして結果をもらう
        (int y, int m, int d, string dow) = GetToday();
        // var (y, m, d, dow) = GetToday(); // このように型推論で受け取ることもできる
        Debug.Log($"今日は {y} 年 {m} 月 {d} 日、{dow} 曜日です。");

        // タプルの変数を作ることもできる
        var t = GetToday();
        Debug.Log($"今日は {t.year} 年 {t.month} 月 {t.day} 日、{t.dayOfWeek} 曜日です。");
    }

    (int year, int month, int day, string dayOfWeek) GetToday()
    {
        var now = DateTime.Now;
        return (now.Year, now.Month, now.Day, now.DayOfWeek.ToString());
    }
}

class ClassForMultipleResult
{
    public string Date;
    public string Time;
    public string Day;

    public ClassForMultipleResult()
    {
        this.Date = DateTime.Now.ToString("yyyy/MM/dd");
        this.Time = DateTime.Now.ToString("HH:mm:ss");
        this.Day = DateTime.Now.ToString("ddd");
    }
}
