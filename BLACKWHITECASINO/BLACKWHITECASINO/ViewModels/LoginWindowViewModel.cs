using BetClass;
using BLACKWHITECASINO.Data;
using BLACKWHITECASINO.Infrastructure.Commands;
using BLACKWHITECASINO.Models;
using BLACKWHITECASINO.ViewModels.Base;
using BLACKWHITECASINO.Views;
using BLACKWHITECASINO.Views.Windows;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TotalClass;

namespace BLACKWHITECASINO.ViewModels
{
    internal class LoginWindowViewModel : ViewModel
    {
        public Window RegisterWindow { get; set; }
        public Window MainWindow { get; set; }
        public Window AdminWindow { get; set; }
        public Window ForgotPasswordWindow { get; set; }
        public Window ChangePasswordWindow { get; set; }

        public User thisUser { get; set; }
        public string Code { get; set; }

        #region UserLoginLog
        private string _UserLoginLog;

        public string UserLoginLog
        {
            get => _UserLoginLog;
            set => Set(ref _UserLoginLog, value);
        }
        #endregion

        #region UserPasswordLog
        private string _UserPasswordLog;

        public string UserPasswordLog
        {
            get => _UserPasswordLog;
            set => Set(ref _UserPasswordLog, value);
        }
        #endregion

        #region RegisterSwapCommand
        public ICommand RegisterSwapCommand { get; }

        private bool CanRegisterSwapCommandExecuted(object p) => true;

        private void OnRegisterSwapCommandExecuted(object p)
        {
            RegisterWindow = new RegisterWindow();
            RegisterWindow.DataContext = new RegisterWindowViewModel(this);
            var LogWin = p as Window;

            LogWin.Close();
            RegisterWindow.ShowDialog();
            
            
        }
        #endregion

        #region ForgotPasswordCommand
        public ICommand ForgotPasswordCommand { get; }

        private bool CanForgotPasswordCommandExecuted(object p) => true;

        private void OnForgotPasswordCommandExecuted(object p)
        {


            ForgotPasswordWindow = new ForgotPassword();
            ForgotPasswordWindow.DataContext = new ForgotPasswordViewModel(this);
            var LogWin = p as Window;

            LogWin.Close();
            ForgotPasswordWindow.ShowDialog();


        }
        #endregion

        #region EnterCommand
        public ICommand EnterCommand { get; }

        private bool CanEnterCommandExecuted(object p) => true;

        private void OnEnterCommandExecuted(object p)
        {
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
            var LogWin = p as Window;
            

            try
            {
                if (UserLoginLog == null || UserPasswordLog == null)
                {
                    if (Language.checkRu == true)
                        throw new Exception("Введите все значения!");
                    else
                        throw new Exception("Enter all values!");
                }
                    

                ActiveUser.activeUser = context.Users.Where(u => u.Login == UserLoginLog).FirstOrDefault();

                if (ActiveUser.activeUser == null)
                {
                    if (Language.checkRu == true)
                        throw new Exception("Аккаунта с таким логином не существует!");
                    else
                        throw new Exception("There is no account with this username!");

                }


                var passCheck = HashPassword.Hash(UserPasswordLog);
                if (ActiveUser.activeUser.Password == passCheck)
                {
                    if (ActiveUser.activeUser.Role == "admin")
                    {
                        AdminWindow = new AdminWindow();
                        LogWin.Close();
                        AdminWindow.Show();
                    }
                    else if (ActiveUser.activeUser.Role == "user")
                    {
                        MainWindow = new MainWindow();
                        LogWin.Close();
                        MainWindow.Show();
                    }
                    else if (ActiveUser.activeUser.Role == "banned")
                    {
                        if (Language.checkRu == true)
                            MessageBox.Show("Ваш аккаунт забанен!");
                        else
                            MessageBox.Show("Your account has been banned!");
                    }
                }
                else
                {
                    if (Language.checkRu == true)
                    {
                        MessageBox.Show("Пароль не верный!");
                    }
                    else
                        MessageBox.Show("Wrong password!");
                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        public LoginWindowViewModel(/*MainWindowViewModel mWindowVW*/)
        {
            //this.mWindowVW = mWindowVW;
            #region Команды
            EnterCommand = new LambdaCommand(OnEnterCommandExecuted, CanEnterCommandExecuted);
            RegisterSwapCommand = new LambdaCommand(OnRegisterSwapCommandExecuted, CanRegisterSwapCommandExecuted);
            ForgotPasswordCommand = new LambdaCommand(OnForgotPasswordCommandExecuted, CanForgotPasswordCommandExecuted);
            #endregion
        }

    }
}
