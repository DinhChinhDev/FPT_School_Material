   M S B A M L   `   `   `  ����F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesWPFAppSalesWPFApp  5   	        SalesWPFApp.WindowProducts   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SalesWPFApp     5   	     � Title$  WindowProducts��5   	   $	��600��6    $	��800��6-   .��5	      � .+�5   
   �� -   5        $��70��5      $��30��6   $
��Left=�5      $��Bottom=�6,   $��
10,10,0,10q�5      
������ 
������ ��5      F� 5      F�������  -1� -1��� � -1��� р����� р��@x}� -1@x}� -1���	
���   �
���   �$��2��5   3   $��24��6G    �� Stretch$
 Fill=�6S   $��51��6b   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGridProducts��5         AutoGenerateColumns$ False��6-   $	��300��6I   $��
0,49,0,235q�6V      SelectionMode$ Single=�6j      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Product ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   �� *	ProductId+6W     5      $ Category��6%   $ * 6a    67   �� *Caterory.CategoryName+6a     5      $ Product Name��6%   $ * 6[    6;   �� *ProductName+6[     5      $ Weight��6%   $
 Auto 6P    65   �� *Weight+6P     5      $ 
Unit Price��6%   $ * 6n    69   �� *	UnitPrice+	 �� StringFormat$	 {0:N3}��6n     5      $ Units In Stock��6%   $ * 6u    6=   �� *UnitsInStock+$	 {0:N3}��6u   5      � 5/   
   $
��Left=�6   $��Bottom=�6*   $��	23,0,0,92q�6E   $	��744��6X   
 � ColumnDefinitions
 50      �� 51      $
��Auto �6#   �� 52      $	��300 �6#    � RowDefinitions 55      �� 56      $
��Auto �6    �� 57      $
��Auto �6    �� 58      $
��Auto �6    �� 59      $
��Auto �6    �� 5:      $
��Auto �6    .+�5>      �� $��Category ID:��6   $��0��6,   $	��Top=�6<   $��	0,7,300,0q�6T   $��2��6g    J� RenderTransformOrigin$ 0.494,0.055&�6{   �� 5?      -   5         ��Name$ txtCategoryID��5?      $��0��6-   $��1��6:   $��	0,6,51,10q�6J   �� 5B      $��Product Name:��6   $��1��6-   $	��Top=�6=   $��278,7,-57,0q�6U   �� 5C      -   5        $ txtProductName��5C      $��1��6.   $��362,6,-311,10q�6>   �� 5F      $��Weight:��6   $��2��6'   $��0��64   $��Center=�6D   $��	0,0,300,0q�6_   $��2��6r   �� 5G      -   5        $ 	txtWeight��5G      $��2��6)   $��1��66   $��
0,11,51,19q�6F   �� 5J      $��Unit Price:��6   $��2��6+   $��1��68   $��Center=�6H   $��287,0,-62,0q�6c   �� 5K      -   5        $ txtUnitPrice��5K      $��2��6,   $��1��69   $��362,7,-311,19q�6I   �� 5N      $��Units In Stock:��6   $��4��6/   $��0��6<   $��Center=�6L   $��0,10,0,0q�6g   �� 5O      -   5        $ txtUnitsInStock��5O      $��4��6/   $��1��6<   $	��249��6L   $��0,10,0,0q�6X   $
��Left=�6j   5P      �� 5U   
    �� Orientation$ 
Horizontal=�6   $��Center=�6.   $	��Top=�6K   $��	0,516,0,0q�6c   .+�5V      �� -   5        $��Add Product��5V      $	��100��6+   $��10q�67   6C   �� 5W      -	   5        $��Edit Product��5W      $	��100��6,   $��10q�68   6D   �� 5X      -
   5        $��Delete Product��5X      $	��100��6.   $��10q�6:   6F   5Y      5Z      5[      