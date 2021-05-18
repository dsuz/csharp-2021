using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Class01 を呼び出します...");
        Class01();
        Wait();

        Console.WriteLine("Class02 を呼び出します...");
        Class02();
        Wait();

        Console.WriteLine("UseBuiltInClass を呼び出します...");
        UseBuiltInClass();
        Wait();

        Console.WriteLine("Static01 を呼び出します...");
        Static01();
        Wait();

        Console.WriteLine("UseBuiltInStatic を呼び出します...");
        UseBuiltInStatic();
        Wait();
    }

    /// <summary>
    /// クラスを定義し、インスタンスを作って機能を呼び出す
    /// </summary>
    static void Class01()
    {
        Vector v1 = new Vector();   // 何もない状態から新たな「インスタンス（「オブジェクト」と呼ばれる時もある）」を作る時は new を使う。
        v1.x = 1;
        v1.y = 2;
        v1.ShowLength();

        v1.x = 3;
        v1.y = 4;
        v1.ShowLength();

        Vector v2 = new Vector();
        v2.x = 4;
        v2.y = 5;
        v2.ShowLength();

        /*
         * ここで以下をやってみましょう
         * https://paiza.jp/works/cs/primer/beginner-cs7/21001/1 の演習 1
         * */
    }

    /// <summary>
    /// 引数つきコンストラクターと戻り値を返すメソッドを使う
    /// </summary>
    static void Class02()
    {
        Person shohei = new Person("Shohei Ohtani", 1994, 7, 5);
        int age1 = shohei.GetAge();
        Console.WriteLine(shohei.name + " さんの年齢は " + age1 + " 歳です。");

        Person p = new Person("Roki Sasaki", 2001, 11, 3);
        Console.WriteLine("{0} さんの年齢は {1} 歳です。", p.name, p.GetAge());

        /*
         * ここで以下をやってみましょう
         * https://paiza.jp/works/cs/primer/beginner-cs7/21002/1 の演習 1
         * https://paiza.jp/works/cs/primer/beginner-cs7/21004/1 の演習 1
         * */
    }

    /// <summary>
    /// 最初から用意されている（組み込み、built-in）クラスを使う
    /// </summary>
    static void UseBuiltInClass()
    {
        // string もクラスである（int, float, bool や配列も実はクラスである）
        string str = "Microsoft Visual Studio is an integrated development environment (IDE) from Microsoft.";
        Console.WriteLine("{0} の文字数は {1} です", str, str.Length);
        Console.WriteLine("{0} の単語数は {1} です", str, str.Split(new string[] { " " }, StringSplitOptions.None).Length);

        // 日付や日時を表すための DateTime　というクラスがある
        DateTime dt = new DateTime(2012, 5, 5); // 2012年5月5日
        dt = dt.AddDays(30);     // こういった「日付操作に都合のよい機能」が用意されている
        dt = dt.AddMonths(10);
        Console.WriteLine(dt.ToString("yyyy年MM月dd日"));  // ToString の引数は日付書式指定文字列です。参照: https://csharp.sql55.com/cookbook/format-datetime.php
    }

    /// <summary>
    /// static 関数、static プロパティを使う
    /// </summary>
    static void Static01()
    {
        Console.WriteLine(StaticTest.Pi);
        int[] numbers = { 5, 3, 2, 6, 9, 10 };
        int sum = StaticTest.Sum(numbers);  // static な関数はインスタンスを作るのではなく「クラス名.関数」で呼び出す
        Console.WriteLine(sum);

        // static なプロパティは「各インスタンスに依存しない」値を返すことができる
        StaticTest st1 = new StaticTest(), st2 = new StaticTest(), st3 = new StaticTest();
        Console.WriteLine("StaticTest クラスのインスタンスは {0} 個あります", StaticTest.count);

        /*
         * ここで以下をやってみましょう
         * https://paiza.jp/works/cs/primer/beginner-cs7/21007/1
         * */
    }

    /// <summary>
    /// 組み込みの static 関数、static プロパティを使う
    /// </summary>
    static void UseBuiltInStatic()
    {
        // インスタンスを使わず、クラス名.プロパティ とか クラス名.関数 で呼び出せていることに注目する
        Console.WriteLine("今日は {0} です", DateTime.Now.ToString("yyyy年MM月dd日"));
        Console.WriteLine("π = {0:f5} です", Math.PI);    // {0:f5} は「小数点以下5桁まで表示」という書式指定文字列です
        Console.WriteLine("58 と 72 では {0} の方が大きい", Math.Max(58, 72));
        Console.WriteLine("58 と 72 では {0} の方が小さい", Math.Min(58, 72));
    }

    static void Wait()
    {
        Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...\n");
        Console.ReadLine();
    }
}
