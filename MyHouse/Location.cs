namespace MyHouse
{
    public abstract class Location
    {
        protected Location(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public Location[] Exits;

        public virtual string Description
        {
            get
            {
                var description = $"Estás en el/la {Name}. Ves salidas hacia los siguientes sitios:";
                for (int i = 0; i < Exits.Length; i++)
                {
                    description += $" {Exits[i].Name}";
                    if (i != Exits.Length - 1)
                        description += ",";
                   
                }
                description += ".";
                return description;
            }
        }
    }
}