using System;
using System.Collections.Generic;

namespace Labwork_3.MainFlow
{
    public class GetStringBaseType
    {
        public static TypeCode GetBaseType(string value)
        {
            foreach (object v in Enum.GetValues(typeof(TypeCode)))
            {
                TypeCode typeCode = (TypeCode)v;

                if (TryParse(value, (TypeCode)typeCode))
                {
                    return typeCode;
                }
            }

            return TypeCode.String;
        }

        public static TypeCode GetBaseType(string value, List<TypeCode> typeList)
        {
            foreach (var tc in typeList)
            {
                if (TryParse(value, tc))
                {
                    return tc;
                }
            }
            
            return TypeCode.String;
        }

        private static bool TryParse(string value, TypeCode baseType)
        {
            switch (baseType)
            {
                case TypeCode.Boolean:
                    return Boolean.TryParse(value,out _);

                case TypeCode.Byte:
                    return Byte.TryParse(value, out _);

                case TypeCode.Char:
                    return Char.TryParse(value, out _);

                case TypeCode.DateTime:
                    return DateTime.TryParse(value, out _);

                case TypeCode.Decimal:
                    return Decimal.TryParse(value, out _);

                case TypeCode.Double:
                    return Double.TryParse(value, out _);

                case TypeCode.Int16:
                    return Int16.TryParse(value, out _);

                case TypeCode.Int32:
                    return Int32.TryParse(value, out _);

                case TypeCode.Int64:
                    return Int64.TryParse(value, out _);

                case TypeCode.SByte:
                    return SByte.TryParse(value, out _);

                case TypeCode.Single:
                    return Single.TryParse(value, out _);

                case TypeCode.UInt16:
                    return UInt16.TryParse(value, out _);

                case TypeCode.UInt32:
                    return UInt32.TryParse(value, out _);

                case TypeCode.UInt64:
                    return UInt64.TryParse(value, out _);

                case TypeCode.DBNull:
                    return value == DBNull.Value.ToString();

                case TypeCode.Empty:
                    return value == String.Empty || value == null;
                default:
                    return false;
            }
        }
    }
}