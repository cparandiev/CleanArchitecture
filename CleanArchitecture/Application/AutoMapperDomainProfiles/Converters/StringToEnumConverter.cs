using AutoMapper;
using System;

namespace Application.AutoMapperDomainProfiles.Converters
{
    public class StringToEnumConverter<T> : ITypeConverter<string, T> where T : struct, IConvertible
    {
        public T Convert(string source, T destination, ResolutionContext context)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            
            return (T)Enum.Parse(typeof(T), source);
        }
    }
}
