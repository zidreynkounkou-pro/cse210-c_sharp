using System;

public class Circle : Shape
{
  private double _radius;

  public Circle(double radius, string color) : base(color)
  {
    _radius = radius;
  }

    public override double GetArea()
    {
      return _radius * _radius * Math.PI;
    }
}