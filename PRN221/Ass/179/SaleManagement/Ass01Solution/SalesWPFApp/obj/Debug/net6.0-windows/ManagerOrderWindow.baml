   M S B A M L   `   `   `  ����\  XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35`Dclr-namespace:System.Windows.Controls;assembly=PresentationFrameworkSystem.Windows.Controls  5   	   F BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesWPFAppSalesWPFApp 5   	   $   SalesWPFApp.ManagerOrderWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml      5   	   @d2http://schemas.microsoft.com/expression/blend/2008      5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006      5   	   YcontrolsDclr-namespace:System.Windows.Controls;assembly=PresentationFramework      5   	   +localclr-namespace:SalesWPFApp      5   	     � Title$  ManagerOrderWindow��5	   	   $	��620��6$   $	��800��61   .��5
      � .+�5   
   ]� $	��Top=�6   $��5q�6,   .+�5      � 
����ح� � RowDefinitions 5      �� 5      $
��Auto �6$   �� 5      $
��Auto �6$   �� 5      $	��180 �6$   �� 5      $��* �6$   .+�5      ��  �� Orientation$ Vertical=�6   $
��Left=�64   $��0, 10, 0, 0q�6O   $��2��6d   .+�5      �� -   5         ��Name$ 
btnProduct��5      $��10q�61   $��80��6=   $��Product��6H   6Z   �� 5      -   5        $ btnOrder��5      $��10q�6/   $��80��6;   $��Order��6F   6V   �� 5      -   5        $ 	btnMember��5      $��10q�60   $��80��6<   $��Member��6G   6X   �� 5      -   5        $ 	btnLogOut��5      $��10q�60   $��80��6<   $��LogOut��6G   6X   5      �� 5      $ Vertical=�6   $��Center=�64   $	��400��6Q   .+�5      �� -   5         ��Name$ lbTitle��5      
���  ��$��DemiBold"�6>   $��20(�6T   $��Shopping��6b   �� 5      -   5        $ 	lbOrderId��5      $��Order Id��6/   �� 5      -   5         ��Name$ 
txtOrderId��5      $��Stretch=�62   $��25��6P   ��5       �� *	OrderId+ �� Mode$ OneWay=� � DataContext 5!      �� *SelectedItem+ �� ElementName$ lvOrders���� 5"      -   5        $��lbOrderDate��5"      $��
Order Date��6/   (   "System.Windows.Controls.DatePicker  5#      -	   5        $��myOrderDate��5#   *   $��Stretch=�6=   $��25��6[   	   SelectedDate	 5$   *   �� 
 �� Path$
 	OrderDate�$ OneWay=� 5%   *   �� $ lvOrders��$
 SelectedItem��� 5&      -
   5        $��lbRequiredDate��5&      $��Required Date��62     5'      -   5        $��myRequiredDate��5'   *   $��Stretch=�6@   $��25��6^   	 5(   *   �� $
 RequiredDate�$ OneWay=� 5)   *   �� $ lvOrders��$
 SelectedItem��� 5*      -   5        $��lbShippedDate��5*      $��Shipped Date��61     5+      -   5        $��myShippedDate��5+   *   $��Stretch=�6?   $��25��6]   	 5,   *   �� $
 ShippedDate�$ OneWay=� 5-   *   �� $ lvOrders��$
 SelectedItem��� 5.      -   5        $ 	lbFreight��5.      $��Freight��6/   �� 5/      -   5        $ 
txtFreight��5/      $��Stretch=�62   $��25��6P   ��50      �� *	Freight+$ OneWay=� 51      �� *SelectedItem+$ lvOrders��52      �� 54      $��1��6   $ 
Horizontal=�6*   $��Center=�6C   .+�55      �� -   5        $ 	btnUpdate��55      $��10q�60   $��80��6<   $��Update��6G   6X   �� 56      -   5        $ 	btnDelete��56      $��10q�60   $��80��6<   $��Delete��6G   6X   57      �� 59      -   5        $��lvOrders��59   (   $��2��6   $
��Auto��68   $
��Auto��6E    �� View 5:      �� 5;      .P�5<      �� $��Order Id��6-    �� Width$	 100��6?    �� DisplayMemberBinding 6K   �� $
 OrderId��� 5=      $��	OrderDate��6-   $	 200��6@    6L   �� $
 	OrderDate��� 5>      $��RequiredDate��6-   $	 200��6C    6O   �� $
 RequiredDate��� 5?      $��ShippedDate��6-   $	 200��6B    6N   �� $
 ShippedDate��� 5@      $��Freight��6-   $	 100��6>    6J   �� $
 Freight�5A      5C      5G      5H      5I      5J      