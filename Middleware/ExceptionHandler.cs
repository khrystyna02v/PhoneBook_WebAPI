namespace PhoneBook_webAPI.Middleware
{
    public class ExceptionHandler(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var source = "exceptions.csv";
                using (var file = new StreamWriter(source, append: true, encoding: System.Text.Encoding.UTF8))
                {
                    file.WriteLine($"{DateTime.UtcNow:O},{exception.GetType().Name},{exception.Message},{exception.StackTrace}");
                }
                throw;
            }
        }
    }
}

