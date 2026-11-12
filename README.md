# TypeMetadata

[English](https://github.com/util-core/TypeMetadata/blob/main/README.en.md) | 简体中文

每个泛型类型的静态元数据缓存。

- 泛型静态类按 `T` 缓存一份元数据。
- 类型 `T` 在静态构造函数中解析一次,之后每次访问都是静态字段读取。

## 安装

```bash
dotnet add package TypeMetadata --version 1.0.0
```

## 用法

```csharp
using TypeMetadata;

// 类型判断
TypeMeta<int>.IsInteger        // true
TypeMeta<int>.IsValueType      // true
TypeMeta<int?>.IsNullable      // true
TypeMeta<MyEnum>.IsEnum        // true,枚举同时是整数(基础类型为整数)
TypeMeta<string>.IsEnum        // false

// 类型信息
TypeMeta<int?>.Type              // typeof(int?),原始类型
TypeMeta<int?>.UnderlyingType    // typeof(int),可空解包后的基础类型
TypeMeta<MyEnum>.UnderlyingType  // typeof(MyEnum),非可空时为自身
```

## API

`TypeMeta<T>` 全部成员均为静态只读字段:

| 成员 | 含义 |
|---|---|
| `Type` | 原始类型 `typeof(T)` |
| `UnderlyingType` | 可空解包后的基础类型(`int?` → `int`) |
| `IsNullable` | 是否可空类型 |
| `IsValueType` | 是否值类型(按基础类型判断) |
| `IsEnum` | 是否枚举类型(按基础类型判断,可空枚举也为真) |
| `IsInteger` | 是否整数类型(8/16/32/64 位有符号与无符号整数) |

## 作者

何镇汐

## License

MIT
