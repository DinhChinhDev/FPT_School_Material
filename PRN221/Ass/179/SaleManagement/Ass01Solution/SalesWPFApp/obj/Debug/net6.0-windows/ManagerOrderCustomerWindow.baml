   M S B A M L   `   `   `  ����F  BSalesWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SalesWPFAppSalesWPFApp  5   	   \ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35`Dclr-namespace:System.Windows.Controls;assembly=PresentationFrameworkSystem.Windows.Controls 5   	   ,    &SalesWPFApp.ManagerOrderCustomerWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:SalesWPFApp     5   	   YcontrolsDclr-namespace:System.Windows.Controls;assembly=PresentationFramework     5   	     � Title$   ManagerOrderCustomerWindow��5	   	   $	��620��6,   $	��900��69   .��5
      � .+�5   
   ]� $	��Top=�6   $��5q�6,   .+�5      � 
����ح� � RowDefinitions 5      �� 5      $
��Auto �6%   �� 5      $
��Auto �6%   �� 5      $	��180 �6%   �� 5      $��* �6%   .+�5      � .+�5      ��  �� Orientation$ Vertical=�6!   $
��Left=�5      $��0, 10, 0, 0q�60   $��2��6E   .+�5      �� -   5         ��Name$ btnOrder��5   !   $��10q�63   $��80��6?   $��Order��6J   6Z   �� 5      -   5        $ 
btnAccount��5   !   $��10q�65   $��80��6A   $��Account��6L   6^   �� 5      -   5        $ 	btnLogOut��5   !   $��10q�64   $��80��6@   $��LogOut��6K   6\   5      �� 5      $ Vertical=�6!   $��Center=�5       $	��400��6:   .+�5"      �� -   5         ��Name$ lbTitle��5"       
���  ��$��DemiBold"�6B   $��20(�5#      $��Shopping��6*   $	��250��6=   �� 5%      -   5        $ 	lbOrderId��5%       $��Order Id��63   $	��250��6F   �� 5&      -   5         ��Name$ 
txtOrderId��5&   "   $��Stretch=�66   $��25��5'      $	��250��6*   ��66   �� *	OrderId+ �� Mode$ OneWay=� � DataContext 5(      �� *SelectedItem+ �� ElementName$ lvOrders���� 5*      -   5        $��lbOrderDate��5*       $��
Order Date��63   $	��250��6I   (  "System.Windows.Controls.DatePicker  5+      -   5        $��myOrderDate��5+   .   $��Stretch=�6A   $��25��5,      $	��250��5-   ^   	   Text	 5,   *   �� 
 �� Path$
 	OrderDate�$ OneWay=� 5-      �� $ lvOrders��$
 SelectedItem�6^   �� 5/      -	   5        $��lbRequiredDate��5/       $��Required Date��66   $	��250��6O     50      -
   5        $��myRequiredDate��50   .   $��Stretch=�6D   $��25��51      $	��250��52   ^   	 51   *   �� $
 RequiredDate�$ OneWay=� 52      �� $ lvOrders��$
 SelectedItem�6^   �� 54      -   5        $��lbShippedDate��54       $��Shipped Date��65   $	��250��6M     55      -   5        $��myShippedDate��55   .   $��Stretch=�6C   $��25��56      $	��250��57   ^   	 56   *   �� $
 ShippedDate�$ OneWay=� 57      �� $ lvOrders��$
 SelectedItem�6^   �� 59      -   5        $ 	lbFreight��59       $��Freight��63   $	��250��6E   �� 5:      -   5        $ 
txtFreight��5:   "   $��Stretch=�66   $��25��5;      $	��250��6*   ��66   �� *	OrderId+$ OneWay=� 5<      �� *SelectedItem+$ lvOrders��5?      �� 5@      $ Vertical=�6!   $��Center=�5A      $	��300��6:   .+�5C      �� -   5        $	 lbc��5C       
���  ��$��DemiBold"�6>   $��20(�5D      $�� ��6*   $	��250��65   �� 5F      -   5        $ lProduct��5F       $��Product��62   $	��250��6D   �� 5G      -   5        $��	ComboBox1��5G   #   $	��250��6b   .@�5H      �� $��1��6+   69   5I      �� 5K      -   5        $ lbUnitPrice��5K       $��	UnitPrice��65   $	��250��6I   �� 5L      -   5        $ txtUnitPrice��5L   "   $��Stretch=�68   $��25��5M      $	��250��6*   ��66   �� *	UnitPrice+$ OneWay=� 5N      �� *SelectedItem+$ 
lvProducts���� 5P      -   5        $ 
lbQuantity��5P       $��Quantity��64   $	��250��6G   �� 5Q      -   5        $ txtQuantity��5Q   "   $��Stretch=�67   $��25��5R      $	��250��6*   ��66   �� *
Quantity+$ OneWay=� 5S      �� *SelectedItem+$ 
lvProducts��5U      5V      �� 5Y      $��1��6   $ 
Horizontal=�6*   $��Center=�6C   .+�5Z      �� -   5        $ 	btnInsert��5Z      $��10q�60   $��80��6<   $��Order��6G   6W   �� 5[      -   5        $ 	btnDelete��5[      $��10q�60   $��80��6<   $��Delete��6G   6X   5\      �� 5_      -   5        $��lvOrders��5_   (   $��2��6   $
��Auto��68   $
��Auto��6E    �� View 5`      �� 5a      .P�5b      �� $��Order Id��6-    �� Width$	 150��6?    �� DisplayMemberBinding 6K   �� $
 OrderId��� 5c      $��	OrderDate��6-   $	 200��6@    6L   �� $
 	OrderDate��� 5d      $��RequiredDate��6-   $	 200��6C    6O   �� $
 RequiredDate��� 5e      $��ShippedDate��6-   $	 200��6B    6N   �� $
 ShippedDate��� 5f      $��Freight��6-   $	 150��6>    6J   �� $
 Freight�5g      5j      5n      5o      5p      5q      