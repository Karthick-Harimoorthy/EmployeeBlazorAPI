using Microsoft.AspNetCore.Components;
using EmployeeBlazorAPI;

namespace GetEmployeeBlazor.Pages
{
    public partial class EmployeeList
    {
        [Inject]
        public IHttpClientFactory HttpClientFactory { 
            get; set; }
        private List<EmployeeData> employees { get; set; } = new();
        protected override async Task OnInitializedAsync()
        {
            var client = HttpClientFactory.CreateClient("api");
            var respone = await client.GetFromJsonAsync<IEnumerable<EmployeeData>>("api/employeedatas/getAllEmployee");
            employees = respone.ToList();
            await Task.CompletedTask;
        }
    }
}