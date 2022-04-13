namespace Lesson5
{
    public record Number
    {
        public int Value { get; init; }

        public Number(int number)
        {
            this.Value = number;
        }
    };
}
