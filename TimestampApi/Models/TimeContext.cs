using Microsoft.EntityFrameworkCore;
using System;

namespace TimestampApi.Models
{
    public class TimeContext : DbContext
    {
        public TimeContext() { }
        public TimeContext(DbContextOptions<TimeContext> options) : base(options)
        {

        }
        public DateTime UserDate { get; set; }
        public Timestamp TimeStamp
        {
            get
            {
                if(!UserDate.Equals(DateTime.MinValue))
                {
                    return new Timestamp(UserDate);
                }
                return new Timestamp();
            }
        }        
    }
}
