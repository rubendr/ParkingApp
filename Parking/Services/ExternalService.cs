namespace Parking.Services
{
    public class ExternalService
    {
        public bool ValidateGoogleCaptcha()
        {
            string response = "token";
            string secret = "key";
            Console.WriteLine(response + " " + secret);
            return true;
        }

    }
}
