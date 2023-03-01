using BetClass;
using BLACKWHITECASINO.Data;
using BLACKWHITECASINO.Infrastructure.Commands;
using BLACKWHITECASINO.Models;
using BLACKWHITECASINO.ViewModels.Base;
using BLACKWHITECASINO.Views.Windows;
using Microsoft.EntityFrameworkCore;
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
    internal class AdminWindowViewModel : ViewModel
    {
        BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
        public ObservableCollection<DataAdmin> DataUsers;

        #region DataAdminItemsSource

        public ObservableCollection<DataAdmin> DataAdminItemsSource
        {
            get
            {
                DataUsers = new ObservableCollection<DataAdmin>();

                foreach (User user in context.Users)
                {
                    DataUsers.Add(new DataAdmin() { DataAdminId = user.Id.ToString(), DataAdminLogin = user.Login.ToString(), DataAdminEmail = user.Email.ToString(), DataAdminMobile = user.Mobile.ToString(), DataAdminTotal = user.Total.ToString(), DataAdminGames = user.GameQuantity.ToString(), DataAdminTrans = user.TransactionQuantity.ToString(), DataAdminBD = user.BirthDay.ToString() });
                }
                DataUsers = new ObservableCollection<DataAdmin>(DataUsers.OrderByDescending(u => u.DataAdminId));
                return DataUsers;
            }

            set => Set(ref DataUsers, value);
        }
        #endregion
        #region SelectedUser

        private DataAdmin _SelectedUser;

        public DataAdmin SelectedUser
        {
            get
            {   
                return _SelectedUser;
            }

            set => Set(ref _SelectedUser, value);
        }
        #endregion

        #region BanUserCommand
        public ICommand BanUserCommand { get; }

        private bool CanBanUserCommandExecuted(object p) => true;

        private void OnBanUserCommandExecuted(object p)
        {
            foreach (User us in context.Users)
            {
                if(us.Id == Convert.ToInt32(SelectedUser.DataAdminId) && us.Login == SelectedUser.DataAdminLogin)
                {
                    BLACK_WHITE_CASINOContext contxt = new BLACK_WHITE_CASINOContext();
                    us.Role = "banned";
                    contxt.Entry(us).State = EntityState.Modified;
                    contxt.SaveChanges();
                    if (Language.checkRu == true)
                        MessageBox.Show("Аккаунт успешно забанен!");
                    else
                        MessageBox.Show("Account successfully banned!");
                }
            }

            
        }
        #endregion
        #region UnBanUserCommand
        public ICommand UnBanUserCommand { get; }

        private bool CanUnBanUserCommandExecuted(object p) => true;

        private void OnUnBanUserCommandExecuted(object p)
        {
            foreach (User us in context.Users)
            {
                if (us.Id == Convert.ToInt32(SelectedUser.DataAdminId) && us.Login == SelectedUser.DataAdminLogin)
                {
                    BLACK_WHITE_CASINOContext contxt = new BLACK_WHITE_CASINOContext();
                    us.Role = "user";
                    contxt.Entry(us).State = EntityState.Modified;
                    contxt.SaveChanges();
                    if (Language.checkRu == true)
                        MessageBox.Show("Аккаунт успешно разбанен!");
                    else
                        MessageBox.Show("Account successfully unbanned!");
                }
            }


        }
        #endregion
        #region DeleteUserCommand
        public ICommand DeleteUserCommand { get; }

        private bool CanDeleteUserCommandExecuted(object p) => true;

        private void OnDeleteUserCommandExecuted(object p)
        {
            foreach (User us in context.Users)
            {
                if (us.Id == Convert.ToInt32(SelectedUser.DataAdminId) && us.Login == SelectedUser.DataAdminLogin)
                {
                    BLACK_WHITE_CASINOContext contxt = new BLACK_WHITE_CASINOContext();

                    foreach(Game game in contxt.Games)
                    {
                        if(game.UserId == us.Id)
                        {
                            contxt.Games.Remove(game);
                        }

                        
                    }

                    foreach (Transaction tran in contxt.Transactions)
                    {
                        if (tran.UserId == us.Id)
                        {
                            contxt.Transactions.Remove(tran);
                        }
                    }

                    contxt.Users.Remove(us);
                    
                    

                    contxt.SaveChanges();
                }
            }


        }
        #endregion

        #region ExitAdmin
        public ICommand ExitAdminCommand { get; }

        private bool CanExitAdminCommandExecuted(object p) => true;

        private void OnExitAdminCommandExecuted(object p)
        {
            var mnWin = p as Window;
            LoginWindow loginWin = new LoginWindow();

            ActiveUser.activeUser = null;

            mnWin.Close();
            loginWin.ShowDialog();
        }
        #endregion


        public AdminWindowViewModel()
        {
            #region Команды

            BanUserCommand = new LambdaCommand(OnBanUserCommandExecuted, CanBanUserCommandExecuted);
            UnBanUserCommand = new LambdaCommand(OnUnBanUserCommandExecuted, CanUnBanUserCommandExecuted);
            DeleteUserCommand = new LambdaCommand(OnDeleteUserCommandExecuted, CanDeleteUserCommandExecuted);
            ExitAdminCommand = new LambdaCommand(OnExitAdminCommandExecuted, CanExitAdminCommandExecuted);

            #endregion
        }
    }
}
