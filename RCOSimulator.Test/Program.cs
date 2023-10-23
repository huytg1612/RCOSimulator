using RCOSimulator.Data.Models;

using (var ctx = new RCODbContext())
{
    var data = ctx.Set<User>().AsQueryable();
    data = data.Skip(2).Take(1);
}