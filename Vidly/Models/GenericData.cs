using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class GenericData
    {
        public enum MessageTypes
        {
            Primary,
            Secondary,
            Danger,
            Warning,
            Info,
            Success,
            Light,
            Dark
        }

        public static Dictionary<int, string> ExceptionString = new Dictionary<int, string>()
        {
            {2601, "Violation in unique index"},
            {2627, "Violation in unique constraint"}
        };

        public static string MessageTypeClass(MessageTypes messageType)
        {
            var messageClass = "alert-";
            switch (messageType)
            {
                case GenericData.MessageTypes.Danger:
                    messageClass += "danger";
                    break;
                case GenericData.MessageTypes.Info:
                    messageClass += "info";
                    break;
                case GenericData.MessageTypes.Dark:
                    messageClass += "dark";
                    break;
                case GenericData.MessageTypes.Light:
                    messageClass += "light";
                    break;
                case GenericData.MessageTypes.Primary:
                    messageClass += "primary";
                    break;
                case GenericData.MessageTypes.Secondary:
                    messageClass += "secondary";
                    break;
                case GenericData.MessageTypes.Warning:
                    messageClass += "warning";
                    break;
                default:
                    messageClass += "success";
                    break;
            }

            return messageClass;
        }
    }
}