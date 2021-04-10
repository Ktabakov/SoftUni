using System;
using System.Collections.Generic;
using System.Text;

namespace ClassBoxData
{
    public class Box
    {
        private double length;
        private double width;
        private double height;
        public Box(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }
        public double Length
        {
            get => length;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                else
                {
                    length = value;
                }
            }
        }

        public double Width
        {
            get => width;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                else
                {
                    width = value;
                }
            }
        }

        public double Height
        {
            get => height;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                else
                {
                    height = value;
                }
            }
        }

        public double SurfaceArea()
        {
            return 2 * (length * width) + 2 * (length * height) + 2 * (width * height);
        }
        public double LateralSurfaceArea()
        {
            return 2 * (length * height) + 2 * (width * height);
        }
        public double Volume()
        {
            return length * height * width;
        }
    }
}
