   M S B A M L   `   `   `  ����W  SPRN221_DinhChinh_Ass3.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PRN221_DinhChinh_Ass3.WpfAppPRN221_DinhChinh_Ass3.WpfApp  5   	   .    (PRN221_DinhChinh_Ass3.WpfApp.UserWindow1   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   <local*clr-namespace:PRN221_DinhChinh_Ass3.WpfApp     5   	     � Title$  
UserWindow��5   	   $	��450��5	   	   $	��800��5
   	    � 	Resources 5       �� 
TargetType �� Property �� Value��%�  'm�       '�� �     '�� �    '�� �    '�� B    �� 5   
   " m�6   .�5      ��  � ��$
 10,0q�6(   �� 5       � ��$ Center=�62   �� 5       � ��$ 14(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��
 �   �6+   5      �� 5   
   " ��6   .�5      ��  � ��$
 10,5q�6(   �� 5       � ��$ 14(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � �� �	#FFDDDDDD6+   �� 5       � �� �	#FFAAAAAA6,   �� 5       � ��$ 1q�60   5      �� 5   
   " ��6   .�5      ��  � ��$ 14(�6)   �� 5        � ��
 �����6+   �� 5!       � �� �	#FFAAAAAA6,   �� 5"       � ��$ 1q�60   5#      �� 5%   
   " ��6   .�5&      ��  � ��$ 14(�6)   �� 5'       � ��$
 Bold"�6+   �� 5(       � ��
 �   �6+   5)      �� 5+   
   " ��6   .�5,      ��  � ��$
 Fill=�6(   �� 5-       �@�Cursor$
 Hand��6'   5.      5/      .��52      �� .+�54   
   &   System.Windows.Controls.DataGrid  -   5        $��dgvBooks��54      $	��800��55      $	��450��56         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 57         AutoGenerateColumns$ False��58         
IsReadOnly$
 True��59      $��Center=�5<      
 �� Top$ 74��5=      $	��Top=�5>      	   Columns	 5?      0  *System.Windows.Controls.DataGridTextColumn  5@      ,  &System.Windows.Controls.DataGridColumn
   Header$
 ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5A   %   �� *BookId+6B     5B      $

 Name��6%    5C   %   �� *
BookName+6D     5D      $
 Price��6%    5E   %   �� *Price+6A     5F      $
 Category��6%    5G   %   �� *Category.CategoryName+6Q   5J      �� 5K   
   -   5         ��Name$ 	txtSearch��5K       �� Left$ 10��5L       �� TextWrapping$
 Wrap=�5M      $ 48��5N      $	��390��5O      $��20��5P      $��Center=�5Q      $	��Top=�5R      $��0q�5U      �� 5V   
   -   5         ��Name$ cboCategory��5V      $	 413��5W      $ 48��5X      $	��120��5Y      $��20��5Z      $��0q�5[      $��Center=�5\      $	��Top=�5]      5^      �� 5_   
   -   5         ��Name$ 	btnSearch��5_      $��Search��5`      $	 349��5a      $��9(�5b      
������ 
������ $��Center=�5e      $	��Top=�5f      
���   �$ 46��5i      $��23��6!   $��52��6-    J� RenderTransformOrigin$ 0.714,0.573&�68   z�5j      V� 5k      .~�5l      �� �� 5m       �� AngleX$ -10.869Q�6$   �� 5n      T� 5o       T� X$ -2.529Q�6)   5p      5r      �� 5t   
   -   5        $ 	btnLogout��5t      $��Logout��5u      $	 702��5v      $ 18��5w      $��20��5x      $ -0.01,0.483&�5z      $
��Left=�5{      $
��10 0q�5|      $	��Top=�5}      �� 5~   
   -   5        $ btnOrder��5~      $��Order��5   	   $	 552��5�   	   $ 46��5�   	   $��20��5�   	   $��61��5�   	   ${�False��5�   	   $
��10,0q�5�   	   $
��Left=�5�   	   $��Center=�5�   	   5�      5�      