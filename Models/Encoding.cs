using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Encoding
    {
        private int _sign = 1;
        private string _key;
        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value;
                _keyShifts.Clear();


                foreach (char i in _key)
                {
                    if (!_keyShifts.ContainsKey(i))
                    {
                        _keyShifts.Add(i, _alphabetIndexes[i]);
                    }

                    if(!_alphabet.Contains(i.ToString().ToLower()))
                    {
                        throw new Exception("Некорректный ключ!");
                    }

                }
            }
        }
        public string Data { get; set; }

        private Dictionary<char, int> _alphabetIndexes = new Dictionary<char, int>();
        private Dictionary<char, int> _keyShifts = new Dictionary<char, int>();

        private string _alphabet;
        private string Alphabet
        {
            get
            {
                return _alphabet;
            }
            set
            {
                _alphabet = value;
                _alphabetIndexes.Clear();

                int index = 0;
                foreach (char i in _alphabet)
                {
                    _alphabetIndexes.Add(i, index);
                    index++;
                }
            }
        }


        public Encoding()
        {
            Alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            Key = "скорпион";
        }

        public string Encode()
        {
            _sign = 1;
            return Anti_Doubling(Data);
        }

        public string Decode()
        {
            _sign = -1;
            return Anti_Doubling(Data);
        }
        private string Anti_Doubling(string text)
        {
            string res = "";
            int index = 0;

            foreach (char symbol in text)
            {
                if (!_alphabetIndexes.ContainsKey(char.ToLower(symbol)))
                {
                    res += symbol;
                    continue;
                }

                int shift = _keyShifts[Key[index % Key.Length]];
                var tmp = _alphabetIndexes[char.ToLower(symbol)] + _sign * shift;
                int newIndex;

                if (tmp < 0)
                {
                    newIndex = (tmp + 33) % Alphabet.Length;
                }
                else
                {
                    newIndex = tmp % Alphabet.Length;
                }

                index++;

                if (char.IsUpper(symbol))
                {
                    res += char.ToUpper(Alphabet[newIndex]);
                }
                else
                {
                    res += Alphabet[newIndex];
                }
            }

            return res;
        }
    }
}