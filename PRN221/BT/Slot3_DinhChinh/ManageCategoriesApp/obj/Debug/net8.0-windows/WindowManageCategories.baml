   M S B A M L   `   `   `  ����N  JManageCategoriesApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:ManageCategoriesAppManageCategoriesApp  5   	   0    *ManageCategoriesApp.WindowManageCategories   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:ManageCategoriesApp     5   	   -   5          � Title$  Manage Categories��5   	   $	��430��6#   $	��420��60    � WindowStartupLocation$ CenterScreen=�5	        � 
ResizeMode$ NoResize=�6E   .��5
      ]� $	��Top=�6   $��10q�6(   .+�5   
   �  � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    .+�5      �� 
����ح� �� Orientation$ Vertical=�60   $
��Left=�5      $	��400��6-   .+�5      �� -   5        $��lblInstruction��5      
���  ��$��DemiBold"�6?   $��20(�6U   $��Category Information��6c   �� 5      -   5        $��lblCategoryID��5      $��
CategoryID��6-   �� 5      -   5        $��txtCategoryID��5      $
��Left=�6/    �� 
IsReadOnly$
 True��5      $��25��6(   $	��300��64   ��5      ��  �� Path$ 
CategoryID� �� Mode$ OneWay=� � DataContext 5      �� 	 �� ElementName$	 lvCategories��$ SelectedItem��� 5      -   5        $��lbCategoryName��5      $��Category Name��6.   �� 5      -   5        $��txtCategoryName��5      $
��Left=�61   $��25��6L   $	��300��6X   ��5      �� $ CategoryName�$ OneWay=� 5      �� $	 lvCategories��$ SelectedItem��� 5      $ 
Horizontal=�6   $
��Left=�67   .+�5      �� -   5        
 ��Name$
 	btnInsert��5      $��10q�60   $��80��6<   $��Insert��6G   5      �� 5      -   5        $
 	btnUpdate��5      $��10q�61   $��80��6=   $��Update��6I   5       �� 5!      -	   5        $
 	btnDelete��5!      $��10q�60   $��80��6=   $��Delete��6H   5"      5#      5$      �� 5%      -
   5        $��lvCategories��5%   $   $��1��6   $	��400��68    �� View 5&      �� 5'      .P�5(      �� $��Category ID��6)    �� Width$	 100��6?    �� DisplayMemberBinding 5)   %   �� $ 
CategoryID��� 5*      $��Category Name��6)   $	 200��6@    5+   %   �� $ CategoryName�5,      5.      5/      50      51      