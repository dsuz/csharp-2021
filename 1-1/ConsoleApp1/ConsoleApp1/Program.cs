using System;

class Program
{
    // この中にプログラムを書くと実行される
    static void Main(string[] args)
    {
        /* *** Console.Write, Console.WriteLine を呼ぶと文字を出力できる *** */
        Console.Write("Console.Write を呼んだ");
        Console.WriteLine("Console.WriteLine を呼んだ");
        Console.WriteLine("Console.WriteLine をもう一度呼んだ");

        // 以下はプログラムを一旦停止させるためのものです。これらをコメントアウトすると、プログラムはすぐに終了します（実行結果が確認できなくなる）。
        Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
        Console.ReadLine();

        // "//" を先頭（左端）に書くとその行は「コメント」になる。コメント行は実行されない。

        /* *** 「変数」を「宣言」し、「値」を「代入」して出力する *** */
        int money;  // int は「整数」
        string name;    // string は「文字列」

        money = 5000;
        name = "ああああ";  // 「"」（ダブルクォーテーションと呼ぶ。Shift + 2 で入力できる）で囲むとそれは「文字列」として扱われる

        Console.WriteLine(money);
        Console.WriteLine(name);

        Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
        Console.ReadLine();

        /* *** 計算し、結果を出力する *** */
        int answer;

        answer = 1 + 2; // 足し算
        Console.WriteLine(answer);

        answer = 8 - 5; // 引き算
        Console.WriteLine(answer);

        answer = 3 * 5; // かけ算。記号は「*」（アスタリスク）である。
        Console.WriteLine(answer);
        
        answer = 63 / 9;    // 割り算。記号は「/」（スラッシュ）である。
        Console.WriteLine(answer);
        
        answer = 10 % 3;    // 剰余算
        Console.WriteLine(answer);
        
        Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
        Console.ReadLine();

        /* *** 文字列と文字列を + で足すと、文字列を連結することができる *** */
        string a;
        a = "あいうえお";
        string b = "かきくけこ"; // 宣言と代入をまとめて1行で書くこともできる。これを「初期化」と言う。
        string c = a + b;
        Console.WriteLine(c);

        Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
        Console.ReadLine();

        /* *** 練習 1 *** 
         * 文字列型の変数 aStr と整数型の変数 aInt を宣言し、それぞれに「文字列として」「整数として」1 と 2 を足した結果を代入せよ。
         * 結果を代入したら、それを出力せよ。
         * *** */
        string aStr;
        int aInt;

        // 中略

        Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
        Console.ReadLine();

        /* *** 練習 2 *** 
         * 10 割る 3 を計算し、出力せよ。
         * *** */

        // 中略

        Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
        Console.ReadLine();

        /* *** 特別な書き方 *** */
        int x = 0;  // 整数型の変数 x を宣言し、0 で初期化している

        x = x + 1;  // x（つまり 0）に 1 を足して、それを x に代入している。普通の数学とは = の使い方が違うことに注意すること。
        Console.WriteLine(x);

        x++;    // x = x + 1 はこのように書くこともできる
        Console.WriteLine(x);

        x += 1; // x = x + 1 はこのように書くこともできる
        Console.WriteLine(x);

        x += 10;    // ということは x = x + 10 はこのように書ける
        Console.WriteLine(x);

        Console.Write("Enter キーを押してください...");
        Console.ReadLine();
    }
}
