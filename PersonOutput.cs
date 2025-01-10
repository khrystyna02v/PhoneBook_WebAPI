namespace PhoneBook_webAPI
{
    public static class PersonOutput
    {
        public static string CsvOutput(this Person person)
        {
            if (person.Email != null)
            {
                return $"{person.Name},{person.Surname},{person.PhoneNumber},{person.Email}\n";
            }
            else
            {
                return $"{person.Name},{person.Surname},{person.PhoneNumber},-\n";
            }
        }
    }
}

