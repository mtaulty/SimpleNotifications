using System.Linq;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace SimpleNotifications
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        void OnRegister()
        {
            if (!HasTask)
            {
                var builder = new BackgroundTaskBuilder();
                builder.Name = "Timer Task";

                // We ask for a 15 minute timer trigger which is the minimum.
                builder.SetTrigger(new TimeTrigger(15, false));
                builder.Register();
            }
        }
        void OnUnregister()
        {
            if (HasTask)
            {
                RegisteredTask.Unregister(false);
            }
        }
        static IBackgroundTaskRegistration RegisteredTask =>
            BackgroundTaskRegistration.AllTasks.Values.FirstOrDefault();
        
        static bool HasTask => 
            RegisteredTask != null;
    }
}