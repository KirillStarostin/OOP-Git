namespace Starostin.KD_ZIVT_251_OOP6
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        public delegate double MyDel(int[] a);

        // Анонимный метод
        MyDel average = delegate (int[] a)
        {
            if (a == null || a.Length == 0)
                return 0;
            double summ = 0;
            foreach (int i in a)
            {
                summ += i;
            }
            return summ / a.Length;
        };
        [Test]
        public void Average_12345_Returns3()
        {
            Assert.AreEqual(3.0, average(new int[] { 1, 2, 3, 4, 5 }), 0.001);
        }

        [Test]
        public void Average_102030_Returns20()
        {
            Assert.AreEqual(20.0, average(new int[] { 10, 20, 30 }), 0.001);
        }

        [Test]
        public void Average_SingleElement_ReturnsElement()
        {
            Assert.AreEqual(5.0, average(new int[] { 5 }), 0.001);
        }

        [Test]
        public void Average_TwoElements_ReturnsFractional()
        {
            Assert.AreEqual(1.5, average(new int[] { 1, 2 }), 0.001);
        }

        [Test]
        public void Average_AllZeros_ReturnsZero()
        {
            Assert.AreEqual(0.0, average(new int[] { 0, 0, 0 }), 0.001);
        }

        [Test]
        public void Average_NegativeNumbers_ReturnsNegative()
        {
            Assert.AreEqual(-2.0, average(new int[] { -1, -2, -3 }), 0.001);
        }

        [Test]
        public void Average_MixedNumbers_ReturnsZero()
        {
            Assert.AreEqual(0.0, average(new int[] { -10, 10 }), 0.001);
        }

        [Test]
        public void Average_EmptyArray_ReturnsZero()
        {
            Assert.AreEqual(0.0, average(new int[] { }), 0.001);
        }

        [Test]
        public void Average_NullArray_ReturnsZero()
        {
            Assert.AreEqual(0.0, average(null), 0.001);
        }

        [Test]
        public void Average_BigArray_ReturnsCorrect()
        {
            int[] a = new int[100];
            for (int i = 0; i < 100; i++)
                a[i] = i + 1;
            Assert.AreEqual(50.5, average(a), 0.001);
        }
    }
}
