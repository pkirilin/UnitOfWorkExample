# UnitOfWorkExample

There are many examples in the internet of UnitOfWork and Repository patterns implemented for EntityFramework Core.
But what if your ORM is not EF Core? Or maybe you decide to change ORM after some time? Can you safely use the same abstraction you've implemented for EF Core? Most likely, the answer is no.

The goal of this project was to find out the following:

> How to implement UnitOfWork and Repository, which has the same interface regardless of what ORM you are using?

The project itself is a simple CRUD weather forecast API.
