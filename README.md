# SOLID Principles Demo

A C# project demonstrating all 5 SOLID design principles through shape calculations.

## What it does

- Calculates areas of 2D shapes (Rectangle, Circle, Square)
- Calculates volumes of 3D shapes (Cube)
- Shows clean, extensible code using all SOLID principles

## SOLID Principles Demonstrated

**Single Responsibility Principle (SRP)**
- Each class has one job: shapes calculate their properties, printers handle output

**Open/Closed Principle (OCP)**
- Easy to add new shapes without modifying existing code

**Liskov Substitution Principle (LSP)**
- Square implements its own Area() method instead of inheriting from Rectangle
- Any IShape1 can be used interchangeably

**Interface Segregation Principle (ISP)**
- Separate interfaces for 2D shapes (IShape1) and 3D shapes (IShape2)
- Classes only implement what they need

**Dependency Inversion Principle (DIP)**
- Program depends on abstractions (interfaces) not concrete classes
- IAreaPrinter and IVolumePrinter interfaces allow flexible implementations

## Code Structure

```
IShape (marker interface)
├── IShape1 (Area calculation)
│   ├── Rectangle
│   ├── Circle  
│   └── Square
└── IShape2 (Volume calculation)
    └── Cube

IAreaPrinter → AreaPrinter
IVolumePrinter → VolumePrinter
```

## How to run

```bash
dotnet run
```

## Output
```
Rectangle Area: 50
Circle Area: 153.938040026
Square Area: 16
Cube Volume: 27
```

## Adding new shapes

**2D Shape:**
```csharp
public class Triangle : IShape1
{
    public double Base, Height;
    
    public Triangle(double b, double h) { Base = b; Height = h; }
    
    public double Area() { return 0.5 * Base * Height; }
}
```

**3D Shape:**
```csharp
public class Sphere : IShape2
{
    public double Radius;
    
    public Sphere(double r) { Radius = r; }
    
    public double Volume() { return (4.0/3.0) * Math.PI * Math.Pow(Radius, 3); }
}
```
