using System;

interface Shape {
  double Area();
}

// the class, being the structure of the data
class Rectangle : Shape {
  private double width;
  private double length;

  // if no constructor is defined:
  //  * zero-argument constructor
  //  * that does nothing

  public Rectangle(int w, int l) {
    // constructors always have same name as class
    width = w;
    length = l;
  }

  public double Area() {
    double a = width * length;
    return a;
  }

  public double Width() {
    Console.WriteLine("Width is accessed.");
    return width;
  }
}

class Circle : Shape {
  double radius;

  public Circle(double r) {
    radius = r;
  }

  public double Area() {
    double x = radius * 2 * 3.14;
    return x;
  }
}

class M {
  static double AreaPlus10(Shape s) {
    double a = s.Area();
    double b = a + 10;
    return b;
  }

  public static void Main(string[] args) {
    
    // one object instance called rect
    Rectangle rect = new Rectangle(6, 9);
    double a = rect.Area();
    // another object instance called rect2
    Rectangle rect2 = new Rectangle(88, 90);
    Circle circ = new Circle(45);
    double p1 = AreaPlus10(rect);
    double p2 = AreaPlus10(rect2);
    double p3 = AreaPlus10(circ);

    Console.WriteLine(p1);
    Console.WriteLine(p2);
    Console.WriteLine(p3);
/*
    Console.WriteLine(a);
    Console.WriteLine(rect2.Area());
    Console.WriteLine(w);
  */  
  }
}