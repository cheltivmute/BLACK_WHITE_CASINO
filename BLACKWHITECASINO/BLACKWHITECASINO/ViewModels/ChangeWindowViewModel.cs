using BetClass;
using BLACKWHITECASINO.Data;
using BLACKWHITECASINO.Infrastructure.Commands;
using BLACKWHITECASINO.Models;
using BLACKWHITECASINO.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TotalClass;

namespace BLACKWHITECASINO.ViewModels
{
    internal class ChangeWindowViewModel : ViewModel
    {
        private void ValidateProperty<T>(T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }

        #region Текст
        private string _LabelText;

        public string LabelText
        {
            get
            {
                _LabelText = accWindowVW.LabelTextChange;
                return _LabelText;
            }
            set => Set(ref _LabelText, value);
        }
        #endregion

        #region ChangeText
        private string _ChangeText;

        [Required(ErrorMessage = "Поле не должно быть пустым!")]
        public string ChangeText
        {
            get
            {
                return _ChangeText;
            }
            set
            {

                ValidateProperty(value, "ChangeText");
                Set(ref _ChangeText, value);
            }
        }
        #endregion

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        private bool CanCloseApplicationCommandExecuted(object p) => true;

        private void OnCloseApplicationCommandExecuted(object p)
        {
            accWindowVW.CloseChangeWindow();
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
                if (accWindowVW.PasswordCheckNum == 1)
                {
                    Regex reg = new Regex(@"\b[A-Za-z0-9._%+-]{3,20}$");
                    if (reg.IsMatch(ChangeText))
                    {
                        var provLog = context.Users.Where(u => u.Login == ChangeText).FirstOrDefault();
                        if (provLog != null)
                        {
                            if (Language.checkRu == true)
                                throw new Exception("Аккаунт с таким логином уже существует!");
                            else
                                throw new Exception("Account with this username already exists!");

                        }

                        ActiveUser.activeUser.Login = ChangeText;
                        accWindowVW.AccountLogin = Convert.ToString(ActiveUser.activeUser.Login);
                    }
                    else
                    {
                        if (Language.checkRu == true)
                            throw new Exception("Логин введён некорректно!");
                        else
                            throw new Exception("Login entered incorrectly!");
                    }
                        
                }
                else if (accWindowVW.PasswordCheckNum == 2)
                {
                    Regex reg = new Regex(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}");
                    if (reg.IsMatch(ChangeText))
                    {
                        var provLog = context.Users.Where(u => u.Email == ChangeText).FirstOrDefault();
                        if (provLog != null)
                        {
                            if (Language.checkRu == true)
                                throw new Exception("Аккаунт с такой почтой уже существует!");
                            else
                                throw new Exception("Account with this email already exists!");

                        }
                        ActiveUser.activeUser.Email = ChangeText;
                        accWindowVW.AccountMail = Convert.ToString(ActiveUser.activeUser.Email);
                    }
                    else
                    {
                        if (Language.checkRu == true)
                            throw new Exception("Почта введена некорректно!");
                        else
                            throw new Exception("Email entered incorrectly!");
                    }
                        
                }
                else if (accWindowVW.PasswordCheckNum == 3)
                {
                    Regex reg = new Regex(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$");
                    if (reg.IsMatch(ChangeText))
                    {
                        var hashP = HashPassword.Hash(ChangeText);

                        ActiveUser.activeUser.Password = hashP;
                        accWindowVW.AccountPassword = Convert.ToString(ActiveUser.activeUser.Password);
                    }
                    else
                    {
                        if (Language.checkRu == true)
                            throw new Exception("Пароль введён некорректно!");
                        else
                            throw new Exception("Password entered incorrectly!");
                    }
                        
                }
                else if (accWindowVW.PasswordCheckNum == 4)
                {
                    Regex reg = new Regex(@"(\+375|80)(29|25|44|33)(\d{3})(\d{2})(\d{2})$");
                    if (reg.IsMatch(ChangeText))
                    {
                        ActiveUser.activeUser.Mobile = ChangeText;
                        accWindowVW.AccountMobile = Convert.ToString(ActiveUser.activeUser.Mobile);
                    }
                    else
                    {
                        if (Language.checkRu == true)
                            throw new Exception("Телефон введён некорректно!");
                        else
                            throw new Exception("Mobile entered incorrectly!");
                    }
                        
                }
                else if (accWindowVW.PasswordCheckNum == 5)
                {
                    Regex reg = new Regex(@"(^(((0[1-9]|1[0-9]|2[0-8])[.](0[1-9]|1[012]))|((29|30|31)[.](0[13578]|1[02]))|((29|30)[.](0[4,6,9]|11)))[.](19|[2-9][0-9])\d\d$)|(^29[.]02[.](19|[2-9][0-9])(00|04|08|12|16|20|24|28|32|36|40|44|48|52|56|60|64|68|72|76|80|84|88|92|96)$)");
                    if (reg.IsMatch(ChangeText))
                    {
                        DateTime dt = Convert.ToDateTime(ChangeText);
                        int AcctDate = DateTime.Now.Year - dt.Year - 1 + ((DateTime.Now.Month > dt.Month || DateTime.Now.Month == dt.Month && DateTime.Now.Day >= dt.Day) ? 1 : 0); ;
                        if (AcctDate < 18 || AcctDate > 100)
                        {
                            if (Language.checkRu == true)
                            {
                                throw new Exception("Вход только от 18 и до 100 лет!");
                            }
                            else
                                throw new Exception("Entrance only from 18 to 100 years old!");
                        }

                        ActiveUser.activeUser.BirthDay = Convert.ToDateTime(ChangeText);
                        accWindowVW.AccountDate = Convert.ToString(ActiveUser.activeUser.BirthDay.Day) + "." + Convert.ToString(ActiveUser.activeUser.BirthDay.Month) + "." + Convert.ToString(ActiveUser.activeUser.BirthDay.Year) + " (" + Convert.ToString(ActiveUser.AgeFind(ActiveUser.activeUser.BirthDay)) + " лет)";
                    }
                    else
                    {
                        if (Language.checkRu == true)
                            throw new Exception("Дата введена некорректно!");
                        else
                            throw new Exception("Date entered incorrectly!");
                    }
                        
                }

                ActiveUser.UpdateState(context);
                context.SaveChanges();
                accWindowVW.CloseChangeWindow();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        #endregion

        private AccountWindowViewModel accWindowVW;

        public ChangeWindowViewModel(AccountWindowViewModel accWindowVW)
        {
            this.accWindowVW = accWindowVW;
            #region Команды
            AcceptApplicationCommand = new LambdaCommand(OnAcceptApplicationCommandExecuted, CanAcceptApplicationCommandExecuted);
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecuted);
            #endregion
        }

    }
}
