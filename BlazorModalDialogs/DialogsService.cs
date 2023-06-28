using BlazorModalDialogs.Components;

namespace BlazorModalDialogs
{
    public class DialogsService
    {
        internal Type[] DialogsClasses { get; set; }

        private List<object> dialogs = new();

        public DialogsService(Type[] dialogsClasses)
        {
            DialogsClasses = dialogsClasses;
        }

        public Task<TResult> Show<TDialog, TParams, TResult>(TParams parameters) where TDialog : Dialog<TParams, TResult>
        {
            var dialog = dialogs.SingleOrDefault(d => d.GetType() == typeof(TDialog));
            if (dialog != null) return ((Dialog<TParams, TResult>)dialog).Show(parameters);
            else throw new KeyNotFoundException($"Dialog ${typeof(TDialog)} not found");
        }

        public void Hide<TDialog, TParams, TResult>() where TDialog : Dialog<TParams, TResult>
        {
            (dialogs.SingleOrDefault(d => d.GetType() == typeof(TDialog)) as TDialog).Hide();
        }

        internal void RegisterDialog<TDialog>(TDialog dialog)
        {
            var registeredDialog = dialogs.SingleOrDefault(d => d.GetType() == typeof(TDialog));
            if (registeredDialog == null)
            {
                dialogs.Add(dialog);
            }
        }
    }
}
