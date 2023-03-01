using BetClass;
using BLACKWHITECASINO.Data;
using BLACKWHITECASINO.Infrastructure.Commands;
using BLACKWHITECASINO.Models;
using BLACKWHITECASINO.ViewModels.Base;
using BLACKWHITECASINO.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TotalClass;

namespace BLACKWHITECASINO.ViewModels
{
    internal class AccountWindowViewModel : ViewModel
    {
        public string LabelTextChange { get; set; }
        public int PasswordCheckNum { get; set; }
        public Window AcceptPasswordWindow { get; set; }
        public Window ChangeWindow { get; set; }
        BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
        public ObservableCollection<DataGame> DataGames;
        public ObservableCollection<DataTran> DataTransactions;

        #region DataItemsSource

        public ObservableCollection<DataGame> DataItemsSource
        {
            get
            {
                DataGames = new ObservableCollection<DataGame>();

                foreach (Game game in context.Games)
                {
                    if (game.UserId == ActiveUser.activeUser.Id)
                    {
                        DataGames.Add(new DataGame() { DataGameId = game.UserGameId.ToString(), DataGameName = game.Name.ToString(), DataGameBet = game.Bet.ToString(), DataGameResult = game.Result.ToString(), DataGameProfit = game.Profit.ToString(), DataGameDate = game.Date.ToString()});
                    }
                }

                DataGames = new ObservableCollection<DataGame>(DataGames.OrderByDescending(u => u.DataGameId));
                return DataGames;
            }

            set => Set(ref DataGames, value);
        }
        #endregion

        #region DataTranItemsSource

        public ObservableCollection<DataTran> DataTranItemsSource
        {
            get
            {
                DataTransactions = new ObservableCollection<DataTran>();

                foreach (Transaction tran in context.Transactions)
                {
                    if (tran.UserId == ActiveUser.activeUser.Id)
                    {
                        DataTransactions.Add(new DataTran() { DataTranId = tran.UserTransactionId.ToString(), DataTranOperation = tran.Operation.ToString(), DataTranSumm = tran.Summ.ToString(), DataTranTotalBef = tran.TotalBefore.ToString(), DataTranTotalAf = tran.TotalAfter.ToString(), DataTranDate = tran.Date.ToString() });
                    }
                }
                DataTransactions = new ObservableCollection<DataTran>(DataTransactions.OrderByDescending(u => u.DataTranId));
                return DataTransactions;
            }

            set => Set(ref DataTransactions, value);
        }
        #endregion

        #region AccountLogin
        private string _AccountLogin = Convert.ToString(ActiveUser.activeUser.Login);

        public string AccountLogin
        {
            get
            {
                return _AccountLogin;
            }
            set => Set(ref _AccountLogin, value);
        }
        #endregion
        #region AccountMail
        private string _AccountMail = Convert.ToString(ActiveUser.activeUser.Email);

        public string AccountMail
        {
            get
            {
                return _AccountMail;
            }
            set => Set(ref _AccountMail, value);
        }
        #endregion
        #region AccountPassword
        private string _AccountPassword = Convert.ToString(ActiveUser.activeUser.Password);

        public string AccountPassword
        {
            get
            {
                return _AccountPassword;
            }
            set => Set(ref _AccountPassword, value);
        }
        #endregion
        #region AccountMobile
        private string _AccountMobile = Convert.ToString(ActiveUser.activeUser.Mobile);

        public string AccountMobile
        {
            get
            {
                return _AccountMobile;
            }
            set => Set(ref _AccountMobile, value);
        }
        #endregion
        #region AccountDate
        private string _AccountDate = Convert.ToString(ActiveUser.activeUser.BirthDay.Day) + "." + Convert.ToString(ActiveUser.activeUser.BirthDay.Month) + "." + Convert.ToString(ActiveUser.activeUser.BirthDay.Year) + " (" + Convert.ToString(ActiveUser.AgeFind(ActiveUser.activeUser.BirthDay)) + " лет)";

        public string AccountDate
        {
            get
            {
                return _AccountDate;
            }
            set => Set(ref _AccountDate, value);
        }
        #endregion

        public void CloseAcceptPasswordWindow()
        {
            AcceptPasswordWindow.Close();
        }

        public void CloseChangeWindow()
        {
            ChangeWindow.Close();
        }



        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecuted(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            //mWindowVW.CloseAccountWindow();
        }
        #endregion

        #region AcceptApplicationCommand
        public ICommand AcceptApplicationCommand { get; }

