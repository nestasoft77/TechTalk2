namespace RAMSerices.Entites
{
    public record Systeme
    {
        public int Id { get; init; }

        public string Nom { get; init; }

        public string CAO { get; set; }

        public List<string> Developpeurs { get; set; }

        public DateTimeOffset DateAjout{ get; init; }
        
    }
}
