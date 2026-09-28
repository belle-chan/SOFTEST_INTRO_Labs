@BasicMusa 
Feature: UsingCalculatorBasicReliability 
  In order to calculate the Basic Musa model's failures and intensities 
  As a Software Quality Metric enthusiast 
  I want to use my calculator to do this

  Scenario: Calculate the current failure intensity
    Given I have a calculator
    And the initial failure intensity is 10 failures per hour
    And the expected total number of failures is 100
    And the accumulated execution time is 5 hours
    When I calculate the current failure intensity
    Then the result should be 6.065306597126334

  Scenario: Calculate the expected cumulative failures
    Given I have a calculator
    And the initial failure intensity is 10 failures per hour
    And the expected total number of failures is 100
    And the accumulated execution time is 5 hours
    When I calculate the expected cumulative failures
    Then the result should be 39.34693402873666

  Scenario Outline: Reject invalid Basic Musa inputs
    Given I have a calculator
    And the initial failure intensity is <lambda> failures per hour
    And the expected total number of failures is <nu>
    And the accumulated execution time is <time> hours
    When I calculate the current failure intensity
    Then the Basic Musa calculation should be rejected

    Examples:
      | lambda | nu  | time |
      | 0      | 100 | 5    |
      | 10     | 0   | 5    |
      | 10     | 100 | -1   |