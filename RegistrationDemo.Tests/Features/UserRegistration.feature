Feature: UserRegistration
In order to use the features only available to members
As a Guest user 
I want to register a new account 

@Browser:Firefox
Scenario:  User signs up with valid details
Given I am on the home page
And I am not logged in
When I click the register button
And fill of the registration form with the following details
| field             | value                |
| UserName          | joe.{0}@snuffy.com   |
| Password          | Password_01          |
| ConfirmPassword   | Password_01          |
And I submit the form
Then I am redirected to the home page
And I will be logged in

@Browser:Firefox
Scenario:  User signs up with mismatched passwords
Given I am on the home page
And I am not logged in
When I click the register button
And fill of the registration form with the following details
| field             | value                |
| UserName          | joe.{0}@snuffy.com   |
| Password          | Password_01          |
| ConfirmPassword   | Pasword_01           |
And  I submit the form
Then I will see the message The password and confirmation password do not match.
