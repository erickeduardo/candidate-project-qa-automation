Feature: Schedule functionality
    As a user, I want to access schedule page and check basic functionality

    Scenario: Check if appointment is available at specific hour
        Given I am on the Schedule Page
        Then I should see page title 'Schedule | ZoomCare'
        When I select location as 'Portland, OR'
        When I select service as 'Primary Care'
        When I select date as '12'
        When I click search button
        Then I should see 'Primary Care' header
