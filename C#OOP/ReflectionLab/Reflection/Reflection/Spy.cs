using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate,  params string[] fieldsToInvestigate)
        {
            StringBuilder sb = new StringBuilder();

            Type classType = Type.GetType(classToInvestigate);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic
                | BindingFlags.Public);

            Object classInstance = Activator.CreateInstance(classType, new Object[] { });
            sb.AppendLine($"Class under investigation: {classToInvestigate}");

            foreach (var classField in classFields)
            {
                sb.AppendLine($"{classField.Name} = {classField.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }
    }
}
