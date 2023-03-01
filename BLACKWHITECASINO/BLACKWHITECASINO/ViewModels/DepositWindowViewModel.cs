using BetClass;
using BLACKWHITECASINO.Data;
using BLACKWHITECASINO.Infrastructure.Commands;
using BLACKWHITECASINO.Models;
using BLACKWHITECASINO.ViewModels.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TotalClass;

namespace BLACKWHITECASINO.ViewModels
{
    internal class DepositWindowViewModel : ViewModel
    {
        public double totalBef { get; set; }

        #region Значение
        private int _CountBetValue = 99999;

        public int CountBetValue
        {
            get => _CountBetValue;
            set => Set(ref _CountBetValue, value);
        }
        #endregion

        #region DepText
        private string _DepText;

        public string DepText
        {
            get
            {
                _DepText = mWindowVW.DepTextMain;
                return _DepText;
            }
            set => Set(ref _DepText, value);
        }
        #endregion

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecuted(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            mWindowVW.CloseDepositWindow();
        }
        #endregion

        #region AcceptApplicationCommand
        public ICommand AcceptApplicationCommand { get; }

        private bool CanAcceptApplicationCommandExecuted(object p) => true;

        private void OnAcceptApplicationCommandExecuted(object p)
        {
            try
            {
                if (mWindowVW.checkDep == true)
                {
                    BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
                    totalBef = Total.TotalSumm;
                    mWindowVW.total.TotalUp(CountBetValue);
                    mWindowVW.TotalValue = Total.TotalSumm.ToString();
                    ActiveUser.activeUser.TransactionQuantity++;
                    Transaction transaction = new Transaction
                    {
                        UserId = ActiveUser.activeUser.Id,
                        UserTransactionId = ActiveUser.activeUser.TransactionQuantity,
                        Operation = "Депозит",
                        Summ = CountBetValue + "$",
                        TotalBefore = totalBef + "$",
                        TotalAfter = Total.TotalSumm + "$",
                        Date = DateTime.Now
                    };

                    // Добавить в DbSet
                    context.Transactions.Add(transaction);

                    // Сохранить изменения в базе данных
                    context.SaveChanges();

                    ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
                    ActiveUser.UpdateState(context);
                    context.SaveChanges();
                    mWindowVW.CloseDepositWindow();
                }
                else if (mWindowVW.checkDep == false)
                {
                    if (CountBetValue <= Total.TotalSumm)
                    {
                        BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();
                        totalBef = Total.TotalSumm;
                        mWindowVW.total.TotalDown(CountBetValue);
                        mWindowVW.TotalValue = Total.TotalSumm.ToString();
                        ActiveUser.activeUser.TransactionQuantity++;
                        Transaction transaction = new Transaction
                        {
                            UserId = ActiveUser.activeUser.Id,
                            UserTransactionId = ActiveUser.activeUser.TransactionQuantity,
                            Operation = "Вывод",
                            Summ = CountBetValue + "$",
                            TotalBefore = totalBef + "$",
                            TotalAfter = Total.TotalSumm + "$",
                            Date = DateTime.Now
                        };

                        // Добавить в DbSet
                        context.Transactions.Add(transaction);

                        // Сохранить изменения в базе данных
                        context.SaveChanges();

                        ActiveUser.activeUser.Total = Convert.ToDecimal(Total.TotalSumm);
                        ActiveUser.UpdateState(context);
                        context.SaveChanges();
                        mWindowVW.CloseDepositWindow();
                    }
                    else
                        throw new Exception("Не хватает средств для вывода");

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        #endregion

        private MainWindowViewModel mWindowVW;

        public DepositWindowViewModel(MainWindowViewModel mWindowVW)
        {
            this.mWindowVW = mWindowVW;
            #region Команды
            AcceptApplicationCommand = new LambdaCommand(OnAcceptApplicationCommandExecuted, CanAcceptApplicationCommandExecuted);
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecuted);

            #endregion
        }
    }
}
