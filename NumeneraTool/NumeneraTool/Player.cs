namespace NumeneraTool
{
    public class Player
    {
        public DataClass Might { get; set; }
        public DataClass Speed { get; set; }
        public DataClass Intellect { get; set; }
        public string Name { get; set; }
        public Player()
        {
            Might = new DataClass();
            Speed = new DataClass();
            Intellect = new DataClass();
        }
    }
}