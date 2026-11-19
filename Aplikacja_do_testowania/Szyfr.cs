using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacja_do_testowania
{
    public class Szyfr
    {
        public string Szyfrowanie(string text, int klucz)
        {
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            int przesuniecie = klucz % 26;
            StringBuilder wynik = new StringBuilder(text.Length);

            foreach (char znak in text)
            {
                if (char.IsUpper(znak))
                {
                    char przesunietyZnak = (char)(znak + przesuniecie);
                    if (przesunietyZnak > 'Z') przesunietyZnak = (char)(przesunietyZnak - 26);
                    else if (przesunietyZnak < 'A') przesunietyZnak = (char)(przesunietyZnak + 26);
                    wynik.Append(przesunietyZnak);
                }
                else if (char.IsLower(znak))
                {
                    char przesunietyZnak = (char)(znak + przesuniecie);
                    if (przesunietyZnak > 'z') przesunietyZnak = (char)(przesunietyZnak - 26);
                    else if (przesunietyZnak < 'a') przesunietyZnak = (char)(przesunietyZnak + 26);
                    wynik.Append(przesunietyZnak);
                }
                else
                {
                    wynik.Append(znak);
                }
            }

            return wynik.ToString();
        }

        public string Deszyfrowanie(string text, int klucz)
        {
            return Szyfrowanie(text, -klucz);
        }
    }
}
