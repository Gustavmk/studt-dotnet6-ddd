using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Notifications
{
    public class Notify
    {
        public Notify()
        {
            Notifications = new List<Notify>();
            PropertyName = string.Empty;
            Message = string.Empty;
        }
        
        public string PropertyName { get; set; }
        
        public string Message { get; set; }

        public List<Notify> Notifications;

        public bool ValidatePropertyString(string Value, string PropertyName)
        {
            // This property is mandatory
            if (string.IsNullOrEmpty(Value) || string.IsNullOrEmpty(PropertyName))
            {
                Notifications.Add(new Notify
                {
                    Message = "Mandatory property",
                    PropertyName = PropertyName
                });
                
                return false;
            }

            return true;

        }
        
        public bool ValidateDecimalProperty(string Value, string PropertyName)
        {
            // This property is mandatory
            int number;
            bool success = int.TryParse(Value, out number);
            if (number < 1  || string.IsNullOrWhiteSpace(PropertyName))
            {
                Notifications.Add(new Notify
                {
                    Message = "Value must be greater than zero",
                    PropertyName = PropertyName
                });
                
                return false;
            }

            return true;

        }
    }
}