namespace NarouBackend;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


class AppDbContext : IdentityDbContext<IdentityUser> {
    public AppDbContext(DbContextOptions options) : base(options) {}
}
