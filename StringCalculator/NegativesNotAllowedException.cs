using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class NegativesNotAllowedException : Exception
    {
        public NegativesNotAllowedException(IEnumerable<int> negativeNumbers)
            : base($"Negatives not allowed: {string.Join(',', negativeNumbers)}")
        {
        }
    }
}