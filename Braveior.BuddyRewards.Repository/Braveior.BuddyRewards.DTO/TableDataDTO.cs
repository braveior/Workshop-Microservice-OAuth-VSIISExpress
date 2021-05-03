using System;
using System.Collections;
using System.Collections.Generic;

namespace Braveior.BuddyRewards.DTO
{
    public class TableDataDTO<T>
    {
        public List<T> PagedMemberData { get; set; }

        public long TotalCount { get; set; }

        
    }

}
