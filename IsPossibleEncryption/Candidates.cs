using System;
using System.Collections.Generic;
using Pipe4Net;

namespace IsPossibleEncryption
{
    public class Candidates
    {
        public bool Check(string nonEcry, string encry)
        {
            if (BothCandidatesAreEmptyOrNull(nonEcry, encry))
                return true;

            if (OneOfTheCandidatesIsEmptyOrNull(nonEcry, encry))
                return false;

            return HaveSameLength(nonEcry, encry) && PossibleEncryption(nonEcry, encry);
        }

        private bool OneOfTheCandidatesIsEmptyOrNull(string awesome, string blossome)
        {
            var awesomeIsEmpty = string.IsNullOrWhiteSpace(awesome);
            var blossomeIsEmpty = string.IsNullOrWhiteSpace(blossome);

            return awesomeIsEmpty || blossomeIsEmpty;
        }


        public bool BothCandidatesAreEmptyOrNull(string awesome, string blossome)
        {
            var awesomeIsEmpty = string.IsNullOrWhiteSpace(awesome);
            var blossomeIsEmpty = string.IsNullOrWhiteSpace(blossome);

            return awesomeIsEmpty && blossomeIsEmpty;
        }

        private bool HaveSameLength(string awesome, string blossome)
        {
            return awesome.Length == blossome.Length;
        }

        private bool PossibleEncryption(string awesome, string blossome)
        {
            var encryptedPairs = new Dictionary<char, char>(awesome.Length);

            for (var i = 0; i < awesome.Length; i++)
            {
                var maybe = encryptedPairs.AddIfNotExists(awesome[i], blossome[i]);
                if (maybe.Value == default(char)) continue;
                if (maybe.Value != blossome[i]) return false;
            }

            return true;
        }
    }

    public static class DictionaryExtensitons
    {
        public static Option<T> AddIfNotExists<T>(this Dictionary<T, T> _this, T key, T value)
        {
            if (_this.ContainsKey(key))
                return Option<Char>.From(_this[key]);

            _this.Add(key, value);

            return Option<Char>.None<T>();
        }
    }
}