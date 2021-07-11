using System;
using System.Collections.Generic;   // List と Dictionary を使うためにこの行を追加する
using System.Linq;                  // 配列 → List の変換をするためにこの行を追加する

class Program
{
    static void Main(string[] args)
    {
        //ArrayExample();
        ListExample();
        //ListExercise01();
        //ListExercise02();
        //DictionaryExample();

        Console.Write("\r\nHit any key...\r\n");
        Console.ReadKey(true); // 何かキーを押すまで抜けないために書いている
    }

    /// <summary>
    /// 配列の実行例
    /// </summary>
    static void ArrayExample()
    {
        // 配列はごく限られた操作しかできない。例えば、「3番目の要素を取り除く」には以下のような操作をする必要がある。

        int[] intArray1 = { 0, 1, 2, 3, 4, 5 };
        int[] intArray2 = new int[intArray1.Length - 1];
        int counter = 0;

        for (int i = 0; i < intArray1.Length; i++)
        {
            if (i != 2) // 3 番目の要素を取り除く
            {
                intArray2[counter] = intArray1[i];
                counter++;
            }
        }
        
        // 結果を確認する
        foreach (var i in intArray2)
            Console.Write(i.ToString() + " ");

        // このように配列は実践的な操作をするのにたくさん処理を書かなくてはならない。
        // この問題を解決するために List という仕組み（クラス）がある。List の基本的は使い方は Exercise02 を参照せよ。
    }

    /// <summary>
    /// List の基本操作
    /// </summary>
    static void ListExample()
    {
        // List を初期化する
        List<string> strList = new List<string>();  // List<T> の T に型を指定することで「型 T の List」を表す
        Console.WriteLine("===== Add() で要素を追加する");
        strList.Add("orange");
        strList.Add("apple");
        strList.Add("banana");

        // 配列と同様に扱える
        for (int i = 0; i < strList.Count; i++) // 要素数が Count プロパティである（Length ではない）ことに注意
            Console.WriteLine(strList[i]);

        Console.WriteLine("===== Insert() で途中に要素を追加できる");
        strList.Insert(2, "kiwi");

        foreach (var item in strList)
            Console.WriteLine(item);

        Console.WriteLine("===== ソートができる");
        strList.Sort();

        foreach (var item in strList)
            Console.WriteLine(item);

        Console.WriteLine("===== 要素を削除できる");
        strList.Remove("orange");

        foreach (var item in strList)
            Console.WriteLine(item);

        Console.WriteLine("===== インデックスを指定して途中の要素を削除できる");
        strList.RemoveAt(2);

        foreach (var item in strList)
            Console.WriteLine(item);

        // その他、どんな操作ができるかについては https://itsakura.com/csharp-list や独習 C# 第6章 コレクションの 6.2.1 List（リスト）などを参照せよ。

        Console.WriteLine("===== 配列から List に変換することもできる");
        int[] intArray = { 17, 61, 3, 19, 54, 22 };
        List<int> intList = intArray.ToList();
        intList.Remove(19);

        foreach (var item in intList)
            Console.Write(item.ToString() + " ");
    }

    /// <summary>
    /// 以下のコードをアンコメントして ??? の部分を追記し、以下の結果を出力するコードにせよ。
    /// 結果: 10 30 108 75 が 4 行で出力される
    /// </summary>
    static void ListExercise01()
    {
        /*
        var list = new List<???> { 10, 15, 30, 60 };
        list[???] = 75;
        list.??? (15);
        list.??? (2, 108);

        foreach(var ??? in list)
        {
            Console.WriteLine(item);
        }
        */
    }


    /// <summary>
    /// 以下のように、コンソールから文字列を入力させ続け、何も入力せずEnterを押すと、それまで入力した文字列が「アルファベット順に」全て表示されるプログラムを作れ。このとき文字列は、Listで作った可変長配列に格納すること。

    /// （実行例）
    /// 
    /// 文字列を入力:apple
    /// 文字列を入力:good
    /// 文字列を入力:pineapple
    /// 文字列を入力:big
    /// 文字列を入力:dog
    /// 文字列を入力:cowboy
    /// 文字列を入力:                            (← 何も入力せず、Enterを押すと、入力を終了する)
    /// 
    /// apple good pineapple big dog cowboy
    /// </summary>
    static void ListExercise02()
    {
        while (true)
        {
            Console.Write("文字列を入力:");
            string buf = Console.ReadLine();

            if (buf.Length == 0)
            {
                break;
            }
        }
    }

    static void DictionaryExample()
    {
        // Dictionary の初期化
        // Dictionary<T1, T2> の T1, T2 に型をそれぞれ指定することで、T1 をキー、T2 を値とした Dictionary を宣言できる
        Dictionary<string, string> countries = new Dictionary<string, string>();
        // 要素を追加する
        countries.Add("jp", "日本");
        countries.Add("us", "米国");
        countries.Add("uk", "英国");
        // 要素を取り出す
        Console.WriteLine(countries["jp"]); // 添字の指定の仕方が配列と若干異なることに注意すること
        
        /*
         * ここで以下をやってみましょう
         * https://paiza.jp/works/cs/primer/beginner-cs9/22902/1
         * */

        // 配列のように扱うこともできる
        foreach (var c in countries)
        {
            Console.WriteLine(c.Key + ": " + c.Value);
        }

        /*
         * ここで以下をやってみましょう
         * https://paiza.jp/works/cs/primer/beginner-cs9/22904/1
         * */

        // こんなこともできます
        Dictionary<string, int> wordCounter = new Dictionary<string, int>();    // キーは単語、値は単語数
        string phrase = "A man who can can a can can can the can";
        string[] words = phrase.ToLower().Split(' ');   // 文字列をすべて小文字にして、スペースで区切って単語リストにする
        Console.WriteLine("次のフレーズから単語ごとにカウントします: " + phrase);

        foreach (var word in words)
        {
            if (wordCounter.ContainsKey(word))
            {
                wordCounter[word]++;    // キーとなる単語が既にあったらカウントアップする
            }
            else
            {
                wordCounter.Add(word, 1);   // キーがなければ追加する
            }
        }

        // 各キーと値（単語数）を出力する
        foreach (var item in wordCounter)
        {
            Console.WriteLine(item.Key + ": " + item.Value);
        }
    }
}
