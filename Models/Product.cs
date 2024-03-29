﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models;

public partial class Product
{
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product Name is required")]
    [MaxLength(100, ErrorMessage = "ProductName must not exceed 100 characters")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Product Description is required")]
    [MaxLength(250, ErrorMessage = "Description must not exceed 250 characters")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Product Price is required")]
    [Range(0, 10000000, ErrorMessage = "Price must be a non-negative number and cannot exceed 10M")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "Product Quantity is required")]
    [Range(0, 10000000, ErrorMessage = "Quantity must be a non-negative number and cannot exceed 10M")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Product Status is required")]
    public int? productStatus { get; set; }

    [Required(ErrorMessage = "Product Image is required")]
    public string ImageUrl { get; set; }

    public int? ShopId { get; set; }

    [Range(1, 4, ErrorMessage = "Invalid Category value")]
    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<BillProduct> BillProducts { get; set; } = new List<BillProduct>();

    public virtual Shop? Shop { get; set; }
}
