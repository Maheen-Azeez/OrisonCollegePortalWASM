﻿
namespace OrisonCollegePortal.Shared.Entities.General
{
    public class ToastOption
    {
        public int Timeout { get; set; } = 0;
        public string? Title { get; set; }
        public string? Content { get; set; }
        public string? X { get; set; }
        public string? Y { get; set; }
        public bool CloseButton { get; set; }=false;
        public string? CssClass { get; set; }
        public string? Icon { get; set; }
    }
}
