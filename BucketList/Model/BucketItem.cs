using System;
using Microsoft.EntityFrameworkCore;
namespace BucketList.Model
{
    [PrimaryKey(nameof(bucketId))]
    public class BucketItem : DbContext
	{
		public long bucketId { get; set; }
		public long userId { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
		public DateOnly? targetDate { get; set; }
        public BucketItem()
		{
		}
	}
}

