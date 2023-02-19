using System;
using Microsoft.EntityFrameworkCore;
namespace BucketList.Model
{
	public class BucketItemContext: DbContext
	{
		public BucketItemContext(DbContextOptions<BucketItemContext> options) : base(options)
		{
		}
		public DbSet<BucketItem> BucketItems { get; set; } = null!;
	}
}

