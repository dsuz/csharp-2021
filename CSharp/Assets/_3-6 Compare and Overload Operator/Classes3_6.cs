using System;
using System.Linq;

/// <summary>
/// アイテム（装備）データを格納する構造体
/// ID 順でソートする。つまり ID の値が大きい方が「大きいアイテム」とみなされる。
/// アイテムとアイテムの和 (+) は合成されたアイテムとなり、ランダムなアイテムとなる。
/// </summary>
public struct Gear : IComparable
{
    /// <summary>アイテムの ID</summary>
    public int Id;
    /// <summary>アイテムの名前</summary>
    public string Name;
    /// <summary>アイテムの値段</summary>
    public int Price;
    /// <summary>攻撃力</summary>
    public int Attack;
    /// <summary>防御力</summary>
    public int Defence;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public Gear(int id, string name, int price, int attack, int defence)
    {
        this.Id = id;
        this.Name = name;
        this.Price = price;
        this.Attack = attack;
        this.Defence = defence;
    }

    /// <summary>
    /// 大小関係を ID 順として定義する
    /// </summary>
    /// <param name="o">大小関係を比較する相手</param>
    /// <returns>自分の方が小さい時は -1, 自分の方が大きい時は 1, 同値の時は 0</returns>
    int IComparable.CompareTo(object o)
    {
        Gear other = (Gear) o;

        if (this.Id < other.Id)
        {
            return -1;  // 自分の ID が小さい時は「自分の方が小さい」とする
        }
        else if (this.Id > other.Id)
        {
            return 1;  // 自分の ID が大きい時は「自分の方が大きい」とする
        }

        return 0;   // ID が同じなら「同じ」とする
    }

    /// <summary>
    /// 文字列データに変換する
    /// </summary>
    /// <returns>文字列</returns>
    public override string ToString()
    {
        return $"Id: {this.Id}, Name: {this.Name}, Price: {this.Price}, Attack: {this.Attack}, Defence: {this.Defence}";
    }

    /// <summary>
    /// Gear の足し算を定義する。
    /// Gear と Gear を足した場合、「合成」としてランダムな Gear を返す。
    /// </summary>
    /// <param name="g1">合成する Gear</param>
    /// <param name="g2">合成する Gear</param>
    /// <returns>合成された Gear</returns>
    public static Gear operator +(Gear g1, Gear g2)
    {
        int maxId = DataLoader.GearData.Max(item => item.Id);
        int id = UnityEngine.Random.Range(1, maxId + 1);
        Gear newGear = DataLoader.GearData.Where(item => item.Id == id).FirstOrDefault();
        return newGear;
    }
}
