using AutoMapper;
using System;

namespace Application.AutoMapperDomainProfiles.Converters
{
    public class EnumToStringConverter<T> : ITypeConverter<T, string> where T : struct, IConvertible
    {
        public string Convert(T source, string destination, ResolutionContext context)
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }
            
            return Enum.GetName((source.GetType()), source);
        }
    }
}
