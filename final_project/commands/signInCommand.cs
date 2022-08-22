using final_project.viewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace final_project.commands
{
    public class SignInCommand : ICommand
    {
        private flightsViewModel vm;
        public SignInCommand(flightsViewModel _vm)
        {
            vm = _vm;
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            //var passwordBox = parameter as PasswordBox;
            //string password = passwordBox.Password;
            //if (this.vm.userName == "" || this.vm.password == "")
            //{
            //    return false;
            //}
            return true;

        }

        public void Execute(object parameter)
        {
            var passwordBox = parameter as PasswordBox;
            string password = passwordBox.Password;
            this.vm.password = password;
            
            if (this.vm.accountModel.alreadyExist())
            {
                this.vm.sendMessage = "this account is already exist, pleas log in";
                this.vm.messageVisibility = true;
            }
            else
            {
                this.vm.accountModel.signIn();
                this.vm.IsSignIn = false;
                this.vm.usesrIslogin = true;
                //show messege
                this.vm.sendMessage = "Hye " + this.vm.accountModel.userName;
                this.vm.messageVisibility = true;
            }
        }
    }
}
