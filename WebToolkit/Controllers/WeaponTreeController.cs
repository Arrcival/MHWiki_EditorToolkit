﻿using Microsoft.AspNetCore.Mvc;

namespace WebToolkit.Controllers
{
	[Route("WeaponTreeController")]
	public class WeaponTreeController : Controller
	{
		[HttpPost("GenerateTree")]
		public string GenerateTree(string json, string sharpnessBase, string weaponLink, int maxSharpnessCount, string pathName, string defaultIcon)
		{
			try
			{
				return MediawikiTranslator.Generators.WeaponTree.ParseJson(json, sharpnessBase, weaponLink, maxSharpnessCount, pathName, defaultIcon);
			}
			catch (Exception ex)
			{
				Response.Clear();
				Response.StatusCode = 500;
				Response.WriteAsync(ex.Message);
				return string.Empty;
			}
		}
	}
}
