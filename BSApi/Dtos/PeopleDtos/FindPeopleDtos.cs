namespace Dtos.PeopleDtos
{
    public class FindPeopleDtos
    {
        public int PersonID { get; init; }
        public string FullName { get; init; }
        public string? Phone { get; init; }
        //public string? Email { get; init; }
        public string  Enabled { get; init; }

        public FindPeopleDtos()
        {
            PersonID = 0;
            FullName = string.Empty;
            Phone = string.Empty;
            //Email = string.Empty;
            Enabled = string.Empty;
        }
    }
}
