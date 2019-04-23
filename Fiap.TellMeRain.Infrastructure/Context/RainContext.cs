using Microsoft.EntityFrameworkCore;

namespace Fiap.TellMeRain.Infrastructure.Context
{
    public class RainContext : DbContext
    {

        public RainContext(DbContextOptions<RainContext> options): base(options)
        {
            
        }
    }
}
