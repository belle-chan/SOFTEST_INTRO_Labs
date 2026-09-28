@Factorial
Feature: UsingCalculatorFactorial
  In order to calculate factorial values
  As a calculator user
  I want the calculator to calculate factorials

  Scenario: Calculate a normal factorial
    Given I have a calculator
    When I calculate the factorial of 5
    Then the factorial result should be 120

  Scenario: Calculate the factorial identity case
    Given I have a calculator
    When I calculate the factorial of 0
    Then the factorial result should be 1

  Scenario: Reject an unsupported factorial value
    Given I have a calculator
    When I calculate the factorial of 21
    Then the factorial calculation should be rejected