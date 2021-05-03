using System.Collections.Generic;

namespace Braveior.BuddyRewards.web.Client.DTO
{
    public class TableDataDTO<T>
    {
        public List<T> PagedMemberData { get; set; }

        public long TotalCount { get; set; }

        
    }

}
