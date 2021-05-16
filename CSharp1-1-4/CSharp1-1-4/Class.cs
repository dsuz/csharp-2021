using System;

class Vector
{
    // メンバ変数（フィールド）
    public double x; // プロパティ = public なメンバ変数。外部から読み書きできる。
    public double y; // プロパティ = public なメンバ変数。外部から読み書きできる。

    // コンストラクター（デフォルトコンストラクター）
    public Vector()
    {
    }

    /// <summary>
    /// 長さを求めて出力する
    /// </summary>
    /// <returns>長さ</returns>
    public void ShowLength()    // public なので外部から呼び出せる
    {
        double length = Math.Sqrt(x * x + y * y);
        Console.WriteLine("x: {0}, y: {1} の時、長さは {2} です", x, y, length);
    }
}

class Person
{
    // メンバ変数（フィールド）
    public string name;             // プロパティ = public なメンバ変数。外部から読み書きできる。
    private int birthYear = 1900;   // private なメンバ変数。外部からは見えないし操作できない。
    private int birthMonth = 1;     // private なメンバ変数。外部からは見えないし操作できない。
    private int birthDay = 1;       // private なメンバ変数。外部からは見えないし操作できない。

    /// <summary>
    /// コンストラクター（引数付きコンストラクター）
    /// </summary>
    /// <param name="name">名前</param>
    /// <param name="birthYear">誕生年</param>
    /// <param name="birthMonth">誕生月</param>
    /// <param name="birthDay">誕生日</param>
    public Person(string name, int birthYear, int birthMonth, int birthDay)
    {
        this.name = name;   // this を使うことで、メンバ変数とパラメータ変数が同じ名前なのを区別している
        this.birthYear = birthYear;
        this.birthMonth = birthMonth;
        this.birthDay = birthDay;
    }

    /// <summary>
    /// 年齢を返す
    /// </summary>
    /// <returns>年齢</returns>
    public int GetAge()    // public なので外部から呼び出せる
    {
        int age = CalcAge();
        return age;
    }

    /// <summary>
    /// 年齢を計算する
    /// </summary>
    /// <returns></returns>
    private int CalcAge()   // private なので外部から呼び出せない
    {
        string strToday = DateTime.Now.ToString("yyyyMMdd");
        int intToday = int.Parse(strToday);

        string strBirthday = this.birthYear.ToString("0000") + this.birthMonth.ToString("00") + this.birthDay.ToString("00");
        int intBirthday = int.Parse(strBirthday);

        int age = (intToday - intBirthday) / 10000;
        return age;
    }
}
