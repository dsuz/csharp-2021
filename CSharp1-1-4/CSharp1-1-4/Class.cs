using System;

class Vector
{
    // メンバー変数（フィールド、クラスフィールドとも言う）
    public double x; // プロパティ = public なメンバ変数。外部から読み書きできる。
    public double y; // プロパティ = public なメンバ変数。外部から読み書きできる。

    // コンストラクター（デフォルトコンストラクター、省略可能）
    public Vector()
    {
        Console.WriteLine("コンストラクターが呼び出された");
    }

    /// <summary>
    /// 長さを求めて出力する
    /// </summary>
    /// <returns>長さ</returns>
    public void ShowLength()    // public なので外部から呼び出せる。メンバー関数・メソッド・メンバメソッドと呼ばれる
    {
        double length = Math.Sqrt(x * x + y * y);   // ローカル変数（関数内からのみ使える変数）
        Console.WriteLine("x: {0}, y: {1} の時、長さは {2} です", this.x, this.y, length);  // this は「このクラスのインスタンス」を表す（省略可能）
    }
}

class Person
{
    // メンバー変数（フィールド、クラスフィールドとも言う）
    public string name;             // プロパティ = public なメンバ変数。外部から読み書きできる。
    private int birthYear = 1900;   // private なメンバ変数。外部からは見えないし操作できない。省略可能。
    private int birthMonth = 1;     // private なメンバ変数。外部からは見えないし操作できない。省略可能。
    private int birthDay = 1;       // private なメンバ変数。外部からは見えないし操作できない。省略可能。

    /// <summary>
    /// コンストラクター（引数付きコンストラクター）
    /// </summary>
    /// <param name="name">名前</param>
    /// <param name="birthYear">誕生年</param>
    /// <param name="birthMonth">誕生月</param>
    /// <param name="birthDay">誕生日</param>
    public Person(string name, int birthYear, int birthMonth, int birthDay)
    {
        // ここの this は省略できない
        // this を使うことで、メンバ変数とパラメータ変数が同じ名前なのを区別しているため
        this.name = name;
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
        int age = this.CalcAge();   // ローカル変数（関数内からのみ使える変数）
        return age;
    }

    /// <summary>
    /// 年齢を計算する
    /// </summary>
    /// <returns></returns>
    private int CalcAge()   // private なので外部から呼び出せない（private は省略可能）
    {
        // ここの処理は現段階では理解しなくてもよい
        // なお、this は省略している
        string strToday = DateTime.Now.ToString("yyyyMMdd");
        int intToday = int.Parse(strToday);

        string strBirthday = this.birthYear.ToString("0000") + this.birthMonth.ToString("00") + this.birthDay.ToString("00");
        int intBirthday = int.Parse(strBirthday);

        int age = (intToday - intBirthday) / 10000;
        return age;
    }
}

class StaticTest
{
    public static float Pi = 3.14f;
    public static int count = 0;

    /// <summary>
    /// int の配列をもらって、その合計を返す
    /// </summary>
    /// <returns></returns>
    public static int Sum(int[] numbers)
    {
        int sum = 0;

        foreach (int n in numbers)
        {
            sum += n;
        }

        return sum;
    }

    /// <summary>
    /// コンストラクター
    /// </summary>
    public StaticTest()
    {
        count++;
    }
}