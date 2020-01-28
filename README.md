# InMemoryRepo
In memory implementation of the repository pattern

Created Repository.cs to implement the methods in IRepository interface

Created a MockStoreable.cs class so the methods in the Repository.cs class could be tested

Added NUnit Reference to project to include Unit Tests

Refactored code to deal with duplicates in the Save Method

Refactored code so the Delete method doesnt throw an exception if it doesnt find an entry with a specific id.

Added additional test for duplicates during Save
