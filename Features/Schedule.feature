Feature: Schedule functionality
    As a user, I want to access schedule page and check basic functionality

Scenario Outline: Validate I can see more options after search
    Given I am on the Schedule Page
    Then I should see page title 'Schedule | ZoomCare'
    When I select location as '<location>'
    And I select service as '<service>'
    And I select date as '<date>'
    And I click search button
    Then I should see '<service>' header
    And I should see '<before_count>' clinics available
    When I click Show More button
    Then I should see '<after_count>' clinics available

    Examples:
    | location     | service      | date | before_count | after_count |
    | Portland, OR | Primary Care | 13   | 5            | 10          |

Scenario Outline: Validate Clinic Care appointment is available
    Given I am on the Schedule Page
    Then I should see page title 'Schedule | ZoomCare'
    When I select location as '<location>'
    And I select service as '<service>'
    And I select date as '<date>'
    And I click search button
    Then I should see '<service>' header
    And I should see Virtual Clinic button exists

    Examples:
    | location    | service                   | date |
    | Eugene, OR  | Mental Health Meds & More | 12   |

Scenario Outline: Validate Video Care appointment is available
    Given I am on the Schedule Page
    Then I should see page title 'Schedule | ZoomCare'
    When I select location as '<location>'
    And I select service as '<service>'
    And I select date as '<date>'
    And I click search button
    Then I should see '<service>' header
    And I should see Virtual Video button exists

    Examples:
    | location      | service         | date |
    | Vancouver, WA | Family Medicine | 13   |

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
    | Portland,OR | Primary Care    | 13   | 8:30 AM  |
    | Salem, OR   | Illness/Injury  | 12   | 10:15 PM  |
    | Seattle, WA | Family Medicine | 18   | 11:00 AM  |

Scenario Outline: Validate provider page
    Given I am on the Schedule Page
    Then I should see page title 'Schedule | ZoomCare'
    When I select location as '<location>'
    And I select service as '<service>'
    And I select date as '<date>'
    And I click search button
    Then I should see '<service>' header
    When I click the '<provider>' provider on the list
    Then I should see the url changed to '/provider/'

    Examples:
    | location    | service         | date | provider |
    | Portland,OR | Primary Care    | 13   | 1        |
    | Seattle, WA | Family Medicine | 18   | 1        |
