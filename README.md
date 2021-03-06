# RayTracer Challenge

Dotnet core project based on the Ray Tracer Challenge book by Jamis Buck.

This project will be developed in .Net Core 3.0 with the Nullable Reference Type being denied.

## Chapter 1

I first created the `Tuple` class like suggested by the book. After completing chapter 1, I decided to split them into two separates classes with no inheritance. The rational behind this was that
I was starting to code some type check in order to make some of the functions work with one or the other type. For example, Dot and Cross product only apply to the Vector and exception had to be thrown
when the wrong type was used.

The second reason was that separating the classes offers better operator management. For example, adding two points make no sense, as stated in the book, yet the `Tuple` class offers an addition operator.
By separating the classes, I can no avoid coding the plus operator between two points.

If later I realize that there are needs to switch from one type to another, I'll implement type conversion.

## Chapter 2

When creating the canvas class, I realized that I needed an easy way to initialize the board to all black without having to create a new color for each pixel.
I decided to convert the Color class into a struct whcih will automatically initialize its color's chanels to 0.