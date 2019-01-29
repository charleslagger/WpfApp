using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.ViewModel
{
    class ViewModelNGPosition : BaseViewModel
    {
        private double x1;
        private double x2;
        private double y1;
        private double y2;
        //private ObservableCollection<Rectangle> listRect;
        private ICommand _mouseLeftButtonDownCommand;
        public ICommand MouseLeftButtonDownCommand
        {
            get
            {
                if (_mouseLeftButtonDownCommand == null) return _mouseLeftButtonDownCommand = new RelayCommand<object>(param => ExecuteMouseLeftButtonDown((MouseButtonEventArgs)param));
                return _mouseLeftButtonDownCommand;
            }
            set { _mouseLeftButtonDownCommand = value; }
        }

        public void ExecuteMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            x1 = e.GetPosition((IInputElement)e.Source).X;
            y1 = e.GetPosition((IInputElement)e.Source).Y;
            Console.WriteLine("Mouse Down X: " + e.GetPosition((IInputElement)e.Source).X);
            Console.WriteLine("Mouse Down Y: " + e.GetPosition((IInputElement)e.Source).Y);
        }

        private ICommand _mouseMoveCommand;
        public ICommand MouseMoveCommand
        {
            get
            {
                if (_mouseMoveCommand == null) return _mouseMoveCommand = new RelayCommand<object>(param => ExecuteMouseMove((MouseEventArgs)param));
                return _mouseMoveCommand;
            }
            set { _mouseMoveCommand = value; }
        }

        private void ExecuteMouseMove(MouseEventArgs e)
        {
            //Console.WriteLine("Mouse Move X: " + e.GetPosition((IInputElement)e.Source).X);
            //Console.WriteLine("Mouse Move Y: " + e.GetPosition((IInputElement)e.Source).Y);
        }

        private ICommand _mouseLeftButtonUpCommand;
        public ICommand MouseLeftButtonUpCommand
        {
            get
            {
                if (_mouseLeftButtonUpCommand == null) return _mouseLeftButtonUpCommand = new RelayCommand<object>(param => ExecuteMouseLeftButtonUp((MouseButtonEventArgs)param));
                return _mouseLeftButtonUpCommand;
            }
            set { _mouseLeftButtonUpCommand = value; }
        }

        public void ExecuteMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            if(x1 < Math.Min(x1, e.GetPosition((IInputElement)e.Source).X))
            {
                x1 = Math.Min(x1, e.GetPosition((IInputElement)e.Source).X);
            }
            else
            {
                x2 = e.GetPosition((IInputElement)e.Source).X;
            }

            if (y1 < Math.Min(y1, e.GetPosition((IInputElement)e.Source).Y))
            {
                y1 = Math.Min(x1, e.GetPosition((IInputElement)e.Source).Y);
            }
            else
            {
                y2 = e.GetPosition((IInputElement)e.Source).Y;
            }

            Console.WriteLine("e.GetPosition((IInputElement)e.Source).X: " + e.GetPosition((IInputElement)e.Source).X);
            Console.WriteLine("e.GetPosition((IInputElement)e.Source).Y: " + e.GetPosition((IInputElement)e.Source).Y);
            Console.WriteLine("X1: " + x1);
            Console.WriteLine("X2: " + x2);
            Console.WriteLine("Y1: " + y1);
            Console.WriteLine("Y2: " + y2);
        }

        private int position;
        public ICommand ButtonClickCommand { get; set; }

        public int Position { get => position; set
            {
                position = value;
                OnPropertyChanged();
            }
        }

        public ViewModelNGPosition()
        {
            position = 0;
            ButtonClickCommand = new RelayCommand<object>((p) => true, ButtonClick);
        }

        public void ButtonClick(object parameter)
        {
            Position = 2;
            Console.WriteLine("==>>Here");
        }
    }
}
