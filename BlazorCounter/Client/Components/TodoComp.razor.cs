
using Microsoft.AspNetCore.Components;

namespace BlazorCounter.Client.Components;
public partial class TodoComp : ComponentBase
{
    [Parameter]
    public List<Models.TodoCli> ListaTodo {  get; set; }
    [Parameter]
    public Models.TodoCli TodoSingolo {  get; set; }
    [Parameter]
    public EventCallback<Models.TodoCli> OnSalva {  get; set; }
    [Parameter]
    public EventCallback<Models.TodoCli> OnElimina {  get; set; }
}
