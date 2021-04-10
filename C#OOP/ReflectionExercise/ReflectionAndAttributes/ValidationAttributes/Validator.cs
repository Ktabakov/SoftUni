using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] props = obj.GetType().GetProperties();

            foreach (var item in props)
            {
                var attrubutes = item.GetCustomAttributes().Cast<MyValidationAttribute>().ToArray();

                var value = item.GetValue(obj);

                foreach (var attr in attrubutes)
                {
                    if (!attr.IsValid(value))
                    {
                        return false; 
                    }
                }
            }
            
            return true;
        }
    }
}
