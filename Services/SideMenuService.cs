
namespace AppConcurso.Services
{
    public class SideMenuService : IDisposable
    {
        public bool collapseNavMenu { get; private set; } = false;

        public string? NavMenuCssClass => collapseNavMenu ? "w-0 overflow-hidden" : "w-[300px]";
        public string? NavMenuItemsCssClass => collapseNavMenu ? "" : "overflow-y-auto";
        public string? BodyCssClass => collapseNavMenu ? "grid grid-cols-[1fr]" : "grid grid-cols-[300px_1fr]";

        public event Action? OnChange;

        public void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
            Console.WriteLine("collapseNavMenu: " + collapseNavMenu);
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();

        public void Dispose()
        {
            OnChange = null;
        }
    }
}