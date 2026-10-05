using System;
using System.Collections.Generic;
using System.Text;

namespace Aplikacja_do_testowania
{
    public class Szyfr
    {
        public string Szyfrowanie(string text, int klucz)
        {
            StringBuilder wynik = new StringBuilder();
            foreach (char znak in text)
            {
                if (char.IsLetter(znak))
                {
                    char przesunietyZnak = (char)(znak + klucz);
                    if (char.IsUpper(znak) && przesunietyZnak > 'Z')
                    {
                        przesunietyZnak = (char)(przesunietyZnak - 26);
                    }
                    else if (char.IsLower(znak) && przesunietyZnak > 'z')
                    {
                        przesunietyZnak = (char)(przesunietyZnak - 26);
                    }
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
