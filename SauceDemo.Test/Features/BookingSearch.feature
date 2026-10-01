Feature: Booking Hotel Search

Scenario: Search for a specific hotel and check its rating
    Given I open the Booking search page
    When I enter the hotel name "Pulitzer Amsterdam"
    And I click the Search button
    Then I should see the hotel "Pulitzer Amsterdam" in the search results
    And the rating for this hotel should be "8.9"