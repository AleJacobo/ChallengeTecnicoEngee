using System.ComponentModel;
using System.Reflection;

namespace ChallengeTecnicoEngee.Crosscutting.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            return value.GetAttribute<DescriptionAttribute>()?.Description ?? value.ToString();
        }

        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            Type type = value.GetType();
            MemberInfo[] member = type.GetMember(value.ToString());
            object[] customAttributes = member[0].GetCustomAttributes(typeof(T), inherit: false);
            return (customAttributes.Length != 0) ? ((T)customAttributes[0]) : null;
        }
    }
}
