using BlazorModalDialogs.Definitions;

namespace BlazorModalDialogs.Utils
{
    internal static class Extensions
    {
        internal static string GetModalSizeClass(this ModalSize modalSize)
        {
            return modalSize switch
            {
                ModalSize.Small => "modal-sm",
                ModalSize.Large => "modal-lg",
                _ => "",
            };
        }
    }
}