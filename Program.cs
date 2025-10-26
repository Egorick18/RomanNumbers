public class RomanNumber
{
    private int value;

    private static readonly string[] romanSymbols = {
        "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"
    };

    private static readonly int[] arabicValues = {
        1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1
    };

    private static readonly Dictionary<char, int> romanToArabic = new Dictionary<char, int>
    {
        {'I', 1}, {'V', 5}, {'X', 10}, {'L', 50}, {'C', 100}, {'D', 500}, {'M', 1000}
    };

    public RomanNumber() { value = 1; }

    public RomanNumber(int number)
    {
        if (number <= 0 || number > 3999)
            throw new ArgumentOutOfRangeException(nameof(number), "Диапазон: 1-3999");
        value = number;
    }

    public RomanNumber(string romanNumber)
    {
        if (string.IsNullOrEmpty(romanNumber))
            throw new ArgumentException("Римское число не может быть пустым");
        value = RomanToInt(romanNumber);
        if (value <= 0 || value > 3999)
            throw new ArgumentOutOfRangeException(nameof(romanNumber), "Диапазон: 1-3999");
    }

    public int IntValue
    {
        get => value;
        set
        {
            if (value <= 0 || value > 3999)
                throw new ArgumentOutOfRangeException(nameof(value), "Диапазон: 1-3999");
            this.value = value;
        }
    }

    public string StringValue
    {
        get => IntToRoman(value);
        set
        {
            int result = RomanToInt(value);
            if (result <= 0 || result > 3999)
                throw new ArgumentOutOfRangeException(nameof(value), "Диапазон: 1-3999");
            this.value = result;
        }
    }

    private string IntToRoman(int number)
    {
        if (number <= 0 || number > 3999)
            throw new ArgumentOutOfRangeException(nameof(number), "Диапазон: 1-3999");

        string roman = "";
        int temp = number;

        for (int i = 0; i < arabicValues.Length; i++)
        {
            while (temp >= arabicValues[i])
            {
                roman += romanSymbols[i];
                temp -= arabicValues[i];
            }
        }
        return roman;
    }

    private int RomanToInt(string roman)
    {
        if (string.IsNullOrEmpty(roman)) return 0;

        roman = roman.ToUpper().Trim();
        int result = 0;
        int previousValue = 0;

        for (int i = roman.Length - 1; i >= 0; i--)
        {
            if (!romanToArabic.TryGetValue(roman[i], out int currentValue))
                throw new ArgumentException($"Недопустимый символ: {roman[i]}");

            if (currentValue < previousValue)
                result -= currentValue;
            else
                result += currentValue;

            previousValue = currentValue;
        }
        return result;
    }

    public override string ToString() => StringValue;

    // Арифметические операторы
    public static RomanNumber operator +(RomanNumber a, RomanNumber b)
        => new RomanNumber(a.value + b.value);

    public static RomanNumber operator -(RomanNumber a, RomanNumber b)
    {
        int result = a.value - b.value;
        if (result <= 0) throw new InvalidOperationException("Результат должен быть положительным");
        return new RomanNumber(result);
    }

    public static RomanNumber operator *(RomanNumber a, RomanNumber b)
        => new RomanNumber(a.value * b.value);

    public static RomanNumber operator /(RomanNumber a, RomanNumber b)
    {
        if (b.value == 0) throw new DivideByZeroException("Деление на ноль невозможно");
        int result = a.value / b.value;
        if (result <= 0) throw new InvalidOperationException("Результат должен быть положительным");
        return new RomanNumber(result);
    }

    public static bool operator <(RomanNumber a, RomanNumber b) => a.value < b.value;
    public static bool operator >(RomanNumber a, RomanNumber b) => a.value > b.value;
    public static bool operator <=(RomanNumber a, RomanNumber b) => a.value <= b.value;
    public static bool operator >=(RomanNumber a, RomanNumber b) => a.value >= b.value;
    public static bool operator ==(RomanNumber a, RomanNumber b)
    {
        if (ReferenceEquals(a, b)) return true;
        if (a is null || b is null) return false;
        return a.value == b.value;
    }
    public static bool operator !=(RomanNumber a, RomanNumber b) => !(a == b);

    public override bool Equals(object obj)
    {
        if (obj is RomanNumber other)
            return this.value == other.value;
        return false;
    }

    public override int GetHashCode() => value.GetHashCode();

}