        private bool CanAcceptApplicationCommandExecuted(object p) => true;

        private void OnAcceptApplicationCommandExecuted(object p)
        {
        }
        #endregion

        #region ChangeLoginCommand
        public ICommand ChangeLoginCommand { get; }

        private bool CanChangeLoginCommandExecuted(object p) => true;

        private void OnChangeLoginCommandExecuted(object p)
        {
            AcceptPasswordWindow = new AcceptPasswordWindow();
            AcceptPasswordWindow.DataContext = new AcceptPasswordWindowViewModel(this);
            PasswordCheckNum = 1;
            if(Language.checkRu == true)
                LabelTextChange = "Введите новый логин";
            else
                LabelTextChange = "Enter a new username";
            AcceptPasswordWindow.ShowDialog();
        }
        #endregion

        #region ChangeMailCommand
        public ICommand ChangeMailCommand { get; }

        private bool CanChangeMailCommandExecuted(object p) => true;

        private void OnChangeMailCommandExecuted(object p)
        {
            AcceptPasswordWindow = new AcceptPasswordWindow();
            AcceptPasswordWindow.DataContext = new AcceptPasswordWindowViewModel(this);
            PasswordCheckNum = 2;
            if(Language.checkRu == true)
                LabelTextChange = "Введите новый почту";
            else
                LabelTextChange = "Enter a new mail";
            AcceptPasswordWindow.ShowDialog();
        }
        #endregion

        #region ChangePasswordCommand
        public ICommand ChangePasswordCommand { get; }

        private bool CanChangePasswordCommandExecuted(object p) => true;

        private void OnChangePasswordCommandExecuted(object p)
        {
            AcceptPasswordWindow = new AcceptPasswordWindow();
            AcceptPasswordWindow.DataContext = new AcceptPasswordWindowViewModel(this);
            PasswordCheckNum = 3;
            if(Language.checkRu == true)
                LabelTextChange = "Введите новый пароль";
            else
                LabelTextChange = "Enter a new password";

            AcceptPasswordWindow.ShowDialog();
        }
        #endregion

        #region ChangeMobileCommand
        public ICommand ChangeMobileCommand { get; }

        private bool CanChangeMobileCommandExecuted(object p) => true;

        private void OnChangeMobileCommandExecuted(object p)
        {
            AcceptPasswordWindow = new AcceptPasswordWindow();
            AcceptPasswordWindow.DataContext = new AcceptPasswordWindowViewModel(this);
            PasswordCheckNum = 4;
            if(Language.checkRu == true)
                LabelTextChange = "Введите новый телефон";
            else
                LabelTextChange = "Enter a new mobile";
            AcceptPasswordWindow.ShowDialog();
        }
        #endregion

        #region ChangeBDCommand
        public ICommand ChangeBDCommand { get; }

        private bool CanChangeBDCommandExecuted(object p) => true;

        private void OnChangeBDCommandExecuted(object p)
        {
            AcceptPasswordWindow = new AcceptPasswordWindow();
            AcceptPasswordWindow.DataContext = new AcceptPasswordWindowViewModel(this);
            PasswordCheckNum = 5;
            if(Language.checkRu == true)
                LabelTextChange = "Введите дату рождения";
            else
                LabelTextChange = "Enter a date of birth";

            AcceptPasswordWindow.ShowDialog();
        }
        #endregion

        /*private MainWindowViewModel mWindowVW;*/

        public AccountWindowViewModel(/*MainWindowViewModel mWindowVW*/)
        {
            //this.mWindowVW = mWindowVW;
            #region Команды
            //AcceptApplicationCommand = new LambdaCommand(OnAcceptApplicationCommandExecuted, CanAcceptApplicationCommandExecuted);
            //CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecuted);
            ChangeLoginCommand = new LambdaCommand(OnChangeLoginCommandExecuted, CanChangeLoginCommandExecuted);
            ChangeMailCommand = new LambdaCommand(OnChangeMailCommandExecuted, CanChangeMailCommandExecuted);
            ChangePasswordCommand = new LambdaCommand(OnChangePasswordCommandExecuted, CanChangePasswordCommandExecuted);
            ChangeMobileCommand = new LambdaCommand(OnChangeMobileCommandExecuted, CanChangeMobileCommandExecuted);
            ChangeBDCommand = new LambdaCommand(OnChangeBDCommandExecuted, CanChangeBDCommandExecuted);
            #endregion
        }

    }
}
