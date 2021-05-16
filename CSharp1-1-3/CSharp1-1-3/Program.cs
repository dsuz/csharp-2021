using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        /* *** 配列 *** */

        int[] numbers = { 5, 15, 20, 25 };  // このように書くと、変数に複数の値を格納できる。
        // これを「配列」と言う。その中のそれぞれの値を「（配列の）要素」という。
        // 型名の直後に [] をつけて宣言する事で、配列を宣言できる。
        string[] fruits = { "apple", "banana", "orange" };  // 他のデータ型でも同じように配列に入れることができる。

        Console.WriteLine(numbers[2]);  // 添字（「そえじ」と読む。英語では index という）を指定することで、要素を取り出すことができる。
        // ただし index は「0 から始まる」ことに注意すること。

        // 配列はよく for 文と組み合わせて使われる
        for (int i = 0; i < fruits.Length; i++) // 配列変数に ".Length" と付けると、配列の要素数を表す（※）
        {
            Console.WriteLine(fruits[i] + " は美味しい");    // （※）
        }
        // （※）index が 0 から始まるので、このように書く。これは典型的なパターンです。

        /*
         * ここで以下をやってみましょう
         * https://paiza.jp/works/cs/primer/beginner-cs4/13031/1 の演習 1
         * https://paiza.jp/works/cs/primer/beginner-cs4/13032/1 の演習 1
         * https://paiza.jp/works/cs/primer/beginner-cs4/13033/1 の演習 1
         */

        numbers[0] = 99; // 配列の index を指定すると値を上書きすることもできる

        // 値が上書きできたことをチェックしてみる
        foreach (var number in numbers)  // この書き方 (foreach) は非常によく使われます。
        {
            Console.WriteLine(number);
        }
        // この書き方 (foreach) をすると、numbers の中の要素を一つ number に入れてブロック内の処理をします。それを全ての要素に対して行います。

        /*
         * ここで以下をやってみましょう
         * https://paiza.jp/works/cs/primer/beginner-cs4/13034/1 の演習 1
         * https://paiza.jp/works/cs/primer/beginner-cs4/13037/1 の演習 1
         */

        Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
        Console.ReadLine();

        /* *** 関数（メソッド） *** */

        Wait(); // 関数を使うと、複数の処理をまとめておき、呼ぶことができる。

        // ここで https://paiza.jp/works/cs/primer/beginner-cs6/10301/1 の演習 1, 2 をやってみましょう

        Wait("Hit Enter...");   // 引数（「ひきすう」と読む。英語では parameter という）を渡して、渡された値によって異なる処理をさせることができる

        // 関数の引数が複数であることもある
        Daikei(2, 4, 3);
        Wait("Hit Enter...");

        /*
         * ここで以下をやってみましょう
         * https://paiza.jp/works/cs/primer/beginner-cs6/10302/1 の演習 1
         * */

        // 「戻り値」として「計算結果を返す」こともできる。
        float r = 10f;
        float enshu = Enshu(r);
        Console.WriteLine("半径 " + r + " の円の円周は " + enshu + "です");    // 関数は計算して結果を受け取ることができる。この結果を「戻り値」という。

        r = 100f;
        Console.WriteLine("半径 {0} の円の円周は {1} です", r, Enshu(r)); // 戻り値をそのまま「値」として扱うこともできる。

        Wait();

        /*
         * ここで以下をやってみましょう
         * https://paiza.jp/works/cs/primer/beginner-cs6/10304/1 の演習 1
         * */
    }

    /// <summary>
    /// メッセージを表示して、処理を停止し、Enter キーが入力されたら次へ進む
    /// （注）関数は class の中、他の関数の外に書かなければならない。ここで「インデント」が重要になる。
    /// </summary>
    static void Wait()  // void は「戻り値なし」という意味です。static は、ここでは "static な関数 Main から呼ばれたから" 必要です。コンソールアプリケーションの場合は関数に static を付ける必要があります。
    {
        Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
        Console.ReadLine();
    }

    /// <summary>
    /// パラメーター（引数）に渡されたメッセージを表示して、処理を停止し、Enter キーが入力されたら次へ進む
    /// （注）関数名が同じでも、引数の数や型が異なっていれば違う関数として扱われる。これを関数の「オーバーロード」という。
    /// </summary>
    /// <param name="message">表示したいメッセージ</param>
    static void Wait(string message)    // 引数には型を指定する必要があります
    {
        Console.Write(message); // パラメーター変数に渡された文字列を表示する
        Console.ReadLine();
    }

    /// <summary>
    /// 台形の面積を求める
    /// （注）引数を複数受け取ることもできる
    /// </summary>
    /// <param name="joutei"></param>
    /// <param name="katei"></param>
    /// <param name="takasa"></param>
    static void Daikei(float joutei, float katei, float takasa)
    {
        float menseki = (joutei + katei) * takasa / 2;
        Console.WriteLine("上底 {0}、下底 {1}、高さ {2} の台形の面積は {3} です", joutei, katei, takasa, menseki);
    }

    /// <summary>
    /// 引数に指定された半径から円周を求める
    /// </summary>
    /// <param name="radius">半径</param>
    /// <returns>円周</returns>
    static float Enshu(float radius)    // float は戻り値の型です。関数で戻り値を返す時は、その型を指定しなければなりません。
    {
        float enshu = 2 * 3.14f * radius;
        return enshu;   // return enshu と書くと、計算した結果である enshu を戻り値として返す事ができる
    }
}
