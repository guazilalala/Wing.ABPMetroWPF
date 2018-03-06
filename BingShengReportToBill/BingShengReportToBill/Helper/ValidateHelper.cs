using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BingShengReportToBill.Helper
{
	public class ValidateHelper
	{
		/// <summary>
		/// 验证配置信息
		/// </summary>
		public static bool ValidateConfig<T>(T config, out List<ValidationResult> validationResult)
		{
			var validationContext = new ValidationContext(config, serviceProvider: null, items: null);
			var results = new List<ValidationResult>();
			var isValid = Validator.TryValidateObject(config, validationContext, results, true);
			if (!isValid)
			{
				validationResult = results;
				return false;
			}
			validationResult = results;
			return true;
		}
	}

}

