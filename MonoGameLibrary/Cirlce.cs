using System;
using Microsoft.Xna.Framework;
namespace MonoGameLibrary;
public readonly struct Circle : IEquatable<Circle>
{
/// Returns a value that indicates if the circle on the left hand side of the equality operator is equal to the
/// circle on the right hand side of the equality operator.
/// <param name="lhs">The circle on the left hand side of the equality operator.</param>
/// <param name="rhs">The circle on the right hand side of the equality operator.</param>
/// <returns>true if the two circles are equal; otherwise, false.</returns>
public static bool operator ==(Circle lhs, Circle rhs) => lhs.Equals(rhs);
/// Returns a value that indicates if the circle on the left hand side of the inequality operator is not equal to the
/// circle on the right hand side of the inequality operator.
/// <param name="lhs">The circle on the left hand side of the inequality operator.</param>
/// <param name="rhs">The circle on the right hand side fo the inequality operator.</param>
/// <returns>true if the two circle are not equal; otherwise, false.</returns>
public static bool operator !=(Circle lhs, Circle rhs) => !lhs.Equals(rhs);
    /// Returns the hash code for this circle.
    /// <returns>The hash code for this circle as a 32-bit signed integer.</returns>
    public override readonly int GetHashCode() => HashCode.Combine(X, Y, Radius);
    /// Returns a value that indicates whether the specified circle intersects with this circle.
    /// <param name="other">The other circle to check.</param>
    /// <returns>true if the other circle intersects with this circle; otherwise, false.</returns>
    public bool Intersects(Circle other)
    {
        int radiiSquared = (this.Radius + other.Radius) * (this.Radius + other.Radius);
        float distanceSquared = Vector2.DistanceSquared(this.Location.ToVector2(), other.Location.ToVector2());
        return distanceSquared < radiiSquared;
    }
    /// Returns a value that indicates whether this circle and the specified object are equal
    /// <param name="obj">The object to compare with this circle.</param>
    /// <returns>true if this circle and the specified object are equal; otherwise, false.</returns>
    public override readonly bool Equals(object obj) => obj is Circle other && Equals(other);
    /// Returns a value that indicates whether this circle and the specified circle are equal.
    /// <param name="other">The circle to compare with this circle.</param>
    /// <returns>true if this circle and the specified circle are equal; otherwise, false.</returns>
    public readonly bool Equals(Circle other) => this.X == other.X &&
                                                    this.Y == other.Y &&
                                                    this.Radius == other.Radius;
    /// Creates a new circle with the specified position and radius.
    /// <param name="x">The x-coordinate of the center of the circle.</param>
    /// <param name="y">The y-coordinate of the center of the circle..</param>
    /// <param name="radius">The length from the center of the circle to an edge.</param>
    public Circle(int x, int y, int radius)
    {
        X = x;
        Y = y;
        Radius = radius;
    }
    /// Creates a new circle with the specified position and radius.
    /// <param name="location">The center of the circle.</param>
    /// <param name="radius">The length from the center of the circle to an edge.</param>
    public Circle(Point location, int radius)
    {
        X = location.X;
        Y = location.Y;
        Radius = radius;
    }
     private static readonly Circle s_empty = new Circle();
    /// The x-coordinate of the center of this circle.
    public readonly int X;
    /// The y-coordinate of the center of this circle.
    public readonly int Y;
    /// The length, in pixels, from the center of this circle to the edge.
    public readonly int Radius;
    /// Gets the location of the center of this circle.
    public readonly Point Location => new Point(X, Y);
    /// Gets a circle with X=0, Y=0, and Radius=0.
    public static Circle Empty => s_empty;
    /// Gets a value that indicates whether this circle has a radius of 0 and a location of (0, 0).
    public readonly bool IsEmpty => X == 0 && Y == 0 && Radius == 0;
    /// Gets the y-coordinate of the highest point on this circle.
    public readonly int Top => Y - Radius;
    /// Gets the y-coordinate of the lowest point on this circle.
    public readonly int Bottom => Y + Radius;
    /// Gets the x-coordinate of the leftmost point on this circle.
    public readonly int Left => X - Radius;
    /// Gets the x-coordinate of the rightmost point on this circle.
    public readonly int Right => X + Radius;
}
