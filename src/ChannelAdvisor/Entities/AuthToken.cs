
using System;

namespace Aarvani.ChannelAdvisor.Entities
{
    public class AuthToken
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public DateTime Created { get; set; }

        public AuthToken()
        {
            Created = DateTime.Now;
        }
        
        public bool IsExpireded()
        {
            if (expires_in <= 0)
                return false;

            TimeSpan difference = DateTime.Now.Subtract(Created);

            return difference.Seconds < expires_in;
        }

    }
}
