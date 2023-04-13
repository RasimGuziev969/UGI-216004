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
        public void SquareTest() 
        {
            var square = new Square(0, 0, 5);
            ChangeRectangleDimensions(square, 2, 3);
            Assert.That(square.Width, Is.EqualTo(square.Height));
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
            var square = new Square(0,0, 1);
            CheckArea(square);
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