using System;

class Program
{
    static void Main(string[] args)
    {
        Vector v1 = new Vector();
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

        Wait();

        /*
         * ここで以下をやってみましょう
         * https://paiza.jp/works/cs/primer/beginner-cs7/21001/1 の演習 1
         * */

        Person shohei = new Person("Shohei Ohtani", 1994, 7, 5);
        int age1 = shohei.GetAge();
        Console.WriteLine(shohei.name + " さんの年齢は " + age1 + " 歳です。");

        Person p = new Person("Roki Sasaki", 2001, 11, 3);
        Console.WriteLine("{0} さんの年齢は {1} 歳です。", p.name, p.GetAge());

        Wait();

        /*
         * ここで以下をやってみましょう
         * https://paiza.jp/works/cs/primer/beginner-cs7/21002/1 の演習 1
         * https://paiza.jp/works/cs/primer/beginner-cs7/21004/1 の演習 1
         * */



    }

    static void Wait()  // void は「戻り値なし」という意味です。static は、ここでは "static な関数 Main から呼ばれたから" 必要です。コンソールアプリケーションの場合は関数に static を付ける必要があります。
    {
        Console.Write("Enter キーを押すと次に進みます。Ctrl + C で実行を中止できます...");
        Console.ReadLine();
    }
}
