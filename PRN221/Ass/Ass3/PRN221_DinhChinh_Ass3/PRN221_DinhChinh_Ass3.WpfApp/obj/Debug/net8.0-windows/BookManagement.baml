   M S B A M L   `   `   `  ����W  SPRN221_DinhChinh_Ass3.WpfApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:PRN221_DinhChinh_Ass3.WpfAppPRN221_DinhChinh_Ass3.WpfApp  5      1    +PRN221_DinhChinh_Ass3.WpfApp.BookManagement   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <local*clr-namespace:PRN221_DinhChinh_Ass3.WpfApp     5        N� Title$  UserManagement��5
       � 	Resources 5       �� 
TargetType �� Property �� Value �� Triggers :� RoutedEvent	 �� To g� Duration	 �� TargetProperty��%�  '��       '�� �    '�� O    �� 5   
   " ��6   .�5      ��  � �� �#D354006+   �� 5       � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 10,5q�6(   �� 5       � �� �#f0a07e6,   �� 5       � ��$ 1q�60   �� 5       � ��$ 5q�6'    5      :� 5      $ Button.MouseEnter��6   .[�5      �� .��5      �� .��5      ��  #f0a07e6-   $ 0:0:0.3D�6:   $1	 +(Button.Background).(SolidColorBrush.Color)�6M   5      5      5      :� 5      $ Button.MouseLeave��6   .[�5      �� .��5      �� .��5      ��  #D354006-   $ 0:0:0.3D�6:   $1	 +(Button.Background).(SolidColorBrush.Color)�6M   5       5!      5"      5$      �� 5&   
   " ��6   .�5)      ��  � ��$ 1q�60   �� 5*       � ��$ 5q�6(   5+      �� 5-   
   " ��6   .�5.      ��  � �� �#5A5A5A6+   5/      50      .��52      �� -   5        
�������.+�54   
   &   System.Windows.Controls.DataGrid  -   5        $��dgvBooks��54      $	��225��55      $	��800��56      $
��Left=�59      $	��Top=�5:      
   
IsReadOnly$

 True��5;         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5<         AutoGenerateColumns$ False��5=       �� Left$ 1��5?      
 �� Top$ 42��5@         Columns 5A      0  *System.Windows.Controls.DataGridTextColumn  5B      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5C   %   �� *BookId+  5D      $
 Name��6%    5E   %   �� *
BookName+  5F      $ Price��6%    5G   %   �� *Price+  5H      $ Category��6%    5I   %   �� *Category.CategoryName+5K      �� 5L   
   5N      �� 5O   
   $��Id��6   $	 146��5P      $	 289��5Q      �� 5R   
   -   5         ��Name$ txtId��5R      $	 206��5S       �� TextWrapping$
 Wrap=�5T      $	 291��5U      $	��164��5V      ${�False��5W      $
��Left=�5X      $	��Top=�5Y      �� 5Z   
   $
��Name��6   $	 397��5[      $	 290��5\      $
��Left=�5]      $	��Top=�5^      �� 5_   
   -   5        $ txtName��5_      $	 479��5`      $
 Wrap=�5a      $	 289��5b      $	��173��5c      $
��Left=�5d      $	��Top=�5e      �� 5f   
   $��Price��6   $	 146��5g      $	 320��5h      $
��Left=�5i      $	��Top=�5j      �� 5k   
   -   5        $ txtPrice��5k      $	 206��5l      $
 Wrap=�5m      $	 321��5n      $	��165��5o      $
��Left=�5p      $	��Top=�5q      �� 5r   
   $��Category��6   $	 397��5s      $	 320��5t      $
��Left=�5u      $	��Top=�5v      �� 5w   
   -   5         ��Name$ cboCategory��5w      $	 479��5x      $	 317��5y      $	��173��5z      $
��Left=�5{      $	��Top=�5|      �� 5}   
   -   5         ��Name$ 	btnDelete��5}      $��Delete��5~      $	 397��5      $	 366��5�      $
��Left=�5�      $	��Top=�5�      5�      �� 5�   
   -   5        $ btnSave��5�      $
��Save��5�      $	 274��5�      $	 366��5�       J� RenderTransformOrigin$ -0.246,-0.028&�5�      $
��Left=�5�      $	��Top=�5�      5�      �� 5�   
   -	   5        $ btnClear��5�      $��Clear��5�      $	 524��5�      $	 366��5�      $
��Left=�5�      $	��Top=�5�      5�      �� 5�   
   $��BOOK MANAGEMENT��6   $	 312��5�      $ 6��5�      $
��Bold"�5�      $��16(�5�      5�      5�      