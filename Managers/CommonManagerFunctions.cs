namespace PhoneBook_webAPI.Managers
{
    public abstract class CommonManagerFunctions(string source)
    {
        protected string _source = source;
        protected void CreateFileIfNotExists()
        {
            if (!File.Exists(_source))
            {
                using (File.Create(_source)) { }
            }
        }
    }
}
