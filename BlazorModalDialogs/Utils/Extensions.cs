using BlazorModalDialogs.Definitions;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorModalDialogs
{
    public static class Extensions
    {
        public static IServiceCollection AddModalDialogs(this IServiceCollection serviceDescriptors, params Type[] dialogsClasses)
        {
            return serviceDescriptors.AddSingleton<DialogsService>(sp => new(dialogsClasses));
        }

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