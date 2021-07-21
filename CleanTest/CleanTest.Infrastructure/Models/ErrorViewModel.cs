using System;

namespace CleanTest.Infrastructure.Models
{
    //TODO: move this back to the .Web project (presentational layer)
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
