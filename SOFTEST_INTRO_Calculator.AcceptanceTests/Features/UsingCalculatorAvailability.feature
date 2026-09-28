@Availability
Feature: UsingCalculatorAvailability
  In order to calculate MTBF and Availability
  As someone who struggles with maths
  I want to be able to use my calculator to do this

  Scenario: Calculating MTBF
    Given I have a calculator
    When I have entered 1000 hours and 5 failures into the calculator and press MTBF
    Then the result should be 200

  Scenario: Calculating Availability
    Given I have a calculator
    When I have entered 80 and 20 into the calculator and press Availability
    Then the result should be 0.8

  Scenario: Calculating Availability with no repair time
    Given I have a calculator
    When I have entered 100 and 0 into the calculator and press Availability
    Then the result should be 1

  Scenario: Rejecting MTBF with zero failures
    Given I have a calculator
    When I have entered 1000 hours and 0 failures into the calculator and press MTBF
    Then the reliability calculation should be rejected

  Scenario: Calculating Availability from named reliability values 
    Given I have a calculator 
    And the reliability values are 
      | MTBF | MTTR | 
      | 90     | 10    | 
    When I calculate Availability from these values 
    Then the result should be 0.9