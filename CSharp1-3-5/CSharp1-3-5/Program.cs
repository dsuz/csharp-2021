using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        BadExample();
        ExceptionHandling();

        string path = "Test.txt";
        // FileOperation(path);

        Console.WriteLine("Hit Enter...");
        Console.ReadLine();
    }

    static void BadExample()
    {
        // 以下のようなプログラムを実行すると、0 による除算 (Divide by Zero) のためプログラムはいきなり終了（不正終了）してしまう。
        int a = 1;
        int b = 0;
        int c = a / b;
        Console.WriteLine(c.ToString());
    }

    /// <summary>
    /// 例外処理 (exception handling) のやり方
    /// </summary>
    static void ExceptionHandling()
    {
        // 例外が起きる可能性がある場合は、try の中でその処理を実行し、例外が起きた場合は catch で処理する
        try
        {
            int a = int.MaxValue;
            int b = 0;
            // int c = a / b;
            // Console.WriteLine(c);
            int[] d = { 0, 1, 2 };
            Console.WriteLine(d[3]);
        }
        catch (DivideByZeroException e) // DivideByZeroException が起きた（スローされた）時はここで catch して続きを処理する
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception e) // それ以外の例外が起きた時はここで catch する
        {
            Console.WriteLine(e.Message);
        }
    }

    /// <summary>
    /// 例外処理の使用例:
    /// 指定したファイルを開いて内容を表示する。
    /// 指定したファイルがない場合は新しくファイルを作り、現在
    /// </summary>
    /// <param name="filePath"></param>
    static void FileOperation(string filePath)
    {
        try
        {
            // ここでの using は「スコープを抜けたらファイルをクローズする」という意味の using です
            using (StreamReader sr = new StreamReader(filePath))
            {
                // 指定したファイルを開いて内容を読み込み、表示する
                while (sr.Peek() > -1)
                {
                    string s = sr.ReadLine();
                    Console.WriteLine(s);
                }
            }
        }
        catch (FileNotFoundException e)
        {
            // ファイルが見つからなかったらメッセージを表示して新しくファイルを作る
            Console.WriteLine(e.Message);
            
            try
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(DateTime.Now.ToString());  // 現在日時を書き込む
                    Console.WriteLine($"{((FileStream)sw.BaseStream).Name} を作成しました。");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
