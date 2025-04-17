using Avalonia.Media.Imaging;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace qrTest
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _inputText = string.Empty;
        private Bitmap? _qrImage;

        public event PropertyChangedEventHandler? PropertyChanged;

        public string InputText
        {
            get => _inputText;
            set
            {
                _inputText = value;
                OnPropertyChanged();
            }
        }

        public Bitmap? QrImage
        {
            get => _qrImage;
            set
            {
                _qrImage = value;
                OnPropertyChanged();
            }
        }

        public ICommand GenerateCommand => new RelayCommand(_ => GenerateQrCode());

        private void GenerateQrCode()
        {
            if (!string.IsNullOrWhiteSpace(InputText))
            {
                QrImage = qrTestService.Generate(InputText);
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action<object?> _execute;

        public RelayCommand(Action<object?> execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object? parameter) => true;

        public void Execute(object? parameter) => _execute(parameter);

        public event EventHandler? CanExecuteChanged
        {
            add { }
            remove { }
        }
    }
}