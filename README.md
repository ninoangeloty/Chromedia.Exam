# OVERVIEW
A Web API that will fetch a collection of articles from an endpoint.
The solution is following a standard Clean Architecture with CQRS. A mediator is used invoke a query request from the controller to a request handler. The request handler will then return the result through the mediator (using MediatR.net).

# HOW TO USE
Run the solution in Visual Studio with the Chromedia.Api set as Startup Project.
The solution is configured to use SwaggerUI so tests can be made from there.

# TESTS
Tests are in Chromedia.Tests project.
