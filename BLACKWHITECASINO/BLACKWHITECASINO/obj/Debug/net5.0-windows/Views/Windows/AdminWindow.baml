   M S B A M L   `   `   `  ????K  GBLACKWHITECASINO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:BLACKWHITECASINO.ViewModelsBLACKWHITECASINO.ViewModels  5   	   O,clr-namespace:BLACKWHITECASINO.Views.WindowsBLACKWHITECASINO.Views.Windows  5   	   0    *BLACKWHITECASINO.Views.Windows.AdminWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   8vm)clr-namespace:BLACKWHITECASINO.ViewModels     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:BLACKWHITECASINO.Views.Windows     5   	   -   5          ?Name$  AdminWin??5   d    ? WindowState$ 	Maximized=?5	   	    ? Title$/ )Панель администратора??5
   	   $	??768??5   	   $
??1024??6   $
??1024??6#   $	??768??63   $
??1920??6C   $
??1080??6S    ? DataContext 5      6  0BLACKWHITECASINO.ViewModels.AdminWindowViewModel  5   
   .??5      ? .+?5   
   ?  ? ColumnDefinitions 5      ?? 5      6%   ?? 5      $??3* ?6#   60   ?? 5      $
??0.5* ?6#   62   ?? 5      $??3* ?6#   60   ?? 5      6%    ? RowDefinitions 5      ?? 5      $??2* ?6    6.   ?? 5      6"   ?? 5      $??1* ?6    6.   ?? 5      $??6* ?6    6.   .+?5"      ??    RoundButtonTemplateCircle#???   6   $??0??6?   $??4??6?    ? Cursor$
 Hand??6?   $??30,40q?6?   ??6I   ?? *ExitAdminCommand+??6n   ??  ?? ElementName$ AdminWin??.??5#      ?? $??40(?6   $
??Bold"?6*   X5%      5&      ?? 5(      $??3??6   $??1??6%   $??3??65   $??Center=?6I   $??Center=?6k   $
??Aqum)?6?   $??45(?6?   $??0q?6?     AWLabel#???  6?   ? 5*      $??2??6   $??2??6    $??5??61    5+      ?? 5,      6)   ?? 5-      6)   ?? 5.      6)    50      ?? 51      $
??0.2* ?6$   64   ?? 52      6&   ?? 53      $
??0.2* ?6$   64   .+?55      &   System.Windows.Controls.DataGrid  $??0??6   $??2??6)   $??3??6:   
???????$
??Aqum)?6a   $??25(?6s      AutoGenerateColumns$ False??6?   $??Center=?6?   $??Center=?6?   	   
IsReadOnly$
	 True??65  
   CanUserAddRows$
 False??6G     CanUserDeleteRows$ False??6^     CanUserReorderColumns$ False??6x     CanUserResizeRows$ False??6?  ??6?   ?? *DataAdminItemsSource+ ?? UpdateSourceTrigger$ PropertyChanged=? ?? SelectedItem 6?  ?? *SelectedUser+$ PropertyChanged=?   Columns 56      0  *System.Windows.Controls.DataGridTextColumn  57      ,  &System.Windows.Controls.DataGridColumn   Header$ Id??6-      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 69   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6D   ?? *DataAdminId+6f     58        AWLogin# ?  6-   $ * 6P    6Z   ?? *DataAdminLogin+6     59        AWEmail# ?  6-   $ * 6P    6Z   ?? *DataAdminEmail+6     5:        AWMobile# ?  6-   $ * 6Q    6[   ?? *DataAdminMobile+6?     5;        AWTotal# ?  6-   $ * 6P    6Z   ?? *DataAdminTotal+6     5<        AWGames# ?  6-   $ 75 6P    6[   ?? *DataAdminGames+6?     5=       
 AWTran# ?  6-   $ 75 6O    6Z   ?? *DataAdminTrans+6     5>        AWBD# ?  6-   $	 170 6M    6Y   ?? *DataAdminBD+6{   5A      ?? 5B      #???   6   $??2??6s   $??0??6?   $
 Hand??6?   $
??10,5q?6?   ??6M   ?? *DeleteUserCommand+.??5C      ?? $??25(?6     		 AWDel#??? 	 6.   5E      ?? 5F      #???   6   $??2??6p   $??1??6}   $
 Hand??6?   $
??10,5q?6?   ??6M   ?? *BanUserCommand+.??5G      ?? $??25(?6     	
 AWBan#??? 
 6.   5I      ?? 5J      #???   6   $??2??6r   $??2??6   $
 Hand??6?   $
??10,5q?6?   ??6M   ?? *UnBanUserCommand+.??5K      ?? $??25(?6      AWUnBan#???  6.   5M      5P      5Q      5R      5T      