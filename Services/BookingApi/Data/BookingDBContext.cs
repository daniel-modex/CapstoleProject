using BookingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingApi.Data
{
    public class BookingDBContext : DbContext
    {
        public BookingDBContext(DbContextOptions<BookingDBContext> options) : base(options)
        {
        }

        public DbSet<BookingDetails> BookingDetails { get; set; }
        public DbSet<BookingResponse> BookingResponse { get; set; }
    }
}
