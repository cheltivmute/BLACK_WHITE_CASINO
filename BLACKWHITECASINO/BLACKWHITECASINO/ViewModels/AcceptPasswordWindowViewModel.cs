using BetClass;
using BLACKWHITECASINO.Data;
using BLACKWHITECASINO.Infrastructure.Commands;
using BLACKWHITECASINO.Models;
using BLACKWHITECASINO.ViewModels.Base;
using BLACKWHITECASINO.Views.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TotalClass;

namespace BLACKWHITECASINO.ViewModels
{
    internal class AcceptPasswordWindowViewModel : ViewModel
    {

        //PasswordText
        #region PasswordText
        private string _PasswordText;

        public string PasswordText
        {
            get
            {
                return _PasswordText;
            }
            set
            {

                Set(ref _PasswordText, value);
            }
        }
        #endregion

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecuted(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            accWindowVW.CloseAcceptPasswordWindow();
        }
        #endregion

        #region AcceptApplicationCommand
        public ICommand AcceptApplicationCommand { get; }

        private bool CanAcceptApplicationCommandExecuted(object p) => true;

        private void OnAcceptApplicationCommandExecuted(object p)
        {
            BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();

            try
            {
                if (PasswordText == null)
                    throw new Exception("Введите значение!");
                var hashP = HashPassword.Hash(PasswordText);
                if (ActiveUser.activeUser.Password == hashP)
                {
                    accWindowVW.ChangeWindow = new ChangeWindow();
                    accWindowVW.ChangeWindow.DataContext = new ChangeWindowViewModel(accWindowVW);
                    accWindowVW.ChangeWindow.ShowDialog();
                    accWindowVW.CloseAcceptPasswordWindow();
                }
                else
                    MessageBox.Show("Пароль не верный!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private AccountWindowViewModel accWindowVW;

        public AcceptPasswordWindowViewModel(AccountWindowViewModel accWindowVW)
        {
            this.accWindowVW = accWindowVW;
            #region Команды
            AcceptApplicationCommand = new LambdaCommand(OnAcceptApplicationCommandExecuted, CanAcceptApplicationCommandExecuted);
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecuted);
            #endregion
        }


    }
}
