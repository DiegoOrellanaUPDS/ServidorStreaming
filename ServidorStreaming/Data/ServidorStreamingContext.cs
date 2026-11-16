using Microsoft.EntityFrameworkCore;
using ServidorStreaming.Models;

namespace ServidorStreaming.Data;

public class ServidorStreamingContext : DbContext
{
    public ServidorStreamingContext(
        DbContextOptions<ServidorStreamingContext> options)
        : base(options)
    {
    }

    public DbSet<Categoria> Categorias { get; set; }
}
