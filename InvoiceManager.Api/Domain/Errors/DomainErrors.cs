namespace InvoiceManager.Api.Domain.Errors;

public static class Error
{
    public static readonly AppError NotFound =
        new("Resource not found.", "General.NotFound");

    public static readonly AppError AlreadyExists =
        new("Resource already exists.", "General.AlreadyExists");

    public static readonly AppError Conflict =
        new("A conflict occurred with the current state.", "General.Conflict");

    public static readonly AppError CannotDelete =
        new("Resource cannot be deleted.", "General.CannotDelete");

    public static readonly AppError InUse =
        new("Resource is currently in use.", "General.InUse");

    public static readonly AppError Unexpected =
        new("An unexpected error occurred.", "General.Unexpected");
}

public static class InvoiceError
{
    public static readonly AppError NotFound =
        new("Invoice not found.", "Invoice.NotFound");

    public static readonly AppError AlreadyExists =
        new("Invoice already exists.", "Invoice.AlreadyExists");

    public static readonly AppError CannotDelete =
        new("Invoice cannot be deleted.", "Invoice.CannotDelete");

    public static readonly AppError Conflict =
        new("Invoice is in an invalid state.", "Invoice.Conflict");
}

public static class SupplierError
{
    public static readonly AppError NotFound =
        new("Supplier not found.", "Supplier.NotFound");

    public static readonly AppError AlreadyExists =
        new("Supplier already exists.", "Supplier.AlreadyExists");

    public static readonly AppError CannotDelete =
        new("Supplier cannot be deleted.", "Supplier.CannotDelete");

    public static readonly AppError InUse =
        new("Supplier is currently in use.", "Supplier.InUse");
}

public static class SchoolError
{
    public static readonly AppError NotFound =
        new("School not found.", "School.NotFound");

    public static readonly AppError AlreadyExists =
        new("School already exists.", "School.AlreadyExists");

    public static readonly AppError CannotDelete =
        new("School cannot be deleted.", "School.CannotDelete");

    public static readonly AppError InUse =
        new("School is currently in use.", "School.InUse");
}

public static class ProductError
{
    public static readonly AppError NotFound =
        new("Product not found.", "Product.NotFound");

    public static readonly AppError AlreadyExists =
        new("Product already exists.", "Product.AlreadyExists");

    public static readonly AppError CannotDelete =
        new("Product cannot be deleted.", "Product.CannotDelete");

    public static readonly AppError InUse =
        new("Product is currently in use.", "Product.InUse");
}