using NUnit.Framework;
using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorBasicReliabilitySteps
{
    private readonly CalculatorContext _context;
    private readonly BasicMusaContext _musa;

    public UsingCalculatorBasicReliabilitySteps(
        CalculatorContext context,
        BasicMusaContext musa)
    {
        _context = context;
        _musa = musa;
    }

    [Given("the initial failure intensity is {double} failures per hour")]
    public void GivenTheInitialFailureIntensityIs(double value)
    {
        _musa.InitialFailureIntensity = value;
    }

    [Given("the expected total number of failures is {double}")]
    public void GivenTheExpectedTotalNumberOfFailuresIs(double value)
    {
        _musa.ExpectedTotalFailures = value;
    }

    [Given("the accumulated execution time is {double} hours")]
    public void GivenTheAccumulatedExecutionTimeIs(double value)
    {
        _musa.ExecutionTime = value;
    }

    [When("I calculate the current failure intensity")]
    public void WhenICalculateTheCurrentFailureIntensity()
    {
        _context.Result = null;
        _context.Error = null;

        try
        {
            _context.Result =
                _context.Calculator.CalculateCurrentFailureIntensity(
                    _musa.InitialFailureIntensity,
                    _musa.ExpectedTotalFailures,
                    _musa.ExecutionTime);
        }
        catch (ArgumentOutOfRangeException error)
        {
            _context.Error = error;
        }
    }

    [When("I calculate the expected cumulative failures")]
    public void WhenICalculateTheExpectedCumulativeFailures()
    {
        _context.Result = null;
        _context.Error = null;

        try
        {
            _context.Result =
                _context.Calculator.CalculateExpectedCumulativeFailures(
                    _musa.InitialFailureIntensity,
                    _musa.ExpectedTotalFailures,
                    _musa.ExecutionTime);
        }
        catch (ArgumentOutOfRangeException error)
        {
            _context.Error = error;
        }
    }

    [Then("the Basic Musa calculation should be rejected")]
    public void ThenTheBasicMusaCalculationShouldBeRejected()
    {
        Assert.That(
            _context.Error,
            Is.TypeOf<ArgumentOutOfRangeException>());
    }
}