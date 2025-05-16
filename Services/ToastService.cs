using System.Timers;

namespace AppConcurso.Services
{
    public enum ToastType
    {
        Success,
        Error,
        Warning
    }

    public class ToastMessage
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Message { get; set; } = string.Empty;
        public ToastType Type { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }

    public class ToastService : IDisposable
    {
        public event Action<ToastMessage>? OnShow;
        public event Action<Guid>? OnHide;
        
        private System.Timers.Timer? _timer;
        private List<ToastMessage> _activeToasts = new();
        
        public void ShowToast(string message, ToastType type)
        {
            var toast = new ToastMessage
            {
                Message = message,
                Type = type
            };
            
            _activeToasts.Add(toast);
            OnShow?.Invoke(toast);
            
            SetTimer(toast.Id);
        }
        
        public void ShowSuccess(string message)
        {
            ShowToast(message, ToastType.Success);
        }
        
        public void ShowError(string message)
        {
            ShowToast(message, ToastType.Error);
        }
        
        public void ShowWarning(string message)
        {
            ShowToast(message, ToastType.Warning);
        }
        
        public void HideToast(Guid id)
        {
            var toast = _activeToasts.FirstOrDefault(t => t.Id == id);
            if (toast != null)
            {
                _activeToasts.Remove(toast);
                OnHide?.Invoke(id);
            }
        }
        
        private void SetTimer(Guid toastId)
        {
            _timer = new System.Timers.Timer(5000);
            _timer.Elapsed += (sender, args) => OnTimerElapsed(sender, args, toastId);
            _timer.AutoReset = false;
            _timer.Enabled = true;
        }
        
        private void OnTimerElapsed(object? sender, ElapsedEventArgs args, Guid toastId)
        {
            HideToast(toastId);
        }
        
        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
} 