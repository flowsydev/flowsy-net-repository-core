# Flowsy Repository Core

Basic abstractions for creating entity repositories which main goal is to define the behavior expected from
each final implementation, no matter what the underlying database technology (SQL, Documental, etc).

## Concepts
When developing applications, we need to create models of the objects and concepts from the real world.
Our models depict the names, attributes and relationships between those objects.
From an abstract point of view, we will say that every object in our model is an entity which will be stored 
in a repository, from where it can be fetched when needed.

## Naming Conventions
As we will see, it is of great importance to define naming conventions for classes and properties, and stick to them
within development teams, so classes implementing interfaces from this package can be built in a consistent way and
provide ease of use to the final user.


## IEntity
Interface that shall be implemented by classes used as entities handled by a given repository.

## IEntityTranslation
Interface that shall be implemented by classes used as the translation for a given entity.
Intended for applications with multi-lingual support.

### Creating an Entity Translation
Along with our main entities, we can create special entities to hold all the translatable properties required for each case.
```csharp
// Entity
public class Product : IEntity 
{
    public int ProductId { get; set; }
    public string Sku { get; set; } = string.Empty; // Not translatable
    // Other properties not requiring translation
}

// Entity translation
public class ProductTranslation : IEntityTranslation
{
    // Identity for ProductTranslation
    public int ProductTranslationId { get; set; }
    
    // Identity for Product
    public int ProductId { get; set; }
    
    ////////////////////////////////////////////////////////////////////////////////
    // Defined in IEntityTranslation
    ////////////////////////////////////////////////////////////////////////////////
    // Value required by the application to identify a specific culture
    // A best practice is to set this property to a value based on RFC 4646 (en-US, es-MX, etc)
    public string CultureId { get; set; } = string.Empty;
    
    // Optional culture name
    public string? CultureName { get; set; }
    
    // Optional language data
    public string? TranslationLanguageId { get; set; }
    public string? TranslationLanguageName { get; set; }
    
    // Optional country data
    public string? TranslationCountryId { get; set; }
    public string? TranslationCountryName { get; set; }
    
    ////////////////////////////////////////////////////////////////////////////////
    // Translatable attributes for a 'Product'
    ////////////////////////////////////////////////////////////////////////////////
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    // ...
}
```

### Creating the Translated Version of an Entity
In a similar way, we can make combinations of the two examples above, to create the translated version of our main entities.
If we take these concepts to a relational database scenario, a translated version of an entity can be thought of as a query joining
the two previous entities: Product and ProductTranslation.
```csharp
public class ProductTranslated : Product, IEntityTranslation
{
    // This class will inherit all the members of a Product
    // and shall include the required ones defined in ProductTranslation
    // in order to create a translated version for a given culture

    ////////////////////////////////////////////////////////////////////////////////
    // Data about the given culture (from IEntityTranslation)
    ////////////////////////////////////////////////////////////////////////////////
    // Value required by the application to identify a specific culture
    // A best practice is to set this property to a value based on RFC 4646 (en-US, es-MX, etc)
    public string CultureId { get; set; } = string.Empty;
    
    // Optional culture name
    public string? CultureName { get; set; }
    
    // Optional language data
    public string? TranslationLanguageId { get; set; }
    public string? TranslationLanguageName { get; set; }
    
    // Optional country data
    public string? TranslationCountryId { get; set; }
    public string? TranslationCountryName { get; set; }

    ////////////////////////////////////////////////////////////////////////////////
    // Translatable attributes for a 'Product'
    ////////////////////////////////////////////////////////////////////////////////
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    // ...
}
```

## IRepository
Interface that defines the behavior of a repository for storing, retrieving, updating and deleting entities.
Other interfaces inheriting or objects implementing this interface can define additional methods suited for a specific entity use case.

```csharp
public interface IRepository<TEntity, TIdentity> : IRepository where TEntity : class, IEntity
{
}
```

### Generic Type Parameters
#### TEntity
The type of entity handled by the repository.

#### TIdentity
The type of the property that uniquely identifies each entity of the repository.


### Properties
#### EntityName
A string to identify the type of entity handled for the repository.
It is highly recommended to stick to a PascalCase convention, so specific implementations will be able to perform tasks in a consistent way.
The entity name can be thought of as the noun used to describe that real world object or concept being modeled: Product, Customer, Invoice, PurchaseOrder, etc.


#### IdentityPropertyName
The name of the property that holds unique identifiers for entities of the repository.
It is highly recommended to use consistent values in PascalCase format for all of the entities handled by the application.

### Methods
The IRepository interface defines several methods intended to create, retrieve, update and delete entities.
Some methods expose overloaded versions to offer different choices to the caller.
This way the repository can perform the same task receiving the type of input best suited for every scenario.

For example, the CreateAsync method offers the following overloads:
```csharp
public interface IRepository<TEntity, TIdentity>
{
    // The type of entity is provided when invoking the method
    Task<TIdentity> CreateAsync<T>(T entity, CancellationToken cancellationToken) where T : class;
    
    // The type of entity is the same known to be handled by the repository
    Task<TIdentity> CreateAsync(TEntity entity, CancellationToken cancellationToken);
    
    // A dynamic object is provided to read the properties to be set for the new entity
    Task<TIdentity> CreateAsync(dynamic entity, CancellationToken cancellationToken);
    
    // A dictionary is provided to read the properties to be set for the new entity
    Task<TIdentity> CreateAsync(IReadOnlyDictionary<string, object?> properties, CancellationToken cancellationToken);
}
```
As we can see, the four versions of the same method can be used to create a new entity in the underlying data store,
but we can provide the type of argument that best suits our needs. 

