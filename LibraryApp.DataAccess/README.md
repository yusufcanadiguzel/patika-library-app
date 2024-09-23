# Data Access Layer
The Data Access layer intermediates between the application and the data storage mechanism.

### Contracts
- IEntityRepository<T>
- IAuthorRepository
- IBookRepository
- IUserRepository

### Concretes
- InMemoryAuthorRepository
- InMemoryBookRepository
- InMemoryUserRepository
- EfEntityRepositoryBase 
- EfAuthorRepository
- EfBookRepository
- EfUserRepository

### Contexts
- EfLibraryAppDbContext
