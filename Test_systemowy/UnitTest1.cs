using System;
using System.Diagnostics;
using System.IO;
using Xunit;

namespace Aplikacja_do_testowania.Tests
{
    public class SzyfrSystemTests
    {
        private readonly string _exePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "Aplikacja_do_testowania.exe"
        );

        [Fact]
        public void SystemTest_ExecutableRunsWithoutErrors_ReturnsSuccessExitCode()
        {
            Assert.True(File.Exists(_exePath), $"Nie znaleziono pliku wykonywalnego: {_exePath}. Zbuduj najpierw projekt główny.");

            var startInfo = new ProcessStartInfo
            {
                FileName = _exePath,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using var process = Process.Start(startInfo);
            Assert.NotNull(process);

            process.StandardInput.WriteLine();
            process.StandardInput.Close();

            string output = process.StandardOutput.ReadToEnd();
            string errors = process.StandardError.ReadToEnd();

            bool exited = process.WaitForExit(5000);

            Assert.True(exited, "Proces aplikacji nie zakończył się w wyznaczonym czasie (5s).");
            Assert.Equal(0, process.ExitCode);
            Assert.True(string.IsNullOrEmpty(errors), $"Błędy na standardowym wyjściu błędów: {errors}");
            Assert.False(string.IsNullOrWhiteSpace(output), "Program nie zwrócił żadnego wyjścia na konsolę.");
        }

        [Fact]
        public void SystemTest_FullCipherCycle_EncryptsAndDecryptsBackToOriginal()
        {
            var szyfr = new Szyfr();
            string oryginalnaWiadomosc = "Ala ma kota, a kot ma Ale! Z";
            int klucz = 3;

            string zaszyfrowana = szyfr.Szyfrowanie(oryginalnaWiadomosc, klucz);
            string odszyfrowana = szyfr.Deszyfrowanie(zaszyfrowana, klucz);

            Assert.NotEqual(oryginalnaWiadomosc, zaszyfrowana);
            Assert.Equal(oryginalnaWiadomosc, odszyfrowana);
        }

        [Fact]
        public void SystemTest_NullInputInCipher_ThrowsArgumentNullException()
        {
            var szyfr = new Szyfr();

            Assert.Throws<ArgumentNullException>(() => szyfr.Szyfrowanie(null!, 3));
            Assert.Throws<ArgumentNullException>(() => szyfr.Deszyfrowanie(null!, 3));
        }
    }
}