# Ave.Extensions.FluentContracts

A fluent contract library for .NET with dual API: `Must()` for tests (throws on failure) and `Should()` for validation (returns `Result<T, Error>`).


## Why Must() and Should()?

The naming follows **RFC 2119** (IETF standard for requirement levels in specifications):

| Keyword | RFC 2119 Meaning | This Library |
|---------|-----------------|--------------|
| **MUST** | "the definition is an absolute requirement" | Throws on violation |
| **SHOULD** | "there may exist valid reasons in particular circumstances to ignore" | Returns Result, caller decides |

Note: FluentAssertions uses `.Should()` for throwing assertions, which is semantically inverted per RFC 2119. This library aligns with the original RFC 2119 semantics.

## Packages

| Package | Purpose | Use In |
|---------|---------|--------|
| `Ave.Extensions.FluentContracts` | Core conditions and contract engine | Both |
| `Ave.Extensions.FluentContracts.ForValidation` | `Should()` entry points | Production code |
| `Ave.Extensions.FluentContracts.ForTesting` | `Must()` entry points | Test projects |

## Acknowledgements

This library is inspired by [FluentAssertions](https://github.com/fluentassertions/fluentassertions), the excellent and widely-used assertion library for .NET. The fluent API design, method naming conventions, and many assertion patterns are derived from FluentAssertions.

## Installation

```bash
# For production validation code
dotnet add package Ave.Extensions.FluentContracts.ForValidation

# For test projects
dotnet add package Ave.Extensions.FluentContracts.ForTesting
```

## Two APIs: Must() vs Should()

### Must() - For Tests (Throws on Failure)

Use `Must()` in your tests. It auto-detects your test framework (xUnit, NUnit, MSTest, TUnit) and throws the appropriate assertion exception on failure.

```csharp
using Ave.Extensions.FluentContracts.ForTesting;

[Fact]
public void Name_should_start_with_capital()
{
    string name = GetName();

    name.Must()
        .NotBeNullOrEmpty()
        .And.StartWith("A");
    // Throws XunitException / NUnit.AssertionException / MSTestAssertFailedException
    // Auto-detected, no configuration needed
}
```

### Should() - For Validation (Returns Result)

Use `Should()` in production code for validation. Returns `Result<T, Error>` instead of throwing.

```csharp
using Ave.Extensions.FluentContracts.ForValidation;
using Ave.Extensions.Functional;

Result<string?, Error> result = input.Should()
    .NotBeNullOrEmpty()
    .And.Contain("@");

if (result.IsFailure)
{
    Console.WriteLine(result.Error.Message);
    Console.WriteLine(result.Error.Code); // e.g., "Contract/String/Contain"
}
```

## Basic Usage Examples

### In Tests with Must()

```csharp
using Ave.Extensions.FluentContracts.ForTesting;

// String contracts
"hello world".Must()
    .NotBeNullOrEmpty()
    .And.StartWith("hello")
    .And.Contain("world");

// Numeric contracts
42.Must()
    .BePositive()
    .And.BeGreaterThan(0)
    .And.BeLessThan(100);

// Collection contracts
new[] { 1, 2, 3 }.Must()
    .HaveCount(3)
    .And.Contain(2);

// Boolean contracts
true.Must().BeTrue();

// Object contracts
myObject.Must()
    .NotBeNull()
    .And.BeOfType<MyClass>();
```

### In Production with Should()

```csharp
using Ave.Extensions.FluentContracts.ForValidation;

public Result<User, Error> ValidateUser(User user)
{
    Result<string?, Error> nameResult = user.Name.Should()
        .NotBeNullOrEmpty()
        .And.HaveLengthGreaterThan(2);

    if (nameResult.IsFailure)
        return Result<User, Error>.Failure(nameResult.Error);

    Result<int, Error> ageResult = user.Age.Should()
        .BeGreaterThanOrEqualTo(0)
        .And.BeLessThan(150);

    if (ageResult.IsFailure)
        return Result<User, Error>.Failure(ageResult.Error);

    return Result<User, Error>.Success(user);
}
```

## Available Contract Types

### Primitive Types
- **BooleanContracts** - `BeTrue()`, `BeFalse()`, `Be()`, `NotBe()`, `Imply()`
- **NumericContracts** - `Be()`, `NotBe()`, `BePositive()`, `BeNegative()`, `BeGreaterThan()`, `BeLessThan()`, `BeInRange()`, `BeOneOf()`
- **StringContracts** - `Be()`, `NotBe()`, `BeEmpty()`, `NotBeEmpty()`, `Contain()`, `StartWith()`, `EndWith()`, `MatchRegex()`, `HaveLength()`
- **GuidContracts** - `Be()`, `NotBe()`, `BeEmpty()`, `NotBeEmpty()`

### Nullable Types
- **NullableBooleanContracts** - `HaveValue()`, `NotHaveValue()`, `BeNull()`, `NotBeNull()`, plus all boolean contracts
- **NullableNumericContracts** - `HaveValue()`, `NotHaveValue()`, plus all numeric contracts

### Date and Time
- **DateTimeContracts** - `Be()`, `NotBe()`, `BeBefore()`, `BeAfter()`, `BeOnOrBefore()`, `BeOnOrAfter()`, `BeCloseTo()`, `HaveYear()`, `HaveMonth()`, `HaveDay()`
- **DateTimeOffsetContracts** - Same as DateTime plus `HaveOffset()`, `BeSameDateAs()`
- **TimeSpanContracts** - `Be()`, `NotBe()`, `BePositive()`, `BeNegative()`, `BeGreaterThan()`, `BeLessThan()`, `BeCloseTo()`

### Collections
- **CollectionContracts** - `BeEmpty()`, `NotBeEmpty()`, `HaveCount()`, `Contain()`, `NotContain()`, `ContainSingle()`, `OnlyContain()`, `BeSubsetOf()`, `BeInAscendingOrder()`, `BeInDescendingOrder()`
- **StringCollectionContracts** - All collection contracts plus `ContainMatch()`, `AllMatch()`, `ContainEquivalentOf()`, `NotContainNullOrEmpty()`
- **DictionaryContracts** - `BeEmpty()`, `NotBeEmpty()`, `HaveCount()`, `ContainKey()`, `ContainValue()`, `ContainKeyValuePair()`, `ContainKeys()`

### Other Types
- **ObjectContracts** - `Be()`, `NotBe()`, `BeNull()`, `NotBeNull()`, `BeSameAs()`, `NotBeSameAs()`, `BeOfType()`, `BeAssignableTo()`
- **TypeContracts** - `Be()`, `NotBe()`, `BeAssignableTo()`, `NotBeAssignableTo()`, `Implement()`, `HaveAttribute()`
- **EnumContracts** - `Be()`, `NotBe()`, `HaveFlag()`, `NotHaveFlag()`, `BeDefined()`, `BeNull()`, `NotBeNull()`
- **ComparableContracts** - `Be()`, `NotBe()`, `BeGreaterThan()`, `BeLessThan()`, `BeInRange()`, `BeOneOf()`, `BeRankedEquallyTo()`

### Exceptions and Functions
- **ActionContracts** - `Throw<T>()`, `ThrowExactly<T>()`, `NotThrow()`, `NotThrow<T>()`
- **ExceptionContracts** - `WithMessage()`, `WithInnerException<T>()`, `Where()`
- **FunctionContracts** - `Return()`, `NotReturn()`, `ReturnNotNull()`, `ReturnNull()`, `Satisfy()`, `Throw<T>()`, `NotThrow()`

### XML
- **XDocumentContracts** - `HaveRoot()`, `HaveElement()`
- **XElementContracts** - `HaveAttribute()`, `HaveValue()`, `HaveElement()`
- **XAttributeContracts** - `HaveValue()`

## Chaining Contracts

Both `Must()` and `Should()` support fluent chaining with the `And` property:

```csharp
// With Must() - throws on first failure
"hello world".Must()
    .NotBeNullOrEmpty()
    .And.StartWith("hello")
    .And.EndWith("world")
    .And.Contain(" ");

// With Should() - returns Result with first failure
Result<string?, Error> result = "hello world".Should()
    .NotBeNullOrEmpty()
    .And.StartWith("hello")
    .And.EndWith("world");
```

## Error Codes

Each contract failure produces a structured error code following the pattern `Contract/{Type}/{Method}`:

```csharp
var result = "hello".Should().StartWith("world");
// result.Error.Code == "Contract/String/StartWith"
```

## Exception Testing

```csharp
// Test that an action throws (with Must)
Action action = () => throw new ArgumentNullException("param");
action.Must().Throw<ArgumentNullException>();

// Test that an action throws (with Should)
Result<ArgumentNullException?, Error> result = action.Should()
    .Throw<ArgumentNullException>()
    .WithMessage("*param*");

// Test that code doesn't throw
Action safeAction = () => Console.WriteLine("safe");
safeAction.Must().NotThrow();
```

## Test Framework Auto-Detection

`Must()` automatically detects your test framework at runtime and throws the appropriate exception type:

| Test Framework | Exception Type |
|---|---|
| xUnit | `Xunit.Sdk.XunitException` |
| NUnit | `NUnit.Framework.AssertionException` |
| MSTest | `Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException` |
| TUnit | `TUnit.Assertions.Exceptions.AssertionException` |
| None | `ContractViolationException` (fallback) |

No configuration or adapter packages needed. Detection runs once on first failure and caches the result.

## Integration with Functional Extensions

Since `Should()` returns `Result<T, Error>`, it integrates seamlessly with `Ave.Extensions.Functional`:

### Chaining with OnSuccessBind

```csharp
using Ave.Extensions.FluentContracts.ForValidation;
using Ave.Extensions.Functional;

// Chain validations - each step only runs if previous succeeded
Result<int, Error> result = "42".Should()
    .NotBeNullOrEmpty()
    .OnSuccessBind(s => s.Should().MatchRegex(@"^\d+$"))
    .OnSuccessBind(s => int.Parse(s).Should().BePositive());
// result.Value == 42

// Validate related fields
Result<Order, Error> ValidateOrder(Order order)
{
    return order.CustomerId.Should()
        .NotBeNullOrEmpty()
        .OnSuccessBind(_ => order.Total.Should().BeGreaterThan(0))
        .OnSuccessBind(_ => order.Items.Should().NotBeEmpty())
        .OnSuccessMap(_ => order);
}
```

### Transforming with OnSuccessMap

```csharp
// Transform validated values
Result<int, Error> result = "42".Should()
    .NotBeNullOrEmpty()
    .OnSuccessMap(int.Parse)
    .OnSuccessBind(n => n.Should().BePositive())
    .OnSuccessMap(n => n * 2);
// result.Value == 84
```

### Validation Pipelines

```csharp
public Result<User, Error> ValidateAndCreateUser(string name, string email, int age)
{
    return name.Should()
        .NotBeNullOrEmpty()
        .And.HaveLengthGreaterThan(2)
        .OnSuccessBind(_ => email.Should()
            .NotBeNullOrEmpty()
            .And.Contain("@"))
        .OnSuccessBind(_ => age.Should()
            .BeGreaterThanOrEqualTo(18)
            .And.BeLessThan(120))
        .OnSuccessMap(_ => new User(name, email, age));
}
```

### Error Handling with Match

```csharp
string message = input.Should()
    .NotBeNullOrEmpty()
    .And.StartWith("https://")
    .Match(
        onSuccess: url => $"Valid URL: {url}",
        onError: error => $"Invalid: {error.Message}");
```

### Collecting Multiple Errors

```csharp
public Result<Registration, Error[]> ValidateRegistration(Registration reg)
{
    var errors = new List<Error>();

    reg.Username.Should()
        .NotBeNullOrEmpty()
        .And.HaveLengthBetween(3, 20)
        .OnFailureDo(e => errors.Add(e));

    reg.Email.Should()
        .NotBeNullOrEmpty()
        .And.Contain("@")
        .OnFailureDo(e => errors.Add(e));

    reg.Age.Should()
        .BeGreaterThanOrEqualTo(18)
        .OnFailureDo(e => errors.Add(e));

    return errors.Count > 0
        ? Result<Registration, Error[]>.Failure(errors.ToArray())
        : Result<Registration, Error[]>.Success(reg);
}
```

## Extensibility

The library supports two extensibility patterns: adding custom contracts to existing types, and creating entirely new API entry points.

### Adding Custom Contracts

Extend the base classes to add contracts that work with both `Should()` and `Must()`:

```csharp
using Ave.Extensions.FluentContracts;
using Ave.Extensions.ErrorPaths;

namespace Acme.Contracts;

public static class UrlContractCodes
{
    public static readonly ErrorCode BeAbsoluteUri = ErrorCode.Parse("Contract/Url/BeAbsoluteUri");
    public static readonly ErrorCode UseHttps = ErrorCode.Parse("Contract/Url/UseHttps");
}

public static class UrlStringContracts
{
    public static TSelf BeAbsoluteUri<TSelf>(this StringContractsBase<TSelf> contracts)
        where TSelf : StringContractsBase<TSelf>
    {
        return contracts.Assert(
            s => Uri.TryCreate(s, UriKind.Absolute, out _),
            UrlContractCodes.BeAbsoluteUri,
            $"Expected absolute URI but found '{contracts.Subject ?? "(null)"}'");
    }

    public static TSelf UseHttps<TSelf>(this StringContractsBase<TSelf> contracts)
        where TSelf : StringContractsBase<TSelf>
    {
        return contracts.Assert(
            s => Uri.TryCreate(s, UriKind.Absolute, out var uri) &&
                 uri.Scheme == Uri.UriSchemeHttps,
            UrlContractCodes.UseHttps,
            $"Expected HTTPS URL but found '{contracts.Subject ?? "(null)"}'");
    }
}
```

```csharp
// Works with both APIs
callbackUrl.Must().BeAbsoluteUri().And.UseHttps();

Result<string?, Error> result = callbackUrl.Should().BeAbsoluteUri().And.UseHttps();
```

### Creating a Guard API

Create an `Ensure()` API for constructor guard clauses that throws `ArgumentException`:

```csharp
using Ave.Extensions.FluentContracts;

namespace Acme.Contracts;

public sealed class EnsureStringContracts : StringContractsBase<EnsureStringContracts>
{
    private readonly string _paramName;

    public EnsureStringContracts(string? subject, string paramName)
        : base(subject, throwOnFailure: false)
    {
        _paramName = paramName;
    }

    public string Value => HasFailure
        ? throw new ArgumentException($"Parameter validation failed for '{_paramName}'", _paramName)
        : Subject!;
}

public static class EnsureExtensions
{
    public static EnsureStringContracts Ensure(this string? subject, string paramName)
        => new EnsureStringContracts(subject, paramName);
}
```

```csharp
public class User
{
    public string Email { get; }
    public string Name { get; }

    public User(string email, string name)
    {
        Email = email.Ensure(nameof(email)).NotBeNullOrEmpty().And.Contain("@").Value;
        Name = name.Ensure(nameof(name)).NotBeNullOrEmpty().And.HaveLength(50).Value;
    }
}
```

### Domain-Specific Contracts: Money

```csharp
using Ave.Extensions.FluentContracts;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Acme.Contracts;

public readonly record struct Money(decimal Amount, string Currency);

public static class MoneyContractCodes
{
    public static readonly ErrorCode BePositive = ErrorCode.Parse("Contract/Money/BePositive");
    public static readonly ErrorCode NotExceed = ErrorCode.Parse("Contract/Money/NotExceed");
    public static readonly ErrorCode BeCurrency = ErrorCode.Parse("Contract/Money/BeCurrency");
}

public abstract class MoneyContractsBase<TSelf> : Contracts<Money, TSelf>
    where TSelf : MoneyContractsBase<TSelf>
{
    protected MoneyContractsBase(Money subject, bool throwOnFailure)
        : base(subject, throwOnFailure) { }

    public TSelf BePositive()
    {
        return Assert(
            m => m.Amount > 0,
            MoneyContractCodes.BePositive,
            $"Expected positive amount but found {Subject.Amount} {Subject.Currency}");
    }

    public TSelf NotExceed(decimal maxAmount)
    {
        return Assert(
            m => m.Amount <= maxAmount,
            MoneyContractCodes.NotExceed,
            $"Expected amount not exceeding {maxAmount} but found {Subject.Amount} {Subject.Currency}");
    }

    public TSelf BeCurrency(string expectedCurrency)
    {
        return Assert(
            m => m.Currency.Equals(expectedCurrency, StringComparison.OrdinalIgnoreCase),
            MoneyContractCodes.BeCurrency,
            $"Expected currency {expectedCurrency} but found {Subject.Currency}");
    }
}

public sealed class MoneyContracts : MoneyContractsBase<MoneyContracts>
{
    public MoneyContracts(Money subject) : base(subject, throwOnFailure: false) { }

    public static implicit operator Result<Money, Error>(MoneyContracts a) => a.ToResult();
}

public sealed class MustMoneyContracts : MoneyContractsBase<MustMoneyContracts>
{
    public MustMoneyContracts(Money subject) : base(subject, throwOnFailure: true) { }
}

public static class MoneyContractExtensions
{
    public static MoneyContracts Should(this Money subject) => new(subject);
    public static MustMoneyContracts Must(this Money subject) => new(subject);
}
```

```csharp
// In payment processing
public Result<Payment, Error> ProcessPayment(Money amount)
{
    return amount.Should()
        .BePositive()
        .And.BeCurrency("EUR")
        .And.NotExceed(10000m)
        .OnSuccessMap(_ => CreatePayment(amount));
}

// In tests
payment.Amount.Must().BePositive().And.BeCurrency("EUR");
```

### Domain-Specific Contracts: Date Ranges

```csharp
public readonly record struct DateRange(DateOnly Start, DateOnly End);

public static class DateRangeContractCodes
{
    public static readonly ErrorCode BeValid = ErrorCode.Parse("Contract/DateRange/BeValid");
    public static readonly ErrorCode NotExceedDays = ErrorCode.Parse("Contract/DateRange/NotExceedDays");
    public static readonly ErrorCode BeInFuture = ErrorCode.Parse("Contract/DateRange/BeInFuture");
}

public abstract class DateRangeContractsBase<TSelf> : Contracts<DateRange, TSelf>
    where TSelf : DateRangeContractsBase<TSelf>
{
    protected DateRangeContractsBase(DateRange subject, bool throwOnFailure)
        : base(subject, throwOnFailure) { }

    public TSelf BeValid()
    {
        return Assert(
            r => r.Start <= r.End,
            DateRangeContractCodes.BeValid,
            $"Expected valid date range but Start ({Subject.Start}) is after End ({Subject.End})");
    }

    public TSelf NotExceedDays(int maxDays)
    {
        return Assert(
            r => (r.End.ToDateTime(TimeOnly.MinValue) - r.Start.ToDateTime(TimeOnly.MinValue)).Days <= maxDays,
            DateRangeContractCodes.NotExceedDays,
            $"Expected range not exceeding {maxDays} days");
    }

    public TSelf StartInFuture()
    {
        return Assert(
            r => r.Start > DateOnly.FromDateTime(DateTime.Today),
            DateRangeContractCodes.BeInFuture,
            $"Expected start date in the future but found {Subject.Start}");
    }
}

public sealed class DateRangeContracts : DateRangeContractsBase<DateRangeContracts>
{
    public DateRangeContracts(DateRange subject) : base(subject, throwOnFailure: false) { }

    public static implicit operator Result<DateRange, Error>(DateRangeContracts a) => a.ToResult();
}

public sealed class MustDateRangeContracts : DateRangeContractsBase<MustDateRangeContracts>
{
    public MustDateRangeContracts(DateRange subject) : base(subject, throwOnFailure: true) { }
}

public static class DateRangeContractExtensions
{
    public static DateRangeContracts Should(this DateRange subject) => new(subject);
    public static MustDateRangeContracts Must(this DateRange subject) => new(subject);
}
```

```csharp
// Booking validation
public Result<Booking, Error> CreateBooking(DateRange period, Room room)
{
    return period.Should()
        .BeValid()
        .And.StartInFuture()
        .And.NotExceedDays(30)
        .OnSuccessBind(_ => room.Should().BeAvailable(period))
        .OnSuccessMap(_ => new Booking(period, room));
}
```

## License

MIT License
