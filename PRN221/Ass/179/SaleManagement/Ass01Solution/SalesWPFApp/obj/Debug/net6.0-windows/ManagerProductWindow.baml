   M S B A M L   `   `   `  ����F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesWPFAppSalesWPFApp  5   	   &     SalesWPFApp.ManagerProductWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SalesWPFApp     5   	     � Title$  ManagerProductWindow��5   	   $	��620��6&   $	��800��63   .��5	      � .+�5
   
   ]� $	��Top=�6   $��5q�6,   .+�5      � 
����ح� � RowDefinitions 5      �� 5      $
��Auto �6%   �� 5      $
��Auto �6%   �� 5      $	��180 �6%   �� 5      $��* �6%   .+�5      ��  �� Orientation$ Vertical=�6   $
��Left=�5      $��0, 10, 0, 0q�60   $��2��6E   .+�5      �� -   5         ��Name$ 
btnProduct��5      $��10q�61   $��80��6=   $��Product��6H   6Z   �� 5      -   5        $ btnOrder��5      $��10q�6/   $��80��6;   $��Order��6F   6V   �� 5      -   5        $ 	btnMember��5      $��10q�60   $��80��6<   $��Member��6G   6X   �� 5      -   5        $ 	btnLogOut��5      $��10q�60   $��80��6<   $��LogOut��6G   6X   5      �� 5      $ Vertical=�6   $��Center=�5      $	��500��6:   .+�5!      �� -   5        $��lbTitle��5!      
���  ��$��DemiBold"�6<   $��20(�5"      $��Product Manager��6*   �� 5$      -   5        $��lbProductId��5$      $��
Product Id��6/   �� 5%      -   5        $��txtProductId��5%      $��Stretch=�62   $��25��5&      ��6*   ��  �� Path$ 	ProductId� �� Mode$ OneWay=� � DataContext 5'      ��  �� ElementName$ 
lvProducts��$ SelectedItem��� 5)      -   5        $��lbCategoryId��5)      $��Category Id��60   6H   �� 5*      -	   5        $��txtCategoryId��5*      $��Stretch=�63   $��25��5+      ��6*   �� $ 
CategoryId�$ OneWay=� 5,      �� $ 
lvProducts��$ SelectedItem��� 5.      -
   5        $��lbProductName��5.      $��Product Name��61   6J   �� 5/      -   5        $��txtProductName��5/      $��Stretch=�64   $��25��50      ��6*   �� $ ProductName�$ OneWay=� 51      �� $ 
lvProducts��$ SelectedItem��� 53      -   5        $��lbWeight��53      $��Weight��6,   6?   �� 54      -   5        $��	txtWeight��54      $��Stretch=�6/   $��25��55      ��6*   �� $ Weight�$ OneWay=� 56      �� $ 
lvProducts��$ SelectedItem��� 58      -   5        $��lbUnitPrice��58      $��	UnitPrice��6/   6E   �� 59      -   5        $��txtUnitPrice��59      $��Stretch=�62   $��25��5:      ��6*   �� $ 	UnitPrice�$ OneWay=� 5;      �� $ 
lvProducts��$ SelectedItem��� 5=      -   5        $��lbUnitsInStock��5=      $��UnitsInStock��62   6K   �� 5>      -   5        $��txtUnitsInStock��5>      $��Stretch=�65   $��25��5?      ��6*   �� $ UnitsInStock�$ OneWay=� 5@      �� $ 
lvProducts��$ SelectedItem�5C      �� 5E      $��1��6   $ 
Horizontal=�6*   $��Center=�6C   .+�5F      �� -   5        $ 	btnInsert��5F      $��10q�60   $��80��6<   $��Insert��6G   6X   �� 5G      -   5        $ 	btnUpdate��5G      $��10q�60   $��80��6<   $��Update��6G   6X   �� 5H      -   5        $ 	btnDelete��5H      $��10q�60   $��80��6<   $��Delete��6G   6X   �� 5I      -   5        $ 	btnSearch��5I      $��10q�60   $��80��6<   $��Seach��6G   6W   5J      �� 5M      -   5        $��
lvProducts��5M   (   $��2��6   $
��Auto��6:   $
��Auto��6G    �� View 5N      �� 5O      .P�5P      �� $��
Product Id��6-   	 �� Width$		 100��6A   
 �� DisplayMemberBinding
 6M   �� $ 	ProductId��� 5Q      $��Category Id��6-   $		 150��6B   
 6N   �� $ 
CategoryId��� 5R      $��Product Name��6-   $		 150��6C   
 6O   �� $ ProductName��� 5S      $��Weight��6-   $		 150��6=   
 6I   �� $ Weight��� 5T      $��	UnitPrice��6-   $		 150��6@   
 6L   �� $ 	UnitPrice��� 5U      $��UnitsInStock��6-   $		 100��6C   
 6O   �� $ UnitsInStock�5V      5Y      5]      5^      5_      5`      