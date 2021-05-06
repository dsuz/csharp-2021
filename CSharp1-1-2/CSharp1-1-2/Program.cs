using System;

namespace CSharp1_1_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /* *** var（暗黙的な型） *** */

            var v = 10f / 3;    // 右辺の方が「明らか」である時は、型名を var で指定することができる。
            Console.WriteLine(v);   // v を使わないと警告が出るので特に意味はないけれど出力している。

            Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
            Console.ReadLine();

            /* *** 条件分岐 *** */

            bool b = false; // bool 型は true もしくは false の値しかない
            b = true;

            if (b)  // () の中が真 (true) の時、次のブロック（{ と } で囲まれた中の命令）が実行される
            {
                Console.WriteLine("b は真");
            }
            else    // if () の () の中が真ではない（偽 = false）である時、こちらのブロックが実行される。else 以降は必要なければ書かなくてもよい。
            {
                Console.WriteLine("b は偽");
            }

            Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
            Console.ReadLine();

            // 偶数・奇数を判定する

            int num = 9;

            if (num % 2 == 0)   // () の中には式を指定することもできる。この式を「条件式」という。
            {
                Console.WriteLine("{0} は偶数", num);  // こういう書き方もできる。これを「書式 (format) の指定」という。教科書によっては載っていない。
            }
            else
            {
                Console.WriteLine("{0} は奇数", num);
            }

            Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
            Console.ReadLine();

            // ここまで理解したら、https://paiza.jp/works/cs/primer/beginner-cs2/13010/1 の演習を解いてみましょう。

            // 複数の条件で分岐する

            num = -5;

            if (num < 0)
            {
                Console.WriteLine("{0} は負", num);
            }
            else if (num > 0)   // else if で条件分岐を増やすことができる
            {
                Console.WriteLine("{0} は正", num);
            }
            else
            {
                Console.WriteLine("{0} は正でも負でもない", num);
            }

            Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
            Console.ReadLine();

            // ここまで理解したら、https://paiza.jp/works/cs/primer/beginner-cs2/13011/1 の演習を解いてみましょう。

            // こういう書き方もできる

            string str = "abcde";
            bool c = (str.Length > 3);  // 条件式の値を bool 型に入れることもできる

            if (c)
            {
                Console.WriteLine("{0} は 3 文字より長い", str);
            }
            else
            {
                Console.WriteLine("{0} は 3 文字より短い", str);
            }

            Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
            Console.ReadLine();

            // 条件の判定は順番も重要です

            num = 54;

            if (num % 2 == 0)
            {
                Console.WriteLine("{0} は 2 の倍数", num);
            }
            else if (num % 3 == 0)
            {
                Console.WriteLine("{0} は 3 の倍数", num);
            }
            else if (num % 6 == 0)
            {
                Console.WriteLine("{0} は 6 の倍数", num);
            }
            else
            {
                Console.WriteLine("{0} は 2, 3, 6 の倍数ではない", num);
            }

            Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
            Console.ReadLine();

            // 上記のプログラムは 6 の倍数を判定できない。なぜできないのかを考え、6 の倍数を判定できるように修正せよ。

            /* *** 繰り返し *** */

            // while を使った繰り返し

            int n = 0;

            while (n < 10)  // while (条件式) の条件式が true である間、繰り返し実行される
            {
                Console.WriteLine("n は {0} です", n);
                n++;
            }

            Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
            Console.ReadLine();

            n = 0;

            while (true)    // こうすると無限ループになるけれど
            {
                Console.WriteLine("n は {0} です", n);
                n++;

                if (n > 9)
                {
                    break;  // break; と書くとループを抜けられる
                }
            }

            Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
            Console.ReadLine();

            // ここまで理解したら、https://paiza.jp/works/cs/primer/beginner-cs3/13020/1 の演習を解いてみましょう。

            // for を使った繰り返し

            for (int i = 0; i < 10; i++)    // for (ループ変数の初期化; ループ条件式; 反復処理）と書く
            {
                Console.WriteLine("i は {0} です", i);
            }

            Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
            Console.ReadLine();

            // こういう書き方もできる

            for (int i = 9; i > -1; i--)    // 初期化・条件式・反復処理を工夫すると、このような「逆順」の処理も書ける
            {
                Console.WriteLine("i は {0} です", i);
            }

            Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
            Console.ReadLine();

            // ここまで理解したら、https://paiza.jp/works/cs/primer/beginner-cs3/13023/1 の演習を解いてみましょう。
        }
    }
}
