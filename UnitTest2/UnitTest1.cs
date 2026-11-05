using System;
using System.IO;
using Aplikacja_do_testowania;
using Xunit;

namespace Aplikacja_do_testowania.IntegrationTests
{
    public class CaesarCipherIntegrationTests : IDisposable
    {
        private readonly Szyfr _cipher;
        private readonly string _testFilePath;

        public CaesarCipherIntegrationTests()
        {
            _cipher = new Szyfr();
            _testFilePath = Path.GetTempFileName();
        }

        public void Dispose()
        {
            if (File.Exists(_testFilePath))
            {
                File.Delete(_testFilePath);
            }
        }

        [Fact]
        public void Integration_EncryptText_SaveToFileAndDecryptSuccessfully()
        {
            string originalText = "Tajna wiadomosc 123!";
            int shift = 5;

            string encryptedText = _cipher.Szyfrowanie(originalText, shift);

            File.WriteAllText(_testFilePath, encryptedText);

            string fileContent = File.ReadAllText(_testFilePath);

            string decryptedText = _cipher.Deszyfrowanie(fileContent, shift);

            Assert.NotEqual(originalText, encryptedText); 
            Assert.Equal(encryptedText, fileContent);     
            Assert.Equal(originalText, decryptedText);    
        }
    }
}