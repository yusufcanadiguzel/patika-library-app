# Data Access Layer
The Data Access layer serves as the intermediary between the application and the data storage mechanism.

### Contracts
- IEntityRepository<T>
- IAuthorRepository
- IBookRepository
- IUserRepository

### Concretes
- InMemoryAuthorRepository
- InMemoryBookRepository
- InMemoryUserRepository
