namespace InvoiceManager.Api.Domain.Errors;

public static class Error
{
    public static readonly AppError NotFound =
        new("General.NotFound", "Resource not found.");

    public static readonly AppError AlreadyExists =
        new("General.AlreadyExists", "Resource already exists.");

    public static readonly AppError Conflict =
        new("General.Conflict", "A conflict occurred with the current state.");

    public static readonly AppError CannotDelete =
        new("General.CannotDelete", "Resource cannot be deleted.");

    public static readonly AppError InUse =
        new("General.InUse", "Resource is currently in use.");

    public static readonly AppError Unexpected =
        new("General.Unexpected", "An unexpected error occurred.");
}

public static class Invoice
{
    public static readonly AppError NotFound =
        new("Invoice.NotFound", "Invoice not found.");

    public static readonly AppError AlreadyExists =
        new("Invoice.AlreadyExists", "Invoice already exists.");

    public static readonly AppError CannotDelete =
        new("Invoice.CannotDelete", "Invoice cannot be deleted.");

    public static readonly AppError Conflict =
        new("Invoice.Conflict", "Invoice is in an invalid state.");
}

public static class Supplier
{
    public static readonly AppError NotFound =
        new("Supplier.NotFound", "Supplier not found.");

    public static readonly AppError AlreadyExists =
        new("Supplier.AlreadyExists", "Supplier already exists.");

    public static readonly AppError CannotDelete =
        new("Supplier.CannotDelete", "Supplier cannot be deleted.");

    public static readonly AppError InUse =
        new("Supplier.InUse", "Supplier is currently in use.");
}

public static class School
{
    public static readonly AppError NotFound =
        new("School.NotFound", "School not found.");

    public static readonly AppError AlreadyExists =
        new("School.AlreadyExists", "School already exists.");

    public static readonly AppError CannotDelete =
        new("School.CannotDelete", "School cannot be deleted.");

    public static readonly AppError InUse =
        new("School.InUse", "School is currently in use.");
}

public static class Product
{
    public static readonly AppError NotFound =
        new("Product.NotFound", "Product not found.");

    public static readonly AppError AlreadyExists =
        new("Product.AlreadyExists", "Product already exists.");

    public static readonly AppError CannotDelete =
        new("Product.CannotDelete", "Product cannot be deleted.");

    public static readonly AppError InUse =
        new("Product.InUse", "Product is currently in use.");
}