using lab_12;
using MyLib;

namespace ListTest
{
    [TestClass]
    public class ListTest
    {
        [TestMethod]
        public void AddToBeginEmptyListTest()
        {
            // Arrange
            MyList<Circle> myList = new MyList<Circle>();
            Circle circle = new Circle("Круг", 1, 10);

            // Act
            myList.AddToBegin(circle);

            // Assert
            Assert.AreEqual(1, myList.Count);
        }

        [TestMethod]
        public void AddToBeginFullListTest()
        {
            // Arrange
            MyList<Circle> myList = new MyList<Circle>();
            Circle circle = new Circle("Круг", 1, 10);
            Circle circle2 = new Circle("Кружок", 2, 15);

            // Act
            myList.AddToEnd(circle);
            myList.AddToBegin(circle2);

            // Assert
            Assert.AreEqual(2, myList.Count);
        }

        [TestMethod]
        public void AddToEndTest()
        {
            // Arrange
            MyList<Circle> myList = new MyList<Circle>();
            Circle circle = new Circle("Круг", 1, 10);

            // Act
            myList.AddToEnd(circle);

            // Assert
            Assert.AreEqual(1, myList.Count);
        }

        [TestMethod]
        public void RemoveItemTrueTest()
        {
            // Arrange
            MyList<Circle> myList = new MyList<Circle>();
            Circle circle = new Circle("Круг", 1, 10);
            myList.AddToEnd(circle);

            // Act
            myList.RemoveItem(circle);

            // Assert
            Assert.AreEqual(0, myList.Count);
        }

        [TestMethod]
        public void RemoveLastItemTrueTest()
        {
            // Arrange
            MyList<Circle> myList = new MyList<Circle>();
            Circle circle = new Circle("Круг", 1, 10);
            Circle circle2 = new Circle("Кружок", 2, 15);
            myList.AddToEnd(circle);
            myList.AddToEnd(circle2);

            // Act
            myList.RemoveItem(circle2);

            // Assert
            Assert.AreEqual(1, myList.Count);
        }

        [TestMethod]
        public void RemoveItemFalseTest()
        {
            // Arrange
            MyList<Circle> myList = new MyList<Circle>();
            Circle circle = new Circle("Круг", 1, 10);
            Circle notInCircle = new Circle("Б", 10, 20);
            myList.AddToEnd(circle);

            // Act
            bool result = myList.RemoveItem(notInCircle);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void RemoveItemByNameTest()
        {
            // Arrange
            MyList<Circle> myList = new MyList<Circle>();
            Circle circle = new Circle("Круг", 1, 10);
            Circle circle2 = new Circle("Б", 10, 20);
            myList.AddToEnd(circle);
            myList.AddToEnd(circle2);

            // Act
            myList.RemoveItemByName("Круг");

            // Assert
            Assert.AreEqual(1, myList.Count);
        }

        [TestMethod]
        public void DeepCloneTest()
        {
            // Arrange
            MyList<Circle> myList = new MyList<Circle>();
            Circle circle = new Circle("Круг", 1, 10);
            myList.AddToEnd(circle);

            // Act
            MyList<Circle> clonedList = myList.DeepClone();

            // Assert
            Assert.AreNotSame(myList, clonedList);
        }

        [TestMethod]
        public void CleanTest()
        {
            // Arrange
            MyList<Circle> myList = new MyList<Circle>();
            Circle circle = new Circle("Круг", 1, 10);
            Circle circle2 = new Circle("Б", 10, 20);
            myList.AddToEnd(circle);
            myList.AddToEnd(circle2);

            // Act
            myList.Clean();

            // Assert
            Assert.AreEqual(0, myList.Count);
        }

        [TestMethod]
        public void PointTest()
        {
            // Arrange
            Rectangle rectangle = new Rectangle("Квадрат", 1, 10, 10);
            Point(Rectangle rectangle)
            // Act

            // Assert

        }
    }
}