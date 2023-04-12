Feature: Schedule functionality
    As a user, I want to access schedule page and check basic functionality
    
Scenario Outline: Check if Clinic Care appointment is available at specific hour
    Given I am on the Schedule Page
    Then I should see page title 'Schedule | ZoomCare'
    When I select location as '<location>'
    And I select service as '<service>'
    And I select date as '<date>'
    And I click search button
    Then I should see '<service>' header
    And I should see '<hour>' hour is available

    Examples:
    | location    | service         | date | hour     |
    | Portland,OR | Primary Care    | 12   | 6:30 PM  |
    | Salem, OR   | Illness/Injury  | 12   | 10:15 PM  |
    | Seattle, WA | Family Medicine | 18   | 11:00 AM  |
