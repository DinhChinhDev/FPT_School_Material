   M S B A M L   `   `   `  ����F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesWPFAppSalesWPFApp  5   	   &     SalesWPFApp.WindowManagerMembers   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SalesWPFApp     5   	     � Title$  WindowManagerMembers��5   	   $	��620��6&   $	��800��63   .��5
      � .+�5   
   ]� $	��Top=�6   $��5q�6,   .+�5      � 
����ح� � RowDefinitions 5      �� 5      $
��Auto �6%   �� 5      $
��Auto �6%   �� 5      $	��180 �6%   �� 5      $��* �6%   .+�5      ��  �� Orientation$ Vertical=�6   $
��Left=�5      $��0, 10, 0, 0q�60   $��2��6E   .+�5      �� -   5         ��Name$ 
btnProduct��5      $��10q�61   $��80��6=   $��Product��6H   6Z   �� 5      -   5        $ btnOrder��5      $��10q�6/   $��80��6;   $��Order��6F   6V   �� 5      -   5        $ 	btnMember��5      $��10q�60   $��80��6<   $��Member��6G   �� 5      -   5        $ 	btnLogOut��5      $��10q�60   $��80��6<   $��LogOut��6G   6X   5      �� 5      $ Vertical=�6   $��Center=�5       $	��500��6:   .+�5"      �� -   5        $��lbTitle��5"      
���  ��$��DemiBold"�6<   $��20(�5#      $��Member Manager��6*   �� 5%      -   5        $��
lbMemberId��5%      $��	Member Id��6.   �� 5&      -   5        $��txtMemberId��5&      $��Stretch=�61   $��25��5'      ��6*   ��  �� Path$ MemberId� �� Mode$ OneWay=� � DataContext 5(      ��  �� ElementName$ 	lvMembers��$ SelectedItem��� 5*      -   5        $��lbEmail��5*      $��Email��6+   6=   �� 5+      -	   5        $��txtEmail��5+      $��Stretch=�6.   $��25��5,      ��6*   �� $ Email�$ OneWay=� 5-      �� $ 	lvMembers��$ SelectedItem��� 5/      -
   5        $��lbCompanyName��5/      $��CompanyName��61   6I   �� 50      -   5        $��txtCompanyName��50      $��Stretch=�64   $��25��51      ��6*   �� $ CompanyName�$ OneWay=� 52      �� $ 	lvMembers��$ SelectedItem��� 54      -   5        $��lbCity��54      $
��City��6*   6;   �� 55      -   5        $��txtCity��55      $��Stretch=�6-   $��25��56      ��6*   �� $
 City�$ OneWay=� 57      �� $ 	lvMembers��$ SelectedItem��� 59      -   5        $��	lbCountry��59      $��Country��6-   6A   �� 5:      -   5        $��
txtCountry��5:      $��Stretch=�60   $��25��5;      ��6*   �� $ Country�$ OneWay=� 5<      �� $ 	lvMembers��$ SelectedItem��� 5>      -   5        $��
lbPassword��5>      $��Password��6.   6C   �� 5?      -   5        $��txtPassword��5?      $��Stretch=�61   $��25��5@       �� 
IsReadOnly$
 True��5A   _   ��5@   *   �� $ Password�$ OneWay=� 5A      �� $ 	lvMembers��$ SelectedItem�6_   5D      �� 5F      $��1��6   $ 
Horizontal=�6*   $��Center=�6C   .+�5G      �� -   5        $ 	btnInsert��5G      $��10q�60   $��80��6<   $��Insert��6G   6X   �� 5H      -   5        $ 	btnUpdate��5H      $��10q�60   $��80��6<   $��Update��6G   6X   �� 5I      -   5        $ 	btnDelete��5I      $��10q�60   $��80��6<   $��Delete��6G   6X   �� 5J      -   5        $ 	btnSearch��5J      $��10q�60   $��80��6<   $��Seach��6G   6W   5K      �� 5N      -   5        $��	lvMembers��5N   (   $��2��6   $
��Auto��69   $
��Auto��6F   	 �� View	 5O      �� 5P      .P�5Q      �� $��	Member Id��6-   
 �� Width$	
 100��6@    �� DisplayMemberBinding 6L   �� $ MemberId��� 5R      $��Email��6-   $	
 150��6<    6H   �� $ Email��� 5S      $��Company Name��6-   $	
 150��6C    6O   �� $ CompanyName��� 5T      $
��City��6-   $	
 150��6;    6G   �� $
 City��� 5U      $��Country��6-   $	
 150��6>    6J   �� $ Country��� 5V      $��Password��6-   $	
 100��6?    6K   �� $ Password�5W      5Z      5^      5_      5`      5a      