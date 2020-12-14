using System.Collections.Generic;

namespace Linx.WebApp.MVC.ViewModels
{
    public class ResponseResult
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public List<string> Errors { get; set; }
    }
}
