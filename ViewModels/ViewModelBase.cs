// using ReactiveUI;
using System;
using System.ComponentModel;


namespace MirrorMirrorMvvm.ViewModels;

public class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        // Console.WriteLine(propertyName);
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
