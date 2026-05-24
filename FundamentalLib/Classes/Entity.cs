namespace FundamentalLib.Classes
{
    public abstract class Entity(BigDouble amount, string name, string image)
    {
        public BigDouble Amount { get; set; } = amount;

        public string Name { get; } = name;

        public string Image { get; } = image;

        public virtual void Increase(BigDouble value) => Amount.Add(value);

        public virtual void Decrease(BigDouble value) => Amount.Subtract(value);
    }
}
