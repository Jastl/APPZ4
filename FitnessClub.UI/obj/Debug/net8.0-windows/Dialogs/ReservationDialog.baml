   M S B A M L   `   `   `  ����  FitnessClub.UI&     FitnessClub.UI.ReservationDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Make Reservation��5   	   $	��400��6"   $	��500��6/    � WindowStartupLocation$ CenterOwner=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Client:��6-   $��0,0,10,5q�6?   �� 5   
   -   5         ��Name$ clientComboBox��5      $��0��5      $��1��6     �� DisplayMemberPath$ FullName��5       �� SelectedValuePath$ Id��5      $��0,0,0,5q�5      �� 5   
   $��1��6   $��0��6   $��	Schedule:��6-   $��0,0,10,5q�6A   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ scheduleGrid��5      $��2��5      $��0��6    $��2��60      AutoGenerateColumns$ False��5      	   
IsReadOnly$
	 True��5      
   SelectionMode$
 Single=�5      $��0,0,0,10q�5!         Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ Activity��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� *ActivityName+6X     5$      $ 
Start Time��6%   $	 150 6m    69   �� *	StartTime+ �� StringFormat$ {0:g}��6m     5%      $ End Time��6%   $	 150 6i    67   �� *	EndTime+$ {0:g}��6i     5&      $ Available Spots��6%   $	 100 6a    6>   �� *AvailableSpots+6a   5(      �� 5*   
   $��3��6   $��0��6"   $��2��62    �� Orientation$ 
Horizontal=�5+      $��Right=�6.   .+�5,      �� -   5         ��Name$ btnSave��5,      $
��Save��6&   $��70��65   $��0,0,10,0q�5-      ${�False��6'   �� 5.      -   5        $��Cancel��5.      $��70��6&   61   5/      50      51      