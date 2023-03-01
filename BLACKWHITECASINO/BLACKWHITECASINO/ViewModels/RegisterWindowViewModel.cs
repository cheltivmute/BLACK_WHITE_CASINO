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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TotalClass;

namespace BLACKWHITECASINO.ViewModels
{
    internal class RegisterWindowViewModel : ViewModel
    {
        public int provLabel { get; set; }

        private void ValidateProperty <T> (T value, string name)
        {
            Validator.ValidateProperty(value, new ValidationContext(this, null, null)
            {
                MemberName = name
            });
        }
        
        #region UserLoginReg
        private string _UserLoginReg;
        
        [Required(ErrorMessage = "Поле не должно быть пустым!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Минимум 3 и максимум 20 символов!")]
        [RegularExpression(@"\b[A-Za-z0-9._%+-]{3,20}$", ErrorMessage = "Поле содержит только латинские буквы, цифры и _")]
        public string UserLoginReg
        {
            get
            { 
                return _UserLoginReg;
            }
            set
            {
                ValidateProperty(value, "UserLoginReg");
                Set(ref _UserLoginReg, value);
            }
        }
        #endregion


        #region UserMailReg
        private string _UserMailReg;

        [Required(ErrorMessage = "Поле не должно быть пустым!")]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Минимум 5 и максимум 25 символов!")]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Формат для почты xxx@xxx.xxx")]
        public string UserMailReg
        {
            get => _UserMailReg;
            set
            {
                ValidateProperty(value, "UserMailReg");
                Set(ref _UserMailReg, value);
            }
        }
        #endregion
        

        #region UserPasswordReg
        private string _UserPasswordReg;
        [Required(ErrorMessage = "Поле не должно быть пустым!")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Минимум 8 и максимум 20 символов!")]
        [RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage = "Пароль должен содержать a-z, A-Z, 0-9")]
        public string UserPasswordReg
        {
            get => _UserPasswordReg;
            set
            {
                ValidateProperty(value, "UserPasswordReg");

                Set(ref _UserPasswordReg, value);
            }
        }
        #endregion
        

        #region UserMobileReg
        private string _UserMobileReg;

        [Required(ErrorMessage = "Поле не должно быть пустым!")]
        [RegularExpression(@"(\+375|80)(29|25|44|33)(\d{3})(\d{2})(\d{2})$", ErrorMessage = "Формат для телефона (+375/80)(29/25/33/44)YYYYYYY")]
        public string UserMobileReg
        {
            get => _UserMobileReg;
            set
            {
                ValidateProperty(value, "UserMobileReg");
                Set(ref _UserMobileReg, value);
            }
        }
        #endregion
        


        #region UserDateReg
        private DateTime _UserDateReg = DateTime.Today;

        public DateTime UserDateReg
        {
            get => _UserDateReg;
            set
            {
                Set(ref _UserDateReg, value);
            }
        }
        #endregion
      

        #region  RegisterEnterCommand
        public ICommand RegisterEnterCommand { get; }

        private bool CanRegisterEnterCommandExecuted(object p)
        {
            return true;
        }

        private void OnRegisterEnterCommandExecuted(object p)
        {
            try
            {
                if (UserLoginReg == null || UserPasswordReg == null || UserMailReg == null || UserMobileReg == null)
                {
                    if(Language.checkRu == true)
                        throw new Exception("Введите все значения!");
                    else
                        throw new Exception("Enter all values!");

                }
                int AcctDate = DateTime.Now.Year - UserDateReg.Year - 1 + ((DateTime.Now.Month > UserDateReg.Month || DateTime.Now.Month == UserDateReg.Month && DateTime.Now.Day >= UserDateReg.Day) ? 1 : 0); ;
                if (AcctDate < 18 || AcctDate > 100)
                {
                    if(Language.checkRu == true)
                    {
                        throw new Exception("Вход только от 18 и до 100 лет!");
                    }
                    else
                        throw new Exception("Entrance only from 18 to 100 years old!");
                }
                    


                BLACK_WHITE_CASINOContext context = new BLACK_WHITE_CASINOContext();

                var provLog = context.Users.Where(u => u.Login == UserLoginReg).FirstOrDefault();
                if (provLog != null)
                {
                    if(Language.checkRu == true)
                        throw new Exception("Аккаунт с таким логином уже существует!");
                    else
                        throw new Exception("Account with this username already exists!");

                }

                Window logWin = new LoginWindow();

                var hashP = HashPassword.Hash(UserPasswordReg);

                User user = new User
                {
                    Login = UserLoginReg,
                    Email = UserMailReg,
                    Password = hashP,
                    Mobile = UserMobileReg,
                    BirthDay = UserDateReg,
                    Role = "user"
                };

                // Добавить в DbSet
                context.Users.Add(user);

                // Сохранить изменения в базе данных
                context.SaveChanges();

                lWindowVW.RegisterWindow.Close();
                logWin.Show();
            }
            catch(Exception ex)
            {  
                MessageBox.Show(ex.Message);
            }
            
        }
        #endregion

        #region  LoginSwapCommand
        public ICommand LoginSwapCommand { get; }

        private bool CanLoginSwapCommandExecuted(object p) => true;

        private void OnLoginSwapCommandExecuted(object p)
        {
            Window logWin = new LoginWindow();
            lWindowVW.RegisterWindow.Close();
            logWin.Show();
        }
        #endregion

        

        private LoginWindowViewModel lWindowVW;

        public RegisterWindowViewModel(LoginWindowViewModel lWindowVW)
        {
            this.lWindowVW = lWindowVW;
            #region Команды
            RegisterEnterCommand = new LambdaCommand(OnRegisterEnterCommandExecuted, CanRegisterEnterCommandExecuted);
            LoginSwapCommand = new LambdaCommand(OnLoginSwapCommandExecuted, CanLoginSwapCommandExecuted);
            #endregion
        }

    }
}
