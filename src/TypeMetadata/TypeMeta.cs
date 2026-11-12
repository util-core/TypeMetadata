using System;

namespace TypeMetadata;

/// <summary>
/// 类型元数据
/// </summary>
public static class TypeMeta<T> {
    /// <summary>
    /// 原始类型
    /// </summary>
    public static readonly Type Type;
    /// <summary>
    /// 基础类型
    /// </summary>
    public static readonly Type UnderlyingType;
    /// <summary>
    /// 是否可空类型
    /// </summary>
    public static readonly bool IsNullable;
    /// <summary>
    /// 是否值类型
    /// </summary>
    public static readonly bool IsValueType;
    /// <summary>
    /// 是否枚举类型
    /// </summary>
    public static readonly bool IsEnum;
    /// <summary>
    /// 是否整数类型
    /// </summary>
    public static readonly bool IsInteger;

    /// <summary>
    /// 初始化类型元数据
    /// </summary>
    static TypeMeta() {
        Type = typeof( T );
        Type underlying = Nullable.GetUnderlyingType( Type );
        UnderlyingType = underlying ?? Type;
        IsNullable = underlying != null;
        IsValueType = UnderlyingType.IsValueType;
        IsEnum = UnderlyingType.IsEnum;
        IsInteger = IsIntegerType( UnderlyingType );
    }

    /// <summary>
    /// 是否整数类型
    /// </summary>
    private static bool IsIntegerType( Type type ) {
        switch ( Type.GetTypeCode( type ) ) {
            case TypeCode.Byte:
            case TypeCode.Int16:
            case TypeCode.Int32:
            case TypeCode.Int64:
            case TypeCode.SByte:
            case TypeCode.UInt16:
            case TypeCode.UInt32:
            case TypeCode.UInt64:
                return true;
        }
        return false;
    }
}
