   M S B A M L   `   `   `  ����I  EHospitalWPFApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:HospitalWPFAppHospitalWPFApp  5   	       HospitalWPFApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:HospitalWPFApp     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �� -   5        .+�5
   
   �� $��APPOINTMENTS MANAGEMENT��6   $
��Left=�62   $��23��6M   $��
291,28,0,0q�6Y   $	��Top=�6m   $	��366��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgvAppointments��5      $	��175��5      $	��800��5      $��Center=�5         AutoGenerateColumns$ False��5         ColumnWidth5  /System.Windows.Controls.DataGridLengthConverter$ * 5      
 �� Top$ 67��5         
IsReadOnly$
 True��5      $	��Top=�5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      �� *AppointmentId+  5      $
 Date��6%    5      �� *AppointmentDateTime+  5      $ Reason��6%    5      �� *Reason+  5      $ Patient��6%    5      �� *Patient.PatientName+  5      $ Doctor��6%    5      �� *Doctor.DoctorName+5!      �� 5"   
   $��Id��6   $
��Left=�6   $��26��68   $��
99,269,0,0q�6D   $	��Top=�6X   $��73��6p   �� 5#   
   $��Reason��6   $
��Left=�6!   $��26��6<   $��
99,300,0,0q�6H   $	��Top=�6\   $��73��6t   �� 5$   
   $��Doctor��6   $
��Left=�6!   $��26��6<   $��
99,331,0,0q�6H   $	��Top=�6\   $��73��6t   	 J� RenderTransformOrigin$	 0.331,2.423&�6   �� 5%   
   -   5        
 ��Name$
 txtAppointmentId��5%       �� 
IsReadOnly$
 true��6,   $
��Left=�6>   $��23��6Y   $��177,272,0,0q�6e    �� TextWrapping$
 Wrap=�6z   $	��Top=�6�   $	��128��6�   �� 5&   
   -   5        $
 	txtReason��5&      $
��Left=�6%   $��23��6@   $��177,303,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��128��6�   �� 5'   
   -   5         ��Name$ 	cboDoctor��5'      $
��Left=�6&   $��23��6A   $��177,334,0,0q�6M   $	��Top=�6c   $	��128��6{   �� 5(   
   $
��Date��6   $
��Left=�6   $��26��6:   $��430,269,0,0q�6F   $	��Top=�6[   $��73��6s   �� 5)   
   $��Patient��6   $
��Left=�6"   $��26��6=   $��430,300,0,0q�6I   $	��Top=�6^   $��73��6v   �� 5*   
   -   5        $ 
cboPatient��5*      $
��Left=�6'   $��23��6B   $��508,303,0,0q�6N   $	��Top=�6d   $	��128��6|   (  "System.Windows.Controls.DatePicker  5+   
   -   5          Name$ txtAppointmentDate��5+      $
��Left=�61   $��508,271,0,0q�6L   $	��Top=�6a   $	��128��6y   �� 5,   
   -   5         ��Name$ btnSave��5,      $
��Save��6"   $
��Left=�61   $��32��6L   $��172,375,0,0q�6X   $	��Top=�6m   $��82��6�   6�   �� 5-   
   -	   5        $ 	btnDelete��5-      $��Delete��6$   $
��Left=�65   $��32��6P   $��367,375,0,0q�6\   $	��Top=�6q   $��82��6�   6�   �� 5.   
   -
   5        $ btnClear��5.      $��Clear��6#   $
��Left=�63   $��32��6N   $��562,375,0,0q�6Z   $	��Top=�6o   $��82��6�   6�   50      51      