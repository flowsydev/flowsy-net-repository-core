# Flowsy Repository Core

Basic abstractions for creating entity repositories which main goal is to define the behavior of
each final implementation, no matter what the underlying database technology (SQL, Documental, etc).  

## IEntity
Interface for objects used as entities for a given repository.

## IEntityTranslation
Interface for objects used as the translation for a given entity.
Intended for applications with multi-lingual support.
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
    public int ProductTranslationId { get; set; }
    public int ProductId { get; set; }
    
    // Defined in IEntityTranslation
    // Value used by the application to identify a specific culture
    // A best practice is to set this property to a value based on RFC 4646 (en-US, es-MX, etc)
    public string CultureId { get; set; } = string.Empty;
    
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    // Other translatable attributes for a 'Product'
}
```

## IEntityTranslated
Interface for objects extending an entity to include a specific translation.
An object implementing **IEntityTranslated** can be thought of as a combination of an entity and its translation.
Intended for applications with multi-lingual support.
```csharp
public class ProductTranslated : Product, IEntityTranslated
{
    public string CultureId { get; set; } // Defined in IEntityTranslated. Example: en-US
    public string? CultureName { get; set; } // Defined in IEntityTranslated. Example: English (United States of America)
    
    public string? LanguageId { get; set; } // Defined in IEntityTranslated. Example: es
    public string? LanguageName { get; set; } // Defined in IEntityTranslated. Example: English
    
    public string? CountryId { get; set; } // Defined in IEntityTranslated. Example: US
    public string? CountryName { get; set; } // Defined in IEntityTranslated. Example: United States of America

    public string Name { get; set; } = string.Empty; // Value specific for the english (US) version
    public string? Description { get; set; } // Value specific for the english (US) version
    // Other translatable attributes for a 'Product'
}
```

## IRepository
Interface that defines the behavior of a repository for storing, retrieving and updating entities.
Other interfaces inheriting or objects implementing this interface can define additional methods suited for a specific entity use case.

### Repository Data and Behavior
* Entity Name: A string to identify the type of entity handled for the repository. Example: Product.
* Identity Property Name: The property of the underlying entity used as unique identifier for entitiies of the repository. Example: ProductId.
* Create: Creates a new entity in the repository.
* Update: Updates all attributes of an entity in the repository.
* Patch: Updates certain attributes of an entity of the repository.
* Delete By Id: Deletes the one entity with the specified unique identifier.
* Delete Many: Deletes one or more entities matching the specified criteria.
* Get By Id: Retrieves the one entity with the specified unique identifier. 
* Get By Id Extended: Retrieves an extended version of one entity with the specified unique identifier.
* Get One: Retrieves a single entity matching the specified criteria.
* Get One Extended: Retrieves an extended version of a single entity matching the specified criteria.
* Get Many: Retrieves one or more entities matching the specified criteria.
* Get Many Extended: Retrieves an extended version of one or more entities matching the specified criteria.

**Note:**
The extended version of an entity shall include additional attributes which may be computed from another attributes of the same entity or gathered from another related entities.

## IRepositoryLocalized
Represents a repository able to retrieve translated versions of its entities through overloaded versions the its methods that include an argument for the culture identifier.

## AbstractRepository
Implements **IRepository** with virtual methods that throw a **NotSupportedException** exception.
This class is abstract and was created as a starting point for other classes.
The classes inheriting **AbstractRepository** only need to override the methods required for a specific implementation, the rest should not be invoked or otherwise will throw an exception by design. 

## IUnitOfWork & IUnitOfWorkFactory
The interface **IUnitOfWork** represents an atomic operation for the underlying data store.
For example, for a SQL database a class implementing **IUnitOfWork** shall be a wrapper for **IDbTransaction** objects.

On the other hand, implementations of **IUnitOfWorkFactory** shall create instances of the requested type of unit of work.
A unit of work shall be designed to group a set of repositories which are related in the context of a given operation.

For example, to create an invoice, we may need to create two kind of entities:
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
    public async Task<CreateInvoiceCommandResult> ExecuteAsync(CreateInvoiceCommand command, CancellationToken cancellationToken)
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


