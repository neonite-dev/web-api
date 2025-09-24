using Microsoft.EntityFrameworkCore;

namespace workspace.Models;

public class CCDBContext : DbContext
{
    public CCDBContext(DbContextOptions<CCDBContext> options) : base(options)
    { }

    public DbSet<CCUserModel> TEMP_TEST_CCUserList { get; set; }
    public DbSet<CCBoardModel> TEMP_TEST_CCBoardList { get; set; }
}