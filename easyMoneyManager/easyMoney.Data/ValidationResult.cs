using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace easyMoney.Data
{
    public class ValidationResult
    {
        public ValidationResult()
        {
            Success = true;
            PreventAction = false;
            Message = String.Empty;
        }

        public ValidationResult(bool success, bool preventAction, List<String> messages)
        {
            Success = success;
            PreventAction = preventAction;
            Message = String.Join(Environment.NewLine, messages);
        }

        public ValidationResult(bool success, bool preventAction, String message)
        {
            Success = success;
            PreventAction = preventAction;
            Message = message;
        }

        public bool Success { get; set; }
        public bool PreventAction { get; set; }
        public String Message { get; set; }
    }
}
