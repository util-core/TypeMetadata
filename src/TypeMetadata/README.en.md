# TypeMetadata

English | [简体中文](README.md)

A static metadata cache per generic type for .NET.

- Generic static classes cache one instance per `T`.
- Type information is resolved once in the static constructor; every access afterwards is a
  static field read.

## Usage

```csharp
using TypeMetadata;

// Type checks
TypeMeta<int>.IsInteger        // true
TypeMeta<int>.IsValueType      // true
TypeMeta<int?>.IsNullable      // true
TypeMeta<MyEnum>.IsEnum        // true, enums are also integers (integral underlying type)
TypeMeta<string>.IsEnum        // false

// Type info
TypeMeta<int?>.Type              // typeof(int?), the raw type
TypeMeta<int?>.UnderlyingType    // typeof(int), unwrapped underlying type
TypeMeta<MyEnum>.UnderlyingType  // typeof(MyEnum), itself when not nullable
```

## API

All members of `TypeMeta<T>` are static readonly fields:

| Member | Meaning |
|---|---|
| `Type` | Raw type `typeof(T)` |
| `UnderlyingType` | Unwrapped underlying type (`int?` → `int`) |
| `IsNullable` | Whether `T` is nullable |
| `IsValueType` | Whether the underlying type is a value type |
| `IsEnum` | Whether the underlying type is an enum (also true for nullable enums) |
| `IsInteger` | Whether the underlying type is an integer (8/16/32/64-bit, signed and unsigned) |

## Author

何镇汐

## License

MIT
