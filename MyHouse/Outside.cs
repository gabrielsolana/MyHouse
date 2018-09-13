namespace MyHouse
{
    public class Outside : Location
    {
        private bool hot;

        public Outside(string name, bool hot): base(name)
        {
            this.hot = hot;
        }

        public override string Description
        {
            get
            {
                var description = base.Description;
                if (hot)
                    description += " Otia que caló, primo.";
                
                return description;
            }
        }
    }
}