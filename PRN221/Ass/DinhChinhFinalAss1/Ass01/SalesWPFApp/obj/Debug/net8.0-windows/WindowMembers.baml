   M S B A M L   `   `   `  ����  SalesWPFApp    SalesWPFApp.WindowMembers   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Manage Members��5   	   $	��500��6    $	��800��6-    � WindowStartupLocation$ CenterScreen=�69   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��	dgMembers��5         AutoGenerateColumns$ False��6$   $
��Left=�6@   $��	10,10,0,0q�6[   $	��Top=�6n   $	��181��6�   $	��760��6�      Columns 5	      0  *System.Windows.Controls.DataGridTextColumn  5
      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6N      
IsReadOnly$
 True��6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *
MemberId+6Y     5      $ Email��6%   $	 200 6N    64   �� *Email+6N     5      $ Company��6%   $	 150 6V    66   �� *CompanyName+6V     5      $
 City��6%   $	 100 6L    63   �� *City+6L     5      $ Country��6%   $	 100 6R    66   �� *	Country+6R     5      $ Password��6%   $	 150 6T    67   �� *
Password+6T   5      �� 5   
    �� Orientation$ Vertical=�6   $
��Left=�6,   $��
12,206,0,0q�6G   $	��Top=�6[   $	��225��6s   .+�5      �� $��Email:��6   �� 5      -   5        $��txtEmail��5      $	��300��6&   �� 5      $��Company Name:��6   �� 5      -   5        $��txtCompanyName��5      $	��300��6,   �� 5      $��City:��6   �� 5      -   5        $��txtCity��5      $	��300��6%   �� 5      $��Country:��6   �� 5      -   5        $��
txtCountry��5      $	��300��6(   �� 5!      $��	Password:��6   G� 5"      -   5        $��txtPassword��5"      $	��300��6-   5#      �� 5&   
   $ 
Horizontal=�6   $
��Left=�6.   $��Center=�6I   $��	340,0,0,0q�6d   $��30��6w   .+�5'      �� -   5        $��
Add Member��5'      $	��100��6*   66   �� 5(      -   5        $��Update Member��5(      $	��100��6-   $��10,0,0,0q�69   6K   �� 5)      -	   5        $��Delete Member��5)      $	��100��6-   $��10,0,0,0q�69   6K   �� 5*      -
   5        $��Clear��5*      $	��100��6%   $��10,0,0,0q�61   6C   5+      5,      5-      