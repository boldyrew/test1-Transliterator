using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transliterator
{
    public class Transliterator
    {
        //Словарь букв
        public IDictionary<char, string> Alphabet = null;

        //Символы с особенной транслитерацией в начале слова
        public IDictionary<char, string> FirstSymbols = null;

        //Буквосочетания c особенной транслитерацией
        public IDictionary<string, string> SymCombs = null;

        public Transliterator()
        {
            Alphabet = new Dictionary<char, string>();
            Alphabet.Add('a', "a");
            Alphabet.Add('б', "b");
            Alphabet.Add('в', "v");
            Alphabet.Add('г', "h");
            Alphabet.Add('ґ', "g");
            Alphabet.Add('д', "d");
            Alphabet.Add('е', "e");
            Alphabet.Add('є', "ie");
            Alphabet.Add('ж', "zh");
            Alphabet.Add('з', "z");
            Alphabet.Add('и', "y");
            Alphabet.Add('i', "i");
            Alphabet.Add('ї', "i");
            Alphabet.Add('й', "i");
            Alphabet.Add('к', "k");
            Alphabet.Add('л', "l");
            Alphabet.Add('м', "m");
            Alphabet.Add('н', "n");
            Alphabet.Add('о', "o");
            Alphabet.Add('п', "p");
            Alphabet.Add('р', "r");
            Alphabet.Add('с', "s");
            Alphabet.Add('т', "t");
            Alphabet.Add('у', "u");
            Alphabet.Add('ф', "f");
            Alphabet.Add('х', "kh");
            Alphabet.Add('ц', "ts");
            Alphabet.Add('ч', "ch");
            Alphabet.Add('ш', "sh");
            Alphabet.Add('щ', "shch");
            Alphabet.Add('ю', "iu");
            Alphabet.Add('я', "ia");
            Alphabet.Add('ь', "");
            Alphabet.Add('\'', "");

            FirstSymbols = new Dictionary<char, string>();
            FirstSymbols.Add('є', "ye");
            FirstSymbols.Add('ї', "yi");
            FirstSymbols.Add('й', "y");
            FirstSymbols.Add('ю', "yu");
            FirstSymbols.Add('я', "ya");

            SymCombs = new Dictionary<string, string>();
            SymCombs.Add("зг", "zgh");
        }

        public Transliterator(IDictionary<char, string> alphabet)
        {
            Alphabet = alphabet;
        }

        public Transliterator(IDictionary<char, string> alphabet, IDictionary<char, string> firstSymbols, IDictionary<string, string> symCombs)
        {
            Alphabet = alphabet;
            FirstSymbols = firstSymbols;
            SymCombs = symCombs;
        }

        public string GetTransliteratedWord(string entryWord)
        {
            //Флаг заглавной буквы
            bool isUpper = false;

            string result = "";

            //Текущая транслитерированная буква или буквосочетание
            string currSymComb = null;

            if (SymCombs != null)
                //Замена буквосочетаний с особенной транслитерацией, например "зг" - "zgh"
                foreach (var comb in SymCombs.OrderByDescending(s => s.Key.Length))
                {
                    entryWord = entryWord.Replace(comb.Key, comb.Value);
                }

            char[] _entry = entryWord.ToCharArray();

            //Перебор по символу во входном массиве символов
            for (int i = 0; i < _entry.Length; i++)
            {
                isUpper = false;
                //to lowercase
                if (char.ToLower(_entry[i]) != _entry[i]) {
                    isUpper = true;
                    _entry[i] = char.ToLower(_entry[i]);
                }

                //получение текущего символа
                currSymComb = _entry[i].ToString();

                //Проверка, является ли символ началом слова
                if (FirstSymbols != null && (i == 0 || _entry[i - 1] == '-' || _entry[i - 1] == ' '))
                {
                    //Если символ имеет особое правило транслитерации
                    if (FirstSymbols.ContainsKey(_entry[i]))
                    {
                        currSymComb = currSymComb.Replace(_entry[i].ToString(), FirstSymbols[_entry[i]]);
                    }
                    else if(Alphabet.ContainsKey(_entry[i]))
                    {
                        currSymComb = currSymComb.Replace(_entry[i].ToString(), Alphabet[_entry[i]]);
                    }
                //Замена согласно общим правилам
                } else if (Alphabet.ContainsKey(_entry[i]))
                {
                    currSymComb = currSymComb.Replace(_entry[i].ToString(), Alphabet[_entry[i]]);
                }

                //Возрат залавной буквы
                if (isUpper)
                    currSymComb = char.ToUpper(currSymComb[0]) + currSymComb.Substring(1);

                result += currSymComb;
            }

            return result;
        }


    }
}
