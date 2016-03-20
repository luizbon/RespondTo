using System.Collections.Generic;
using Newtonsoft.Json.Serialization;

namespace Demo.Models
{
    public class RespondToViewModel
    {
        public IList<string> Items { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int HasNextPage { get; set; }
        public int HasPrevPage { get; set; }
        public int TotalPages { get; set; }
    }
}