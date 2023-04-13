using System.Drawing;

namespace Shapes.UnitTests
{
    public class Tests
    {

        [Test]
        public void RectangleDimensionsTest()
        {
            var rectangle = new Rectangle(0, 0, 4, 1);
            
            ChangeRectangleDimensions(rectangle, 2, 3);

            Assert.That(rectangle.Width, Is.EqualTo(2));
            Assert.That(rectangle.Height, Is.EqualTo(3));
        }

        [Test]
        public void SquareDimensionsTest() 
        {
            var square = new Square(0, 0, 5);
            square.Side = 4;
            Assert.That(square.Side, Is.EqualTo(4));
        }

        [Test]
        public void RectangleAreaTest()
        {
            var rectangle = new Rectangle(0, 0, 1, 2);
            CheckArea(rectangle);
        }

        [Test]
        public void SquareAreaTest()
        {
            var square = new Square(0,0, 5);
            Assert.That(square.Area, Is.EqualTo(25));
        }

        [Test]
        public void CircleAreaTest()
        {
            var circle = new Circle(4, 8, 2);

            Assert.That(circle.Area, Is.EqualTo(12.566370614).Within(1e-8));
        }

        private void CheckArea(Rectangle rectangle)
        {
            ChangeRectangleDimensions(rectangle, 4, 5);
            Assert.That(rectangle.Area, Is.EqualTo(20));
        }

        void ChangeRectangleDimensions(Rectangle r, double width, double heigh)
        {
            r.Width = width;
            r.Height = heigh;
        }


    }
}