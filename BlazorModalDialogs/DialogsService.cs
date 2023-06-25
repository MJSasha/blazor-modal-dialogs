using BlazorModalDialogs.Components;

namespace BlazorModalDialogs
{
    public class DialogsService
    {
        private List<object> dialogs = new();

        internal void RegisterDialog<TDialog>(TDialog dialog)
        {
            var registeredDialog = dialogs.SingleOrDefault(d => d.GetType() == typeof(TDialog));
            if (registeredDialog != null) throw new KeyNotFoundException($"Dialog ${typeof(TDialog)} already exist");
            dialogs.Add(dialog);
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
    }
}
