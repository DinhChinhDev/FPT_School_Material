   M S B A M L   `   `   `  ����  SalesWPFApp    SalesWPFApp.WindowOrders   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Manage Orders��5   	   $	��500��6   $	��800��6,    � WindowStartupLocation$ CenterScreen=�68   .��5      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��dgOrders��5         AutoGenerateColumns$ False��6#   $
��Left=�6?   $��10,10,10,200q�6Z   $	��Top=�6p   $	��150��6�   $	��760��6�      Columns 5	      0  *System.Windows.Controls.DataGridTextColumn  5
      ,  &System.Windows.Controls.DataGridColumn   Header$ Order ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6S      
IsReadOnly$
 True��6_   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *	OrderId+6_     5      $ 	Member ID��6%   $	 100 6U    68   �� *
MemberId+6U     5      $ 
Order Date��6%   $	 150 6W    69   �� *	OrderDate+6W     5      $ Required Date��6%   $	 150 6]    6<   �� *RequiredDate+6]     5      $ Shipped Date��6%   $	 150 6[    6;   �� *ShippedDate+6[     5      $ Freight��6%   $	 100 6R    66   �� *	Freight+6R   5      �� 5   
   $��Order Details��6   $
��Left=�6(   $	��Top=�6C   $��
10,170,0,0q�6[   $
��Bold"�6o     5   
   -   5        $��dgOrderDetails��5      $ False��6)   $
��Left=�6E   $��10,200,10,10q�6`   $��Bottom=�6v   $	��200��6�   $	��760��6�    5        5      $ 
Product ID��6%   $	 100 6W   $
 True��6c    69   �� *	ProductId+6c     5      $ 
Unit Price��6%   $	 100 6W    69   �� *	UnitPrice+6W     5      $ Quantity��6%   $	 100 6T    67   �� *
Quantity+6T     5      $ Discount��6%   $	 100 6T    67   �� *
Discount+6T   5      5      5       