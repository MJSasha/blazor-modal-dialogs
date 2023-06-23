namespace BlazorModalDialogs.Dialogs.InputDialog
{
    public class InputDialogParameters
    {
        public string Title { get; set; }
        public string Placeholder { get; set; }
        public string CompleteButton { get; set; } = "Ok";
        public string CancelButton { get; set; } = "Cancel";
    }
}
