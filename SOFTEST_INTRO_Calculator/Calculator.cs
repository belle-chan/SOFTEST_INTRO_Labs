namespace SOFTEST_INTRO_Calculator;

public class Calculator
{
    public double Add(double a, double b)
    {
        if (ContainsOnlyBinaryDigits(a) &&
            ContainsOnlyBinaryDigits(b))
        {
            string combined = $"{(long)a}{(long)b}";
            return Convert.ToInt64(combined, 2);
        }

        return a + b;
    }

    private static bool ContainsOnlyBinaryDigits(double value)
    {
        if (value < 0 || value != Math.Truncate(value))
        {
            return false;
        }

        string text = ((long)value).ToString();

        return text.All(character =>
            character == '0' || character == '1');
    }
    public double Subtract(double a, double b) => a - b;
    public double Multiply(double a, double b) => a * b;
    // Starter version: complete the zero-divisor rule in section 5. 
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Divisor cannot be zero.");
        }

        return a / b;
    }

    public double DoOperation(double a, double b, string op)
    {
        return op switch
        {
            "a" => Add(a, b),
            "s" => Subtract(a, b),
            "m" => Multiply(a, b),
            "d" => Divide(a, b),
            _ => throw new ArgumentException("Unknown operation.")
        };
    }

    public long Factorial(int n)
    {
        if (n < 0 || n > 20)
        {
            throw new ArgumentOutOfRangeException(
                nameof(n),
                "Factorial input must be between 0 and 20.");
        }

        long result = 1L;

        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }

        return result;
    }

    public double TriangleArea(double height, double width)
    {
        if (height < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(height),
                "Height cannot be negative.");
        }

        if (width < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(width),
                "Width cannot be negative.");
        }

        return 0.5 * height * width;
    }

    public double CircleArea(double radius)
    {
        if (radius < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(radius),
                "Radius cannot be negative.");
        }

        return Math.PI * radius * radius;
    }

    public long UnknownFunctionA(int n, int r)
    {
        if (n < 0 || n > 20 || r < 0 || r > n)
        {
            throw new ArgumentOutOfRangeException(
                nameof(r),
                "Inputs must satisfy 0 <= r <= n <= 20.");
        }

        return Factorial(n) / Factorial(n - r);
    }

    public long UnknownFunctionB(int n, int r)
    {
        if (n < 0 || n > 20 || r < 0 || r > n)
        {
            throw new ArgumentOutOfRangeException(
                nameof(r),
                "Inputs must satisfy 0 <= r <= n <= 20.");
        }

        return Factorial(n) /
            (Factorial(r) * Factorial(n - r));
    }

    public double CalculateMtbf(
    double operatingTime, int numberOfFailures)
    {
        if (operatingTime <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(operatingTime),
                "Operating time must be positive.");
        }

        if (numberOfFailures <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(numberOfFailures),
                "Number of failures must be positive.");
        }

        return operatingTime / numberOfFailures;
    }

    public double CalculateAvailability(double mtbf, double mttr)
    {
        if (mtbf < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(mtbf),
                "MTBF cannot be negative.");
        }

        if (mttr < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(mttr),
                "MTTR cannot be negative.");
        }

        if (mtbf + mttr <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(mtbf),
                "MTBF and MTTR cannot both be zero.");
        }

        return mtbf / (mtbf + mttr);
    }

    public double CalculateCurrentFailureIntensity(
        double initialFailureIntensity,
        double expectedTotalFailures,
        double executionTime)
    {
        ValidateBasicMusaInputs(
            initialFailureIntensity,
            expectedTotalFailures,
            executionTime);

        return initialFailureIntensity *
            Math.Exp(
                -initialFailureIntensity * executionTime /
                expectedTotalFailures);
    }

    public double CalculateExpectedCumulativeFailures(
        double initialFailureIntensity,
        double expectedTotalFailures,
        double executionTime)
    {
        ValidateBasicMusaInputs(
            initialFailureIntensity,
            expectedTotalFailures,
            executionTime);

        return expectedTotalFailures *
            (1 - Math.Exp(
                -initialFailureIntensity * executionTime /
                expectedTotalFailures));
    }

    private static void ValidateBasicMusaInputs(
        double initialFailureIntensity,
        double expectedTotalFailures,
        double executionTime)
    {
        if (initialFailureIntensity <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(initialFailureIntensity),
                "Initial failure intensity must be positive.");
        }

        if (expectedTotalFailures <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(expectedTotalFailures),
                "Expected total failures must be positive.");
        }

        if (executionTime < 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(executionTime),
                "Execution time cannot be negative.");
        }
    }
}