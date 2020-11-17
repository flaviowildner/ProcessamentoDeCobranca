using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CobrancaAPI.Util
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AtLeastOneAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Type type = value.GetType();

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(value, null) != null)
                {
                    return true;
                }
            }

            return false;
        }
    }
}