In the same way, the rest of the methods of the IRepository interface provide support for the same types of arguments, so
we can invoke all of them in a flexible and consistent manner.

**Important:** It is strongly recommended to stick to a PascalCase format for the names of the properties set on
the **dynamic** and **IReadOnlyDictionary** objects passed as arguments, in order to keep consistency throughout 
different implementations of IRepository.

The IRepository interface defines overloaded versions of the following methods:
* CreateAsync: Creates a new entity in the repository.
* UpdateAsync: Updates all attributes of an entity in the repository.
* PatchAsync: Updates certain attributes of an entity of the repository.
* DeleteByIdAsync: Deletes the one entity with the specified unique identifier.
* DeleteManyAsync: Deletes one or more entities matching the specified criteria.
* GetByIdAsync: Retrieves the entity with the specified unique identifier. 
* GetByIdExtendedAsync: Retrieves an extended version of one entity with the specified unique identifier.
* GetOneAsync: Retrieves a single entity matching the specified criteria.
* GetOneExtendedAsync: Retrieves an extended version of a single entity matching the specified criteria.
* GetManyAsync: Retrieves one or more entities matching the specified criteria.
* GetManyExtendedAsync: Retrieves an extended version of one or more entities matching the specified criteria.
* GetPageAsync: Retrieves a page of one or more entities matching the specified criteria.
* GetPageExtendedAsync: Retrieves a page of the extended version of one or more entities matching the specified criteria.

**Note:**
The extended version of an entity shall include additional attributes which may be computed from another attributes of the same entity or gathered from another related entities.


## IRepositoryTranslation
Represents a repository able to retrieve translated versions of its entities through overloaded versions of the 'Get*' methods that include an argument for the culture identifier.
The IRepositoryTranslation interface inherits from IRepository, so it includes of the inherited members plus all the new ones defined.
```csharp
public interface IRepositoryTranslation<TEntity, TEntityTranslation, TIdentity> :
    IRepository<TEntity, TIdentity>
    where TEntity : class, IEntity
    where TEntityTranslation : TEntity, IEntityTranslation
{
    // Get* methods overloaded to receive the culture identifier   
}
```
### Generic Type Parameters
#### TEntity
The type of entity handled by the repository.

#### TEntityTranslation
The type of the entity translation.

#### TIdentity
The type of the property that uniquely identifies each entity of the repository.



## AbstractRepository & Abstract Repository Translation
Implement **IRepository** and **IRepositoryTranslation** with virtual methods that throw a **NotSupportedException** exception.
These classes are abstract and were created as a starting point for other classes, so they only need to override the methods
required for a specific implementation, the rest should not be invoked or otherwise will throw an exception by design. 

## IUnitOfWork & IUnitOfWorkFactory
The interface **IUnitOfWork** represents an atomic operation for the underlying data store.
For example, for a SQL database a class implementing **IUnitOfWork** shall be a wrapper for **IDbTransaction** objects.

On the other hand, implementations of **IUnitOfWorkFactory** shall create instances of the requested type of unit of work.
A unit of work shall be designed to group a set of repositories which are related in the context of a given operation.

For example, to create an invoice, we may need to create two kinds of entities:
* Invoice
  * InvoiceId
  * CustomerId
  * CreateDate
  * Total
  * Taxes
  * GrandTotal
* InvoiceItem
  * InvoiceItemId
  * InvoiceId
  * ProductId
  * Quantity
  * Amount 

The way of completing such operation from an application-level command handler could be:
```csharp
public class CreateInvoiceCommandHandler
{
    public async Task<CreateInvoiceCommandResult> HandleAsync(CreateInvoiceCommand command, CancellationToken cancellationToken)
    {
        // Begin operation
        // IUnitOfWork inherits from IDisposable and IAsyncDisposable, if any exception is thrown, the current operation shall be rolled back
        await using var unitOfWork = unitOfWorkFactory.Create<ICreateInvoiceUnitOfWork>();

        var invoice = new Invoice();
        // Populate invoice object from properties of command object 
        
        // Create the Invoice entity
        var invoiceId = await unitOfWork.InvoiceRepository.CreateAsync(invoice, cancellationToken);
        
        // Create all the InvoiceItem entities
        foreach (var item in command.Items)
        {
            var invoiceItem = new InvoiceItem();
            // Populate invoiceItem object from properties of item object
            
            // Create each InvoiceItem entity
            await unitOfWork.InvoiceItemRepository.CreateAsync(invoiceItem, cancellationToken); 
        }

        // Commit the current operation        
        await unitOfWork.CommitAsync(cancellationToken);
        
        // Return the result of the operation
        return new CreateInvoiceCommandResult
        {
            InvoiceId = invoiceId
        };
    }
}
```

## Final Thoughts
As shown before, this package provides only abstractions aimed to offer consistency and a starting point for different kinds of repositories no matter the underlying infrastructure.
From an application-level point of view, we only need to create or retrieve entities wihout even caring about what needs to be done internally to do the job.
