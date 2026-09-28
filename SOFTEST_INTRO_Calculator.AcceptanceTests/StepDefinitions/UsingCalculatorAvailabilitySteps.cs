using NUnit.Framework;
using Reqnroll;
using SOFTEST_INTRO_Calculator.AcceptanceTests.Support;

namespace SOFTEST_INTRO_Calculator.AcceptanceTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorAvailabilitySteps
{
    private readonly CalculatorContext _context;

    private readonly ReliabilityContext _reliability;

    public UsingCalculatorAvailabilitySteps(
        CalculatorContext context,
        ReliabilityContext reliability)
    {
        _context = context;
        _reliability = reliability;
    }


    [Given("the reliability values are")]
    public void GivenTheReliabilityValuesAre(DataTable table)
    {
        var values = table.Rows[0];

        _reliability.Mtbf = double.Parse(values["MTBF"]);
        _reliability.Mttr = double.Parse(values["MTTR"]);
    }

    [When("I calculate Availability from these values")]
    public void WhenICalculateAvailabilityFromTheseValues()
    {
        _context.Result = null;
        _context.Error = null;

        _context.Result =
            _context.Calculator.CalculateAvailability(
                _reliability.Mtbf,
                _reliability.Mttr);
    }

    [When("I have entered {double} hours and {int} failures into the calculator and press MTBF")]
    public void WhenICalculateMtbf(
        double operatingTime, int numberOfFailures)
    {
        _context.Result = null;
        _context.Error = null;

        try
        {
            _context.Result = _context.Calculator.CalculateMtbf(
                operatingTime, numberOfFailures);
        }
        catch (ArgumentOutOfRangeException error)
        {
            _context.Error = error;
        }
    }

    [When("I have entered {double} and {double} into the calculator and press Availability")]
    public void WhenICalculateAvailability(
        double mtbf, double mttr)
    {
        _context.Result = null;
        _context.Error = null;

        try
        {
            _context.Result =
                _context.Calculator.CalculateAvailability(mtbf, mttr);
        }
        catch (ArgumentOutOfRangeException error)
        {
            _context.Error = error;
        }
    }

    [Then("the reliability calculation should be rejected")]
    public void ThenTheReliabilityCalculationShouldBeRejected()
    {
        Assert.That(
            _context.Error,
            Is.TypeOf<ArgumentOutOfRangeException>());
    }
}