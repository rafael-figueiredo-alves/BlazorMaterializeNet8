using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace BlazorMaterializeNet8.Components.Pages
{
    public class EditorBase : ComponentBase
    {
        [Inject] protected IJSRuntime? JSRuntime { get; set; }

        protected string strSavedContent = "";
        protected ElementReference divEditorElement;
        protected string? EditorContent { get; set; }
        protected string? EditorHTMLContent { get; set; }
        protected bool EditorEnabled { get; set; } = true;

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await JSRuntime!.InvokeAsync<string>(
                    "QuillFunctions.createQuill", divEditorElement);
            }
        }
        protected async Task GetText()
        {
            EditorHTMLContent = "";
            EditorContent = await JSRuntime!.InvokeAsync<string>(
                "QuillFunctions.getQuillText", divEditorElement);
        }
        protected async Task GetHTML()
        {
            EditorContent = "";
            EditorHTMLContent = await JSRuntime!.InvokeAsync<string>(
                "QuillFunctions.getQuillHTML", divEditorElement);
        }
        protected async Task GetEditorContent()
        {
            EditorHTMLContent = "";
            EditorContent = await JSRuntime!.InvokeAsync<string>(
                "QuillFunctions.getQuillContent", divEditorElement);
        }
        protected async Task SaveContent()
        {
            strSavedContent = await JSRuntime!.InvokeAsync<string>(
                "QuillFunctions.getQuillContent", divEditorElement);
        }
        protected async Task LoadContent()
        {
            var QuillDelta = await JSRuntime!.InvokeAsync<object>(
                "QuillFunctions.loadQuillContent", divEditorElement, strSavedContent);
        }
        protected async Task DisableQuillEditor()
        {
            EditorEnabled = false;
            await JSRuntime!.InvokeAsync<object>(
                "QuillFunctions.disableQuillEditor", divEditorElement);
        }
    }
}
