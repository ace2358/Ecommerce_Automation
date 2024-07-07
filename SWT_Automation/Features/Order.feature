Feature: Order

Background:
  Given the user has logged in

Scenario: Post a new article after successful login
    When the user navigates to men's page
    And user chooses an item
    And user adds to cart
    Then user places order