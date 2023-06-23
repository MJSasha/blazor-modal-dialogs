using Microsoft.AspNetCore.Components;

namespace BlazorModalDialogs.Components
{
    public partial class Dialog<TParam, TResult> : ComponentBase
    {
        [Inject]
        public DialogsService DialogsService { get; set; }

        [Parameter]
        public RenderFragment ChildContent { get; set; }

        public TParam Params { get; set; }

        public bool IsDisplayed { get; set; }

        private TaskCompletionSource<TResult> taskCompletionSource;

        protected override void OnInitialized()
        {
            DialogsService.RegisterDialog(this);
        }

        protected virtual void OnAfterShow() { }

        protected virtual void OnBeforeClose() { }

        public Task<TResult> Show(TParam parameters)
        {
            taskCompletionSource = new TaskCompletionSource<TResult>();
            Params = parameters;
            IsDisplayed = true;
            OnAfterShow();
            StateHasChanged();
            return taskCompletionSource.Task;
        }

        public void Hide()
        {
            IsDisplayed = false;
            StateHasChanged();
        }

        public virtual void Close(TResult result)
        {
            OnBeforeClose();
            IsDisplayed = false;
            taskCompletionSource.SetResult(result);
            StateHasChanged();
        }

        public virtual void Cancel()
        {
            IsDisplayed = false;
            taskCompletionSource.SetCanceled();
            StateHasChanged();
        }
    }
}