using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Headers;
using Microsoft.Ajax.Utilities;

namespace ContactOperations
{
	public static class GlobalVariables
	{
		

		
		public static HttpClient webApiClient = new HttpClient();
		static GlobalVariables()
		{
			webApiClient.BaseAddress = new Uri("https://localhost:44378/api/");
			webApiClient.DefaultRequestHeaders.Clear();
			webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/plain"));
			
		}
	}
}