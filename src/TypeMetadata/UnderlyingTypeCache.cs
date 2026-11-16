using System;
using System.Collections.Concurrent;

namespace TypeMetadata;

/// <summary>
/// 基础类型缓存
/// </summary>
public static class UnderlyingTypeCache {
    /// <summary>
    /// 缓存字典
    /// </summary>
    private static readonly ConcurrentDictionary<Type, Type> _cache = new();

    /// <summary>
    /// 获取基础类型
    /// </summary>
    /// <param name="type">类型</param>
    public static Type Get( Type type ) {
        if ( type == null )
            return null;
        if ( type.IsValueType == false || type.IsGenericType == false || type.GetGenericTypeDefinition() != typeof( Nullable<> ) )
            return type;
        if ( _cache.TryGetValue( type, out var result ) )
            return result;
        Type underlying = type.GetGenericArguments()[0];
        return _cache.GetOrAdd( type, underlying );
    }

    /// <summary>
    /// 清空缓存
    /// </summary>
    public static void Clear() {
        _cache.Clear();
    }
}
