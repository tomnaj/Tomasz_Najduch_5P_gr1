namespace Aplikacja_do_testowania
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            string input = "Hello";
            int klucz = 3;
            string oczekiwany = "Khoor";

            string wynik = new Szyfr().Szyfrowanie(input, klucz);

            Assert.Equal(oczekiwany, wynik);
        }

        [Fact]
        public void Test2()
        {
            string input = "Khoor";
            int klucz = 3;
            string oczekiwany = "Hello";
            string wynik = new Szyfr().Deszyfrowanie(input, klucz);
            Assert.Equal(oczekiwany, wynik);
        }

        [Fact]
        public void Test3()
        {
            string input = "Hello, World!";
            int klucz = 5;
            string oczekiwany = "Mjqqt, Btwqi!";
            string wynik = new Szyfr().Szyfrowanie(input, klucz);
            Assert.Equal(oczekiwany, wynik);
        }

        [Fact]
        public void Test4()
        {
            string inputNull = null;
            int klucz = 3;

            Assert.Throws<ArgumentNullException>(() => new Szyfr().Szyfrowanie(inputNull, klucz));
        }
    }
}
