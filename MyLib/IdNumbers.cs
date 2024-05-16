namespace MyLib
{
    public class IdNumbers
    {
        public int ID;

        public IdNumbers(int number)
        {
            if (number >= 0)
                ID = number;
            else
                throw new ArgumentOutOfRangeException("Число меньше 0");
        }

        //Не используется, но пусть будет
        public override bool Equals(object? obj)
        {
            if (obj is IdNumbers number)
            {
                return this.ID == number.ID;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
