using System;

namespace Braveior.BuddyRewards.DTO
{
    public class TableStateDTO
    {
        public string SortColumn { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public string SearchKey { get; set; }

        public string SortDirection { get; set; }

        public string FilterID { get; set; }
    }
}
