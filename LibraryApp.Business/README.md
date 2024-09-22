# Business Layer
The Business layer is responsible for implementing the core logic of the application. It acts as a bridge between the Data Access layer and the presentation layer.

### Contracts
- IServiceManager
- IAuthorService
- IBookService
- IUserService

### Concretes
- ServiceManager
- AuthorManager
- BookManager
- UserManager

### Dependency Resolver
- AutofacBusinessModule
