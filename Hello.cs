using System;

class C {
  public static void Main(string[] args) {
    int v = DoBoth("abc");
    Console.WriteLine(gv);
  }

  static int DoBoth(string str) {
    int r = DoubleLength(str);
    int s = Add10(r);
    return s;
  }

  static int DoubleLength(string str) {
    int len = str.Length;
    int len2 = len * 2;
    return len2;
  }

  static int Add10(int i) {
    int x = i + 10;
    return x;
    // return i + 10;
  }
}
