using OrisonCollegePortal.Shared.Entities.General;

namespace OrisonCollegePortal.Client.Services
{
    public class ToastService
    {
        public event Action<ToastOption>? ShowToastTrigger;
        public void ShowToast(ToastOption options)
        {
            //Invoke ToastComponent to update and show the toast with messages  
            this.ShowToastTrigger?.Invoke(options);
        }
        public void ToastError(string msg)
        {
            this.ShowToast(new ToastOption()
            {
                Title = "Something went wrong...",
                Content = msg,
                CssClass = "e-toast-danger",
                Icon = "e-error toast-icons",
                Timeout = 3000,
                X = "Right",
                Y = "Top",
                CloseButton = true
            });
        }
        public void ToastSuccess(string msg)
        {
            this.ShowToast(new ToastOption()
            {
                Title = "Success",
                Content = msg,
                CssClass = "e-toast-success",
                Icon = "e-success toast-icons",
                Timeout = 3000,
                X = "Right",
                Y = "Top",
                CloseButton = true
            });
        }
    }
}
