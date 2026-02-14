# Ave.Extensions.Assertions

A fluent assertion library for .NET with dual API: `Must()` for tests (throws on failure) and `Should()` for validation (returns `Result<T, Error>`).

## Acknowledgements

This library is inspired by [FluentAssertions](https://github.com/fluentassertions/fluentassertions), the excellent and widely-used assertion library for .NET. The fluent API design, method naming conventions, and many assertion patterns are derived from FluentAssertions.

## Installation

```bash
dotnet add package Ave.Extensions.Assertions
```

## Two APIs: Must() vs Should()

### Must() - For Tests (Throws on Failure)

Use `Must()` in your tests. It auto-detects your test framework (xUnit, NUnit, MSTest, TUnit) and throws the appropriate assertion exception on failure.

```csharp
using Ave.Extensions.Assertions.Strings;

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
using Ave.Extensions.Assertions.Strings;
using Ave.Extensions.Functional;

Result<string?, Error> result = input.Should()
    .NotBeNullOrEmpty()
    .And.Contain("@");

if (result.IsFailure)
{
    Console.WriteLine(result.Error.Message);
    Console.WriteLine(result.Error.Code); // e.g., "Assertion/String/Contain"
}
```

## Basic Usage Examples

### In Tests with Must()

```csharp
// String assertions
"hello world".Must()
    .NotBeNullOrEmpty()
    .And.StartWith("hello")
    .And.Contain("world");

// Numeric assertions
42.Must()
    .BePositive()
    .And.BeGreaterThan(0)
    .And.BeLessThan(100);

// Collection assertions
new[] { 1, 2, 3 }.Must()
    .HaveCount(3)
    .And.Contain(2);

// Boolean assertions
true.Must().BeTrue();

// Object assertions
myObject.Must()
    .NotBeNull()
    .And.BeOfType<MyClass>();
```

### In Production with Should()

```csharp
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

## Available Assertion Types

### Primitive Types
- **BooleanAssertions** - `BeTrue()`, `BeFalse()`, `Be()`, `NotBe()`, `Imply()`
- **NumericAssertions** - `Be()`, `NotBe()`, `BePositive()`, `BeNegative()`, `BeGreaterThan()`, `BeLessThan()`, `BeInRange()`, `BeOneOf()`
- **StringAssertions** - `Be()`, `NotBe()`, `BeEmpty()`, `NotBeEmpty()`, `Contain()`, `StartWith()`, `EndWith()`, `MatchRegex()`, `HaveLength()`
- **GuidAssertions** - `Be()`, `NotBe()`, `BeEmpty()`, `NotBeEmpty()`

### Nullable Types
- **NullableBooleanAssertions** - `HaveValue()`, `NotHaveValue()`, `BeNull()`, `NotBeNull()`, plus all boolean assertions
- **NullableNumericAssertions** - `HaveValue()`, `NotHaveValue()`, plus all numeric assertions

### Date and Time
- **DateTimeAssertions** - `Be()`, `NotBe()`, `BeBefore()`, `BeAfter()`, `BeOnOrBefore()`, `BeOnOrAfter()`, `BeCloseTo()`, `HaveYear()`, `HaveMonth()`, `HaveDay()`
- **DateTimeOffsetAssertions** - Same as DateTime plus `HaveOffset()`, `BeSameDateAs()`
- **TimeSpanAssertions** - `Be()`, `NotBe()`, `BePositive()`, `BeNegative()`, `BeGreaterThan()`, `BeLessThan()`, `BeCloseTo()`

### Collections
- **CollectionAssertions** - `BeEmpty()`, `NotBeEmpty()`, `HaveCount()`, `Contain()`, `NotContain()`, `ContainSingle()`, `OnlyContain()`, `BeSubsetOf()`, `BeInAscendingOrder()`, `BeInDescendingOrder()`
- **StringCollectionAssertions** - All collection assertions plus `ContainMatch()`, `AllMatch()`, `ContainEquivalentOf()`, `NotContainNullOrEmpty()`
- **DictionaryAssertions** - `BeEmpty()`, `NotBeEmpty()`, `HaveCount()`, `ContainKey()`, `ContainValue()`, `ContainKeyValuePair()`, `ContainKeys()`

### Other Types
- **ObjectAssertions** - `Be()`, `NotBe()`, `BeNull()`, `NotBeNull()`, `BeSameAs()`, `NotBeSameAs()`, `BeOfType()`, `BeAssignableTo()`
- **TypeAssertions** - `Be()`, `NotBe()`, `BeAssignableTo()`, `NotBeAssignableTo()`, `Implement()`, `HaveAttribute()`
- **EnumAssertions** - `Be()`, `NotBe()`, `HaveFlag()`, `NotHaveFlag()`, `BeDefined()`, `BeNull()`, `NotBeNull()`
- **ComparableAssertions** - `Be()`, `NotBe()`, `BeGreaterThan()`, `BeLessThan()`, `BeInRange()`, `BeOneOf()`, `BeRankedEquallyTo()`

### Exceptions and Functions
- **ActionAssertions** - `Throw<T>()`, `ThrowExactly<T>()`, `NotThrow()`, `NotThrow<T>()`
- **ExceptionAssertions** - `WithMessage()`, `WithInnerException<T>()`, `Where()`
- **FunctionAssertions** - `Return()`, `NotReturn()`, `ReturnNotNull()`, `ReturnNull()`, `Satisfy()`, `Throw<T>()`, `NotThrow()`

### XML
- **XDocumentAssertions** - `HaveRoot()`, `HaveElement()`
- **XElementAssertions** - `HaveAttribute()`, `HaveValue()`, `HaveElement()`
- **XAttributeAssertions** - `HaveValue()`

## Chaining Assertions

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

Each assertion failure produces a structured error code following the pattern `Assertion/{Type}/{Method}`:

```csharp
var result = "hello".Should().StartWith("world");
// result.Error.Code == "Assertion/String/StartWith"
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
| None | `AssertionFailedException` (fallback) |

No configuration or adapter packages needed. Detection runs once on first failure and caches the result.

## Integration with Functional Extensions

Since `Should()` returns `Result<T, Error>`, it integrates seamlessly with `Ave.Extensions.Functional`:

### Chaining with OnSuccessBind

```csharp
using Ave.Extensions.Assertions.Strings;
using Ave.Extensions.Assertions.Numeric;
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

The library supports two extensibility patterns: adding custom assertions to existing types, and creating entirely new API entry points.

### Adding Custom Assertions

Extend the base classes to add assertions that work with both `Should()` and `Must()`:

```csharp
using Ave.Extensions.Assertions.Strings;
using Ave.Extensions.ErrorPaths;

namespace Acme.Assertions;

public static class UrlAssertionCodes
{
    public static readonly ErrorCode BeAbsoluteUri = ErrorCode.Parse("Assertion/Url/BeAbsoluteUri");
    public static readonly ErrorCode UseHttps = ErrorCode.Parse("Assertion/Url/UseHttps");
}

public static class UrlStringAssertions
{
    public static TSelf BeAbsoluteUri<TSelf>(this StringAssertionsBase<TSelf> assertions)
        where TSelf : StringAssertionsBase<TSelf>
    {
        return assertions.Assert(
            s => Uri.TryCreate(s, UriKind.Absolute, out _),
            UrlAssertionCodes.BeAbsoluteUri,
            $"Expected absolute URI but found '{assertions.Subject ?? "(null)"}'");
    }

    public static TSelf UseHttps<TSelf>(this StringAssertionsBase<TSelf> assertions)
        where TSelf : StringAssertionsBase<TSelf>
    {
        return assertions.Assert(
            s => Uri.TryCreate(s, UriKind.Absolute, out var uri) &&
                 uri.Scheme == Uri.UriSchemeHttps,
            UrlAssertionCodes.UseHttps,
            $"Expected HTTPS URL but found '{assertions.Subject ?? "(null)"}'");
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
using Ave.Extensions.Assertions.Strings;

namespace Acme.Assertions;

public sealed class EnsureStringAssertions : StringAssertionsBase<EnsureStringAssertions>
{
    private readonly string _paramName;

    public EnsureStringAssertions(string? subject, string paramName)
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
    public static EnsureStringAssertions Ensure(this string? subject, string paramName)
        => new EnsureStringAssertions(subject, paramName);
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

### Domain-Specific Assertions: Money

```csharp
using Ave.Extensions.Assertions;
using Ave.Extensions.ErrorPaths;
using Ave.Extensions.Functional;

namespace Acme.Assertions;

public readonly record struct Money(decimal Amount, string Currency);

public static class MoneyAssertionCodes
{
    public static readonly ErrorCode BePositive = ErrorCode.Parse("Assertion/Money/BePositive");
    public static readonly ErrorCode NotExceed = ErrorCode.Parse("Assertion/Money/NotExceed");
    public static readonly ErrorCode BeCurrency = ErrorCode.Parse("Assertion/Money/BeCurrency");
}

public abstract class MoneyAssertionsBase<TSelf> : Assertions<Money, TSelf>
    where TSelf : MoneyAssertionsBase<TSelf>
{
    protected MoneyAssertionsBase(Money subject, bool throwOnFailure)
        : base(subject, throwOnFailure) { }

    public TSelf BePositive()
    {
        return Assert(
            m => m.Amount > 0,
            MoneyAssertionCodes.BePositive,
            $"Expected positive amount but found {Subject.Amount} {Subject.Currency}");
    }

    public TSelf NotExceed(decimal maxAmount)
    {
        return Assert(
            m => m.Amount <= maxAmount,
            MoneyAssertionCodes.NotExceed,
            $"Expected amount not exceeding {maxAmount} but found {Subject.Amount} {Subject.Currency}");
    }

    public TSelf BeCurrency(string expectedCurrency)
    {
        return Assert(
            m => m.Currency.Equals(expectedCurrency, StringComparison.OrdinalIgnoreCase),
            MoneyAssertionCodes.BeCurrency,
            $"Expected currency {expectedCurrency} but found {Subject.Currency}");
    }
}

public sealed class MoneyAssertions : MoneyAssertionsBase<MoneyAssertions>
{
    public MoneyAssertions(Money subject) : base(subject, throwOnFailure: false) { }

    public static implicit operator Result<Money, Error>(MoneyAssertions a) => a.ToResult();
}

public sealed class MustMoneyAssertions : MoneyAssertionsBase<MustMoneyAssertions>
{
    public MustMoneyAssertions(Money subject) : base(subject, throwOnFailure: true) { }
}

public static class MoneyAssertionExtensions
{
    public static MoneyAssertions Should(this Money subject) => new(subject);
    public static MustMoneyAssertions Must(this Money subject) => new(subject);
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

### Domain-Specific Assertions: Date Ranges

```csharp
public readonly record struct DateRange(DateOnly Start, DateOnly End);

public static class DateRangeAssertionCodes
{
    public static readonly ErrorCode BeValid = ErrorCode.Parse("Assertion/DateRange/BeValid");
    public static readonly ErrorCode NotExceedDays = ErrorCode.Parse("Assertion/DateRange/NotExceedDays");
    public static readonly ErrorCode BeInFuture = ErrorCode.Parse("Assertion/DateRange/BeInFuture");
}

public abstract class DateRangeAssertionsBase<TSelf> : Assertions<DateRange, TSelf>
    where TSelf : DateRangeAssertionsBase<TSelf>
{
    protected DateRangeAssertionsBase(DateRange subject, bool throwOnFailure)
        : base(subject, throwOnFailure) { }

    public TSelf BeValid()
    {
        return Assert(
            r => r.Start <= r.End,
            DateRangeAssertionCodes.BeValid,
            $"Expected valid date range but Start ({Subject.Start}) is after End ({Subject.End})");
    }

    public TSelf NotExceedDays(int maxDays)
    {
        return Assert(
            r => (r.End.ToDateTime(TimeOnly.MinValue) - r.Start.ToDateTime(TimeOnly.MinValue)).Days <= maxDays,
            DateRangeAssertionCodes.NotExceedDays,
            $"Expected range not exceeding {maxDays} days");
    }

    public TSelf StartInFuture()
    {
        return Assert(
            r => r.Start > DateOnly.FromDateTime(DateTime.Today),
            DateRangeAssertionCodes.BeInFuture,
            $"Expected start date in the future but found {Subject.Start}");
    }
}

public sealed class DateRangeAssertions : DateRangeAssertionsBase<DateRangeAssertions>
{
    public DateRangeAssertions(DateRange subject) : base(subject, throwOnFailure: false) { }

    public static implicit operator Result<DateRange, Error>(DateRangeAssertions a) => a.ToResult();
}

public sealed class MustDateRangeAssertions : DateRangeAssertionsBase<MustDateRangeAssertions>
{
    public MustDateRangeAssertions(DateRange subject) : base(subject, throwOnFailure: true) { }
}

public static class DateRangeAssertionExtensions
{
    public static DateRangeAssertions Should(this DateRange subject) => new(subject);
    public static MustDateRangeAssertions Must(this DateRange subject) => new(subject);
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
