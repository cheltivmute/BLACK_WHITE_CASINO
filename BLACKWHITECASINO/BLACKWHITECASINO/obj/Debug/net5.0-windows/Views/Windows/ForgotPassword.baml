   M S B A M L   `   `   `  ????K  GBLACKWHITECASINO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:BLACKWHITECASINO.ViewModelsBLACKWHITECASINO.ViewModels  5      O,clr-namespace:BLACKWHITECASINO.Views.WindowsBLACKWHITECASINO.Views.Windows  5      3    -BLACKWHITECASINO.Views.Windows.ForgotPassword   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      8vm)clr-namespace:BLACKWHITECASINO.ViewModels     5      >local,clr-namespace:BLACKWHITECASINO.Views.Windows     5        ? WindowStyle$
  None=?5	      $??5q?6)   $	??200??5
      $	??400??6    ? 
ResizeMode$ NoResize=?6    ? Topmost$
 True??64    ? WindowStartupLocation$ CenterScreen=?6C    ? DataContext 5      6  0BLACKWHITECASINO.ViewModels.LoginWindowViewModel  5   
   .??5      ?  ? Cursor$
 Hand??6    ? ColumnDefinitions 5   
   ?? 5      6!   ?? 5      6!   ?? 5      6!    ? RowDefinitions 5   
   ?? 5      6   ?? 5      6   .+?5   
   ?? $??0??6   $??3??6      ForgotLabel#???   61   $??Center=?6Y   $??0,10,0,0q?6v   $??Center=?6?   $
??Aqum)?6?   $??20(?6?   ?? 5   
   -   5         ??Name$ forgotEmail??5      $??1??6'   $??3??64   $??2q?6H   $??Center=?6\   $??	0,-20,0,0q?6y   	 ?? TextWrapping$
	 Wrap=?6?   $	??Top=?6?   $	??350??6  $??Center=?6!  $??Center=?6E  $??Arial Rounded MT Bold)?6g  $??14(?6?  
???   ?$??30??6?  ??6?   ?? *
ChangeText+
 ?? ValidatesOnExceptions$

 True?? ?? UpdateSourceTrigger$ PropertyChanged=?6?  ?? 5   
   $??1??6   $??3??6!   $
??Aqum)?65   $??10(?6G   $??
30,0,30,45q?6U   $??Center=?6i   ???	#FFDC5454??6?   ?? *%#(Validation.Errors)[0].ErrorContent+ ?? ElementName$ forgotEmail??6?   ?? 5   
   $??1??6   $??2??6   $??2,2,1,2q?62   $
??ок??6L   $
??Left=?6Y   $??	20,0,0,12q?6t   $??Bottom=?6?   $	??175??6?   
???   ????	#FF88FF9A$
??Aqum)?6?   $??10(?6?   $??30??6?   ??6  ?? *AcceptApplicationCommand+?? 5   
   $??1??6   $??2??6   $??1,2,2,2q?62    
 Cancel#???  6L   $??Right=?6o   $??	0,0,20,12q?6?   $??Bottom=?6?   $	??175??6?   
???   ????	#FFFF8888$
??Aqum)?6?   $??10(?6  $??30??6  $??1??6  ??6,  ?? *CloseApplicationCommand+5      5      