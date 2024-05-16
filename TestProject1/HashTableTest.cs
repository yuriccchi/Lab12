using lab_12;
using MyLib;

namespace UnitTest
{
    [TestClass]
    public class HashTableTest
    {
        [TestMethod]
        public void AddItemTest()
        {
            // Arrange
            MyHashTable<int, Circle> hashTable = new MyHashTable<int, Circle>();
            Circle circle = new Circle("Круг", 1, 10);

            // Act
            hashTable.AddItem(1, circle);

            // Assert
            Assert.AreEqual(1, hashTable.Count);
        }

        [TestMethod]
        public void ResizeTableTest()
        {
            // Arrange
            MyHashTable<int, Circle> hashTable = new MyHashTable<int, Circle>();
            Circle circle = new Circle("А", 1, 10);
            Circle circle1 = new Circle("Б", 2, 10);
            Circle circle2 = new Circle("В", 3, 10);
            Circle circle3 = new Circle("Г", 4, 10);
            Circle circle4 = new Circle("Д", 5, 10);
            Circle circle5 = new Circle("Е", 6, 10);
            Circle circle6 = new Circle("Ж", 7, 10);
            Circle circle7 = new Circle("З", 8, 10);
            Circle circle8 = new Circle("И", 9, 10);
            Circle circle9 = new Circle("К", 10, 10);
            Circle circle10 = new Circle("Л",11, 10);
            Circle circle11 = new Circle("М", 12, 10);
            Circle circle12 = new Circle("Н", 12, 10);

            // Act
            hashTable.AddItem(circle.id.ID, circle);
            hashTable.AddItem(circle1.id.ID, circle1);
            hashTable.AddItem(circle2.id.ID, circle2);
            hashTable.AddItem(circle3.id.ID, circle2);
            hashTable.AddItem(circle4.id.ID, circle4);
            hashTable.AddItem(circle5.id.ID, circle5);
            hashTable.AddItem(circle6.id.ID, circle6);
            hashTable.AddItem(circle7.id.ID, circle7);
            hashTable.AddItem(circle8.id.ID, circle8);
            hashTable.AddItem(circle9.id.ID, circle9);
            hashTable.AddItem(circle10.id.ID, circle10);
            hashTable.AddItem(circle11.id.ID, circle11);
            hashTable.AddItem(circle12.id.ID, circle12);

            // Assert
            Assert.AreEqual(13, hashTable.Count);
        }

        [TestMethod]
        public void ContainsKeyTestReturnsTrue()
        {
            // Arrange
            MyHashTable<int, Circle> hashTable = new MyHashTable<int, Circle>();
            Circle circle = new Circle("Круг", 1, 10);
            hashTable.AddItem(1, circle);

            // Act
            bool containsKey = hashTable.ContainsKey(1);

            // Assert
            Assert.IsTrue(containsKey);
        }

        [TestMethod]
        public void ContainsKeyTestReturnsFalse()
        {
            // Arrange
            MyHashTable<int, Circle> hashTable = new MyHashTable<int, Circle>();
            Circle circle = new Circle("Круг", 1, 10);
            hashTable.AddItem(1, circle);

            // Act
            bool containsKey = hashTable.ContainsKey(2);

            // Assert
            Assert.IsFalse(containsKey);
        }

        [TestMethod]
        public void RemoveByKeyTrueTest()
        {
            // Arrange
            MyHashTable<int, Circle> hashTable = new MyHashTable<int, Circle>();
            Circle circle = new Circle("Круг", 1, 10);
            hashTable.AddItem(1, circle);

            // Act
            hashTable.RemoveByKey(1);

            // Assert
            Assert.AreEqual(0, hashTable.Count);
        }

        [TestMethod]
        public void RemoveByKeyFalseTest()
        {
            // Arrange
            MyHashTable<int, Circle> hashTable = new MyHashTable<int, Circle>();
            Circle circle = new Circle("Круг", 1, 10);
            hashTable.AddItem(1, circle);

            // Act
            bool result = hashTable.RemoveByKey(2);

            // Assert
            Assert.IsFalse(result);
        }
    }
}