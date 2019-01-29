using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfApp.ViewModel
{
    class ViewModelNGPosition : BaseViewModel
    {
        private ICommand _mouseUpCommand;
        private ICommand _mouseDownCommand;
        private ICommand _mouseMoveCommand;
        public ViewModelNGPosition()
        {

        }

        public ICommand MouseUpCommand {
            get {
                if (_mouseUpCommand == null)
                    return _mouseUpCommand = new RelayCommand<MouseButtonEventArgs>(param => ExecuteMouseUp((MouseButtonEventArgs)param));
                return _mouseUpCommand;
            }
            set {
                _mouseUpCommand = value;
            }
        }
        public ICommand MouseDownCommand {
            get
            {
                if (_mouseDownCommand == null)
                    return _mouseDownCommand = new RelayCommand<MouseButtonEventArgs>(param => ExecuteMouseDown((MouseButtonEventArgs)param));
                return _mouseDownCommand;
            }
            set
            {
                _mouseDownCommand = value;
            }
        }

        public ICommand MouseMoveCommand
        {
            get
            {
                if (_mouseMoveCommand == null)
                    return _mouseMoveCommand = new RelayCommand<MouseEventArgs>(param => ExecuteMouseMove((MouseEventArgs)param));
                return _mouseMoveCommand;
            }
            set
            {
                _mouseMoveCommand = value;
            }
        }
        private void ExecuteMouseUp(MouseButtonEventArgs e)
        {
            Console.WriteLine("Mouse Up : " + e);
        }

        private void ExecuteMouseDown(MouseButtonEventArgs e)
        {
            Console.WriteLine("Mouse Down : " + e);
        }

        private void ExecuteMouseMove(MouseEventArgs e)
        {
            //Console.WriteLine("Mouse Move : " + e.GetPosition((IInputElement)e.Source));
        }
    }
}
