Feature: Create customer
  In order to persist customers
  As a client of the API
  I want to be able to create a customer

  Scenario: Successfully create a customer
    Given a valid create customer request with name "AnyName", cpf "11111111111" and email "test@test.com"
    When the client calls the Create endpoint
    Then the response should contain the created customer with id 1 and the same name, cpf and email and updatedAt null