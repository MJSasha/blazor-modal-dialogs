using BlazorModalDialogs.Components;

namespace BlazorModalDialogs
{
    public class DialogsService
    {
        private List<object> Dialogs = new List<object>();

        public void RegisterDialog<TDialog>(TDialog dialog)
        {
            var registeredDialog = Dialogs.Where(d => d.GetType() == typeof(TDialog)).SingleOrDefault();
            if (registeredDialog != null) Dialogs.Remove(registeredDialog);
            Dialogs.Add(dialog);
        }

        public Task<TResult> Show<TDialog, TParams, TResult>(TParams parameters) where TDialog : Dialog<TParams, TResult>
        {
            var dialog = Dialogs.Where(d => d.GetType() == typeof(TDialog)).SingleOrDefault();
            if (dialog != null) return ((Dialog<TParams, TResult>)dialog).Show(parameters);
            else throw new KeyNotFoundException($"Dialog ${typeof(TDialog)} not found");
        }

        public void Close<TDialog, TParams, TResult>() where TDialog : Dialog<TParams, TResult>
        {
            (Dialogs.SingleOrDefault(d => d.GetType() == typeof(TDialog)) as TDialog).Hide();
        }
    }
}
