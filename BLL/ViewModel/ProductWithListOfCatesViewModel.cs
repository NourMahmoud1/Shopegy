﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Shopegy.Models;
using Microsoft.AspNetCore.Http;

namespace BLL.ViewModel;

public class ProductWithListOfCatesViewModel
{
	public int Id { get; set; }

	public string Name { get; set; }

	[DisplayFormat(NullDisplayText = "No Description yet")]
	public string? Description { get; set; }

	public string ImageUrl { get; set; } = "wwwroot/images/sfdsdf";  // default image

	[NotMapped]
	public IFormFile image { get; set; }


	[Column(TypeName = "Money")]
	public decimal Price { get; set; }

	public int Quantity { get; set; }

	public string Color { get; set; }

	// we want to make array of colors for each product
	//public int MyProperty { get; set; }

	[DisplayFormat(NullDisplayText = "No Rating yet")]
	[Column(TypeName = "Money")]

	public decimal? Rating { get; set; }

	//----------------------------------

	[ForeignKey("Category")]
	

	public List<ProductCategorie>? categories { get; set; }
    public int CategoryId { get; set; }
}
   
