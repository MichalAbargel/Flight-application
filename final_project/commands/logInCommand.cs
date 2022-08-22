using final_project.viewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace final_project.commands
{
    public class LogInCommand : ICommand
    {
        private flightsViewModel vm;
        public LogInCommand(flightsViewModel _vm)
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
            //this.vm.password = password;
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
            //log in action
            bool loginflag = this.vm.usesrIslogin;
            if (!loginflag)
            {
                if (this.vm.accountModel.logIn())
                {
                    this.vm.usesrIslogin = true;
                    this.vm.islogIn = false;
                    //show messege
                    this.vm.sendMessage = "welcome back " + this.vm.accountModel.userName + "!";
                    this.vm.messageVisibility = true;
                }
                else
                {
                    //show messege
                    this.vm.islogIn = false;
                    this.vm.sendMessage = "you are not sign in, please sing in and join us!";
                    this.vm.messageVisibility = true;
                }
            }
            else
            {
                //show messege
                this.vm.islogIn = false;
                this.vm.sendMessage = "you are already log in";
                this.vm.messageVisibility = true;
            }


        }
    }
}
