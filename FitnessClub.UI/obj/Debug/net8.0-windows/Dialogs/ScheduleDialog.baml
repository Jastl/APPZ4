   M S B A M L   `   `   `  ����  FitnessClub.UI#    FitnessClub.UI.ScheduleDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Schedule Details��5   	   $	��400��6"   $	��500��6/    � WindowStartupLocation$ CenterOwner=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5	      $
��Auto �6   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Activity Name:��6-   $��0,0,10,5q�6F   �� 5   
   $��0��6   $��1��6   $��0,0,0,5q�5      ��5      �� *ActivityName+5      �� 5   
   $��1��6   $��0��6   $��Start Time:��6-   $��0,0,10,5q�6C   �� 5   
   $��1��6   $��1��6"    �� Orientation$ 
Horizontal=�62   $��0,0,0,5q�6K   .+�5      (  "System.Windows.Controls.DatePicker  -   5          Name$ startDatePicker��5      $	��120��62   $��0,0,10,0q�6>      SelectedDate 5      �� *	StartTime+ �� Mode$ TwoWay=��� 5      -   5         ��Name$ startTimeComboBox��5      $��80��62   5      5       �� 5"   
   $��2��6   $��0��6   $��	End Time:��6-   $��0,0,10,5q�6A   �� 5#   
   $��2��6   $��1��6"   $ 
Horizontal=�62   $��0,0,0,5q�6K   .+�5$        -   5        $ endDatePicker��5$      $	��120��60   $��0,0,10,0q�6<    5%      �� *	EndTime+$ TwoWay=��� 5&      -   5        $ endTimeComboBox��5&      $��80��60   5'      5(      �� 5*   
   $��3��6   $��0��6   $��Max Participants:��6-   $��0,0,10,5q�6I   �� 5+   
   $��3��6   $��1��6   $��0,0,0,5q�5-      ��5,      �� *MaxParticipants+5-      �� 5/   
   $��6��6   $��0��6"   $��2��62   $ 
Horizontal=�50      $��Right=�6.   .+�51      �� -   5        $
��Save��51      $��70��6$   $��0,0,10,0q�6E   �� 52      -   5        $��Cancel��52      $��70��6&   61   53      54      55      