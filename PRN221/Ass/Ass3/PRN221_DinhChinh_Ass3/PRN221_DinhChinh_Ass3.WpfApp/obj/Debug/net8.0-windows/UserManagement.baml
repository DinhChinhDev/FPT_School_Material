   M S B A M L   `   `   `  ����W  SPRN221_DinhChinh_Ass3.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PRN221_DinhChinh_Ass3.WpfAppPRN221_DinhChinh_Ass3.WpfApp  5      1    +PRN221_DinhChinh_Ass3.WpfApp.UserManagement   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:PRN221_DinhChinh_Ass3.WpfApp     5        N� Title$  UserManagement��5
       � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers :� RoutedEvent	 �� To g� Duration	 �� TargetProperty��%�  '��       '�� �    '�� y    �� 5   
   " ��6   .�5      ��  � �� �#D354006+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 10,5q�6(   �� 5       � �� �#f0a07e6,   �� 5       � ��$ 1q�60   �� 5       � ��$ 5q�6'    5      :� 5      $ Button.MouseEnter��6   .[�5      �� .��5      �� .��5      ��  #f0a07e6-   $ 0:0:0.3D�6:   $1	 +(Button.Background).(SolidColorBrush.Color)�6M   5      5      5      :� 5      $ Button.MouseLeave��6   .[�5      �� .��5      �� .��5       ��  #D354006-   $ 0:0:0.3D�6:   $1	 +(Button.Background).(SolidColorBrush.Color)�6M   5!      5"      5#      5%      �� 5'   
   " ��6   .�5(      ��  � �� �#FAFAF96+   �� 5*       � ��$ 1q�60   �� 5+       � ��$ 5q�6(   5,      �� 5.   
   " ��6   .�5/      ��  � �� �#5A5A5A6+   50      51      .��53      �� -   5        
�������.+�54   
   &   System.Windows.Controls.DataGrid  -   5        $��dgvUsers��54      $	��225��55      $	��800��56      $
��Left=�59      $	��Top=�5:      
   ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$
 * 5;         
IsReadOnly$
 True��5<       �� Left$ 1��5>      
 �� Top$ 44��5?         AutoGenerateColumns$ False��5@         Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5C   %   �� *	AppUserId+  5D      $ Username��6%    5E   %   �� *
UserName+  5F      $ Password��6%    5G      �� *
Password+4  .System.Windows.Controls.DataGridCheckBoxColumn  5I      $ 
Is Shipper��6)      
IsReadOnly$
 True��5K   %    5J   %   �� *	IsShipper+5K   %   5M      �� 5O   
   -   5         ��Name$ txtId��5O      $	 228��5P       �� TextWrapping$
 Wrap=�5Q      $	 291��5R      $	��120��5S      ${�False��5T      �� 5U   
   $��Id��6   $	 146��5V      $	 291��5W      �� 5X   
   $��Username��6   $	 146��5Y      $	 322��5Z      $
��Left=�5[      $	��Top=�5\      �� 5]   
   -   5        $ txtUsername��5]      $	 228��5^      $
 Wrap=�5_      $	 321��5`      $	��120��5a      $
��Left=�5b      $	��Top=�5c      �� 5d   
   $��Password��6   $	 397��5e      $	 322��5f      $
��Left=�5g      $	��Top=�5h      G� 5i   
   -   5         G�Name$ txtPassword��5i      $	 479��5j      $	 321��5k      $	��109��5l      $
��Left=�5m      $��Center=�5n      $y�Visible=�5p      �� 5r   
   -   5        $ txtPasswordReveal��5r      $	 479��5s      $	 321��5t      $	��120��5u      $
��Left=�5v      $	��Top=�5w      $y�	Collapsed=�5x       �� 
IsReadOnly$
 True��5y      �� 5{   
   -   5         ��Name$ btnShowPassword��5{      $	 588��5|      $	 322��5}      $��20��5~      $��16��5      $
��👁��5�      
������ 
������ $��0q�5�      
���   �$��0q�5�      $
��Left=�5�      $	��Top=�5�       J� RenderTransformOrigin$ -0.203,-1.02&�6)   �� 5�   
   -   5        $ 	btnDelete��5�      $��Delete��5�      $	 380��5�      $	 412��5�      $
��Left=�5�      $	��Top=�5�      5�      �� 5�   
   -	   5        $ btnSave��5�      $
��Save��5�      $	 257��5�      $	 412��5�      $
��Left=�5�      $	��Top=�5�      5�      �� 5�   
   -
   5        $ btnClear��5�      $��Clear��5�      $	 507��5�      $	 412��5�      $
��Left=�5�      $	��Top=�5�      5�      �� 5�   
   $��	IsShipper��6   $	 397��5�      $	 289��5�      $
��Left=�5�      $	��Top=�5�      �� 5�   
   -   5         ��Name$ checkIsShipper��5�      $	 479��5�      $	 295��5�      �� 5�   
   $��USER MANAGEMENT��6   $	 316��5�      $ 8��5�      $��16(�5�      $
��Bold"�5�      $��Center=�5�      $	��Top=�5�      5�      5�      