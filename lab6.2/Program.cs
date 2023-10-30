using System;
using System.Collections.Generic;


public abstract class GraphicPrimitive
{
    public int X { get; set; }
    public int Y { get; set; }

    public abstract void Draw();

    public void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public virtual void Scale(float factor)
    {
    
    }
}


public class Circle : GraphicPrimitive
{
    public int Radius { get; set; }

    public Circle(int x, int y, int radius)
    {
        X = x;
        Y = y;
        Radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a circle at ({X}, {Y}) with radius {Radius}");
    }

    public override void Scale(float factor)
    {
        Radius = (int)(Radius * factor);
    }
}


public class Rectangle : GraphicPrimitive
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a rectangle at ({X}, {Y}) with width {Width} and height {Height}");
    }

    public override void Scale(float factor)
    {
        Width = (int)(Width * factor);
        Height = (int)(Height * factor);
    }
}

public class Triangle : GraphicPrimitive
{
    public override void Draw()
    {
        Console.WriteLine($"Drawing a triangle at ({X}, {Y})");
    }
}

public class Group : GraphicPrimitive
{
    private List<GraphicPrimitive> elements = new List<GraphicPrimitive>();

    public void AddElement(GraphicPrimitive element)
    {
        elements.Add(element);
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a group at ({X}, {Y})");
        foreach (var element in elements)
        {
            element.Move(X, Y); 
            element.Draw();
        }
    }

    public override void Move(int x, int y)
    {
        base.Move(x, y);
        foreach (var element in elements)
        {
            element.Move(x, y);
        }
    }
}


public class GraphicsEditor
{
    private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public void DrawAll()
    {
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }

    public void ScaleAll(float factor)
    {
        foreach (var primitive in primitives)
        {
            primitive.Scale(factor);
        }
    }
}

class Program
{
    static void Main()
    {
        var editor = new GraphicsEditor();

        var circle = new Circle(10, 10, 5);
        var rectangle = new Rectangle(20, 20, 8, 6);
        var triangle = new Triangle();

        var group = new Group();
        group.AddElement(circle);
        group.AddElement(rectangle);

        editor.AddPrimitive(group);
        editor.AddPrimitive(triangle);

        editor.DrawAll();

        editor.ScaleAll(2);

        Console.WriteLine("\nAfter Scaling:\n");
        editor.DrawAll();
    }
}
