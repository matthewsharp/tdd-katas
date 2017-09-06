namespace StringCalculator
{
    public class Number
    {
        public string NumberString { get; set; }
        public int ParsedNumber => int.Parse(NumberString);
        public bool IsNegative => ParsedNumber < 0;
        public bool IsLessThanOrEqualToOneThousand => ParsedNumber <= 1000;
    }
}