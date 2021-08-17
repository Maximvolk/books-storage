# Books Storage

This is a service which provides user with basic CRUD operations with Books Storage (books with authors).

### Technologies
Used technoligies are: ASP.NET Core 5.0, EntityFramework (ORM), PostgreSQL (RDBMS)

While development PostgreSQL was launched in docker container (docker-compose file provided).

### Structure / architecture
Project structured in a 'Clean Architecture'-like (R.Martin) style.
Web presentation layer uses MVC.

### Possible improvements
- Unit tests.
- Use Unit Of Work pattern over Repositories to unify working with DB.