   M S B A M L   `   `   `  ����  SalesWPFApp     SalesWPFApp.WindowProducts   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Manage Products��5   	   $	��500��6!   $	��800��6.    � WindowStartupLocation$ CenterScreen=�6:   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��
dgProducts��5         AutoGenerateColumns$ False��6%   $
��Left=�6A   $��10,10,10,200q�6\   $	��Top=�6r   $	��200��6�   $	��760��6�      Columns 5	      0  *System.Windows.Controls.DataGridTextColumn  5
      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Product ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6W      
IsReadOnly$
 True��6c   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	ProductId+6c     5      $ Category ID��6%   $	 100 6Y    6:   �� *
CategoryId+6Y     5      $ Product Name��6%   $	 200 6[    6;   �� *ProductName+6[     5      $ Weight��6%   $	 100 6P    65   �� *Weight+6P     5      $ 
Unit Price��6%   $	 100 6W    69   �� *	UnitPrice+6W     5      $ Units In Stock��6%   $	 100 6^    6=   �� *UnitsInStock+6^   5      �� 5   
    �� Orientation$ Vertical=�6   $
��Left=�6,   $��10,220,10,10q�6G   $	��Top=�6]   $	��760��6u   .+�5      �� $ 
Horizontal=�6   .+�5      �� $��Product Name:��6   $	��100��60   �� 5      -   5        $��txtProductName��5      $	��200��60   5      �� 5      $ 
Horizontal=�6   .+�5      �� $��Category ID:��6   $	��100��6/   �� 5      -   5        $��txtCategoryId��5      $	��200��6/   5      �� 5      $ 
Horizontal=�6   .+�5       �� $��Weight:��6   $	��100��6*   �� 5!      -   5        $��	txtWeight��5!      $	��200��6+   5"      �� 5$      $ 
Horizontal=�6   .+�5%      �� $��Unit Price:��6   $	��100��6.   �� 5&      -   5        $��txtUnitPrice��5&      $	��200��6.   5'      �� 5)      $ 
Horizontal=�6   .+�5*      �� $��Units In Stock:��6   $	��100��62   �� 5+      -   5        $��txtUnitsInStock��5+      $	��200��61   5,      �� 5/      $ 
Horizontal=�6   $��Center=�62   $��10q�6O   .+�50      �� -   5        $��btnAdd��50      $	��Add��6'   $	��100��65   6A   �� 51      -   5        $��	btnUpdate��51      $��Update��6*   $	��100��6;   $��	10,0,10,0q�6_   �� 52      -	   5        $��	btnDelete��52      $��Delete��6*   $	��100��6;   6G   53      54      55      56      