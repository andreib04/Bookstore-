using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel;

namespace bookstore.api.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Password { get; set; } = string.Empty;

		[SwaggerSchema("User role, defaults to 'Member'")]
		[JsonProperty(DefaultValueHandling = DefaultValueHandling.Populate)]
		[DefaultValue("Member")]
		public string Role { get; set; } = "Member";
		public DateTime Date {  get; set; }
	}
}
