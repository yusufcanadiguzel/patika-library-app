# Presentation Layer

Presentation layer is responsible for the user interface and interaction within the ASP.NET MVC application. It follows the Model-View-Controller architecture, where the Model represents the data and business logic, the View displays the user interface elements, and the Controller handles user input and communication between the Model and View.

## Controllers

- ### BookController Operations

  - List: Gets the list of books.
  - Details: Gets the details of the book.
  - Create: Creates a book.
  - Edit: Edits a book.
  - Delete: Deletes a book.

- ### AuthorControlller Operations

  - List: Gets the list of authors.
  - Details: Gets the details of the author.
  - Create: Creates an author.
  - Edit: Edits an author.
  - Delete: Deletes an author.

- ### AuthController Operations

  - SignIn: Manages sign in operation.
  - SignUp: Manages sign up operation.

## Views

- ### Book Views

  - List: A view that displays a list of books.
  - Details: A view that displays book details.

- ### Author Views

  - List: A view that displays a list of authors.
  - Details: A view that displays author details.

- ### User Views

  - SignIn: A view for registering with user information. It must include a 'Confirm Password' field, and an alert should be displayed if it does not match the password.
  - SignUp: A view for logging in with email and password. Depending on the result of the operation, it should either display an error on the same page or redirect to the home page upon successful login.

## Admin Area

- ### Book Area

  - List: A view that displays a list of books. Deletion can also be performed with a button.
  - Details: A view that displays book details.
  - Create: A view containing a form to add a new book.
  - Edit: A view containing a form to edit existing books.

- ### Author Area

  - List: A view that displays a list of authors. Deletion can also be performed with a button.
  - Details: A view that displays author details.
  - Create: A view containing a form to add a new author.
  - Edit: A view containing a form to edit existing authors.
  
