namespace BlazorModalDialogs.Dialogs.MessageDialog
{
    public class MessageDialogParameters
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string CloseButtonText { get; set; } = "Ok";
    }
}
