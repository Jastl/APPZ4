   M S B A M L   `   `   `  ����  FitnessClub.UI*    $FitnessClub.UI.Pages.ReservationPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     N� Title$  Reservations��5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5	      $��* �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      �� -   5         ��Name$ btnMakeReservation��5      $��Make Reservation��61   $	��120��6m   $��0,0,10,0q�6y   �� 5      -   5        $ 
btnRefresh��5      $��Refresh��6)   $��70��6T   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   $��0,0,0,10q�6;   .+�5      �� $��Club:��6   $��Center=�6$   �� 5      -   5         ��Name$ clubComboBox��5      $	��200��6-   $��5,0,10,0q�69    �� DisplayMemberPath$
 Name��5       �� SelectedValuePath$ Id��5      5      �� 5      $��Date:��6   $��Center=�6$   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 
datePicker��5      $	��120��6-   $��5,0,0,0q�69   5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ reservationsGrid��5      $��2��6-   	   AutoGenerateColumns$	 False��6:   
   
IsReadOnly$

 True��5         SelectionMode$ Single=�6%      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Activity��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6a   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *Schedule.ActivityName+6a     5       $ 
Start Time��6%   $	 150 6v    69   �� *Schedule.StartTime+ �� StringFormat$ {0:g}��6v     5!      $ End Time��6%   $	 150 6r    67   �� *Schedule.EndTime+$ {0:g}��6r     5"      $ Client��6%   $	 200 6Y    65   �� *Client.FullName+6Y     5#      $ Status��6%   $	 100 6U    65   �� *IsConfirmed+6U   4  .System.Windows.Controls.DataGridTemplateColumn  5$      $ Actions��6)   $	 100 6:      CellTemplate 5%      �� 5&      .R�5'      �� $ 
Horizontal=�6)   .+�5(   "   �� -   5        $��Cancel��5(   )   $	��5,0q�5)   )   5*      5+      5-      5/      50      51      